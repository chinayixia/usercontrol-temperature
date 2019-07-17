using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

using System.Threading;
using System.IO;


namespace wf_qc_foh_100
{
    /// <summary>
    /// 线程测试待优化
    /// </summary>
    public partial class FOHW : Form
    {

        #region  instrumentation command
        //PMT-300温度、电压读取：
        string pmt300_state_command = "system,state" + "\r\n";

        //FOH-100
        string foh100_state_command = "system state" + "\r\n";
        string foh100_onu_command = "sys onu";
        #endregion

        //serial communication part         
        public byte[] a = new byte[13];
        //  private SerialPort com = new SerialPort();
        public USB usb;
        private Thread thread;

        int sendCount = 1;   //send command times
        public FOHW()
        {
            InitializeComponent();


            //graph part
            f_saveReadFirst(false);

            //serial communiacation part            
            usb = new USB();
            Init();
        }
        ///test timer
        ///用TimeSpan将计数器的整数转化为DateTime日期
        ///定义Timer类变量
        System.Timers.Timer test_timer;
        long TimeCount;
        //定义委托
        public delegate void SetControlValue(long value);

        //graph part
        private Color[] m_colors;
        private float m_fstyle;
        private int[] m_istyle;
        /// <summary>
        /// 获取初始的波形显示控件的样式或设置为初始样式
        /// </summary>
        /// <param name="isRead">获取ture | 设置false</param>
        private void f_saveReadFirst(bool isRead)
        {
            if (!isRead)
            {
                m_colors = new Color[18];
                m_istyle = new int[2];
                m_istyle[0] = LGraphTest.m_titleSize;
                m_fstyle = LGraphTest.m_titlePosition;
                m_colors[0] = LGraphTest.m_titleColor;
                m_colors[1] = LGraphTest.m_titleBorderColor;
                m_colors[2] = LGraphTest.m_backColorL;
                m_colors[3] = LGraphTest.m_backColorH;
                m_colors[4] = LGraphTest.m_coordinateLineColor;
                m_colors[5] = LGraphTest.m_coordinateStringColor;
                m_colors[6] = LGraphTest.m_coordinateStringTitleColor;
                m_istyle[1] = LGraphTest.m_iLineShowColorAlpha;
                m_colors[7] = LGraphTest.m_iLineShowColor;
                m_colors[8] = LGraphTest.m_GraphBackColor;
                m_colors[9] = LGraphTest.m_ControlItemBackColor;
                m_colors[10] = LGraphTest.m_ControlButtonBackColor;
                m_colors[11] = LGraphTest.m_ControlButtonForeColorL;
                m_colors[12] = LGraphTest.m_ControlButtonForeColorH;
                m_colors[13] = LGraphTest.m_DirectionBackColor;
                m_colors[14] = LGraphTest.m_DirectionForeColor;
                m_colors[15] = LGraphTest.m_BigXYBackColor;
                m_colors[16] = LGraphTest.m_BigXYButtonBackColor;
                m_colors[17] = LGraphTest.m_BigXYButtonForeColor;

                LGraphTest.m_SyStitle = "Sample  Graph";     //LGraphTest.m_SyStitle = tb_title.Text.ToString();  
                LGraphTest.m_SySnameX = "Count";                         // LGraphTest.m_SySnameX = tb_x.Text.ToString();
                LGraphTest.m_SySnameY = "Data";                   //LGraphTest.m_SySnameY = tb_y.Text.ToString();


                //this.groupBox1.Paint += groupBox1_Paint;

                //graph show 
                ToggleControls(true);
                lbl_test_time.Visible = false;
                btn_stop_sample.Enabled = false;

                //test timer
                //设置时间间隔ms
                int interval = 1000;
                test_timer = new System.Timers.Timer(interval);
                //设置重复计时
                test_timer.AutoReset = true;
                //设置执行System.Timers.Timer.Elapsed事件
                test_timer.Elapsed += new System.Timers.ElapsedEventHandler(test_timer_tick);

                //textbox view log
                tbxView.Text = System.Environment.CurrentDirectory + "\\fohlog.txt";

                //init_comboBox_devices
                init_comboBox_devices();

            }

        }


        // reset groupbox1 
        //private void groupBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.Clear(this.BackColor);            
        //    SizeF fontSize = e.Graphics.MeasureString(groupBox1.Text, groupBox1.Font);
        //    //font etc.
        //    e.Graphics.DrawString(groupBox1.Text, groupBox1.Font, Brushes.DarkGray, (groupBox1.Width - fontSize.Width) / 2, 1);
        //    //recolor DarkGray
        //    e.Graphics.DrawLine(Pens.DarkGray, 1, 10, (groupBox1.Width - fontSize.Width) / 2, 10);
        //    e.Graphics.DrawLine(Pens.DarkGray, (groupBox1.Width + fontSize.Width) / 2 - 4, 10, groupBox1.Width - 2, 10);

        //    //Transparency
        //    //this.groupBox1.BackColor = Color.Gray;
        //    //this.TransparencyKey = Color.Gray;           
        //}

        private void ToggleControls(bool value)
        {
            checkBox_manul.Enabled = !value;
            checkBox_scatter.Enabled = !value;
            btn_clear_graph.Enabled = !value;
            // btn_stop_sample.Enabled = !value;
            btn_start_sample.Enabled = !value;
            tb_sample_frequency.Enabled = !value;
         
            // Color.FromArgb(204, 204, 204)
            //rtbShowInfo.BackColor = Color.FromArgb(204, 204, 204);
            //tbxSendCommand.BackColor = Color.FromArgb(245, 245, 243);


        }

        private void TextboxControls(bool value)
        {            
            tb_sample_frequency.Text = "";
           
        }


        #region **测试数据**
        public List<float> x1 = new List<float>();
        public List<float> y1 = new List<float>();
        public List<float> x2 = new List<float>();
        public List<float> y2 = new List<float>();
        public List<float> x3 = new List<float>();
        public List<float> y3 = new List<float>();
        public List<float> x4 = new List<float>();
        public List<float> y4 = new List<float>();

        private int timerDrawI = 0;

        //线程测试
        private static bool _isDone = false;
        private static object _lock = new object();
        private bool done;
        static object locker = new object();
        private delegate void txtHandeler(object obj);
        #endregion




        //private void start_sample()
        //{

        //    int i = 0;


        //    if (checkBox_manul.Checked)
        //    {
        //        Action<int> action = (data) =>
        //        {

        //            ToggleControls(true);
        //            lbl_test_time.Visible = true;


        //            this.Focus();

        //            //int current;
        //            //if (int.TryParse(tb_sample_frequency.Text.ToString(), out current))
        //            //{
        //            //    if (current > 0)  // && current < 300
        //            //    {
        //            //        timerDraw.Interval = (current * 6000);
        //            //    }
        //            //    else
        //            //    {
        //            //        tb_sample_frequency.Text = "1";
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    tb_sample_frequency.Text = "1";
        //            //}
        //            //  x1.Clear();
        //            // y1.Clear();

        //            // x2.Clear();
        //            // y2.Clear();
        //            //  x3.Clear();
        //            //  y3.Clear();
        //            //  x4.Clear();
        //            //  y4.Clear();
        //            //  LGraphTest.f_ClearAllPix();
        //            LGraphTest.f_reXY();
        //            LGraphTest.f_LoadOnePix(ref x1, ref y1, Color.Red, 2);




        //            //    LGraphTest.f_AddPix(ref x2, ref y2, Color.Blue, 3);
        //            //  LGraphTest.f_AddPix(ref x3, ref y3, Color.FromArgb(0, 128, 192), 2);
        //            //  LGraphTest.f_AddPix(ref x4, ref y4, Color.Yellow, 3);

        //            // f_timerDrawStart(); //start sample timer

        //            timerDrawI = 0;
        //            x1.Add(timerDrawI);
        //            y1.Add(float.Parse(tb_mcu_temperate.Text));
        //            timerDrawI++;
        //            LGraphTest.f_Refresh();

        //            lbl_status.Text = "SAMPLING[Period" + tb_sample_frequency.Text + "s]...";

        //            //test timer label
        //            //开始计时
        //            test_timer.Start();
        //            TimeCount = 0;
        //        };
        //        Invoke(action, i);
        //        i++;
        //    }

        //    else
        //    {
        //        Action<int> action = (data) =>
        //    {
        //        ToggleControls(true);
        //        lbl_test_time.Visible = false;

        //        //list add serial data 

        //        this.Focus();

        //        tb_sample_frequency.Text = "";
        //        //  tb_sample_frequency.Enabled = false;


        //        // x1.Clear();
        //        // y1.Clear();
        //        // LGraphTest.f_ClearAllPix();
        //        //LGraphTest.f_reXY();
        //        LGraphTest.f_LoadOnePix(ref x1, ref y1, Color.Red, 2);


        //        //foh100_state();




        //        x1.Add(timerDrawI++);
        //        //y1.Add(timerDrawI);
        //        y1.Add(float.Parse(tb_mcu_temperate.Text));
        //        ReceivedTextBox.Text += (float.Parse(tb_mcu_temperate.Text)).ToString() + "     ";
        //        // timerDrawI++;             


        //        LGraphTest.f_Refresh();


        //    };
        //        Invoke(action, i);
        //        i++;

        //    }
        //}
        private void timerDraw_Tick(object sender, EventArgs e)
        {
            ///TIME增加数据
            //x1.Add(timerDrawI);
            // y1.Add(timerDrawI % 100);
            //  x2.Add(timerDrawI);
            //  y2.Add((float)Math.Sin(timerDrawI / 10f) * 200);
            // x3.Add(timerDrawI);
            //  y3.Add(50);
            //  x4.Add(timerDrawI);
            //   y4.Add((float)Math.Sin(timerDrawI / 10) * 200);           
            // timerDrawI++;
            //LGraphTest.f_Refresh();

            foh100_state();
            Thread.Sleep(500);
            foh100_onu();
            //  lbl_status.Text = "SAMPLING[Period" + tb_sample_frequency.Text + "s]";
       

        }

        private void f_timerDrawStart()
        {
            timerDrawI = 0;

            //set  timerDraw.Interval
            int current;
            if (int.TryParse(tb_sample_frequency.Text.ToString(), out current))
            {
                if (current > 1)  // && current < 300
                {
                    timerDraw.Interval = current * 1000;
                }
                else
                {
                    tb_sample_frequency.Text = "2";
                    timerDraw.Interval = 2000; ;
                }
            }
            else
            {
                tb_sample_frequency.Text = "2";
                timerDraw.Interval = 2000; ;
            }
            timerDraw.Start();

            tb_sample_frequency.ReadOnly = true;

            btn_clear_graph.Enabled = false;
        }


        private void f_timerDrawStop()
        {
            timerDraw.Stop();
            tb_sample_frequency.ReadOnly = false;
            // textBox数值.ReadOnly = false;
            btn_start_sample.Enabled = true;
            btn_clear_graph.Enabled = true;
        }


        private void stop_sample()
        {
            ///关闭TIMER
            btn_stop_sample.Enabled = false;
            this.Focus();
            f_timerDrawStop();
            lbl_status.Text = "SAMPLING STOPED.";
            btn_stop_sample.Enabled = true;
            //ToggleControls(false);


            //test timer label
            //停止计时
            test_timer.Stop();
        }


        private void clear_sample()
        {
            timerDraw.Stop();
            timerDrawI = 0;

            x1.Clear();
            y1.Clear();
            LGraphTest.f_ClearAllPix();
            lbl_status.Text = "SAMPLING DATA CLEARED.";

        }



        #region  test timer label
        private void test_timer_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new SetControlValue(ShowTime), TimeCount);
            TimeCount++;
        }

        private void ShowTime(long t)
        {
            TimeSpan temp = new TimeSpan(0, 0, (int)t);
            lbl_test_time.Text = "采样计时：" + string.Format("{0:00}:{1:00}:{2:00}", temp.Hours, temp.Minutes, temp.Seconds);
        }

        #endregion



        //线程测试：


        private void Btn_stop_sample_Click(object sender, EventArgs e)
        {
            stop_sample();
            ToggleControls(false);
        }

        private void Btn_clear_graph_Click(object sender, EventArgs e)
        {
            stop_sample();
            clear_sample();
            // tb_send_count.Text = "";

        }



        #region serial communication part

        //initial serial port
        private void Init()
        {
            try
            {
                List<string> list = new List<string>();
                string[] ports = USB.GetPorts(); //SerialPort.GetPortNames();//

                PortcomboBox.Items.Clear();
                for (int i = 0; i < ports.Length; i++)
                {
                    PortcomboBox.Items.Add(ports[i]);
                }
                if (ports.Length > 0)
                {
                    PortcomboBox.SelectedIndex = ports.Length - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_portSearch_Click(object sender, EventArgs e)
        {
            Init();
        }

        //force quit form 
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                // 点击winform右上关闭按钮 
                usb.CloseCom();
                isExit = true;
            }
            base.WndProc(ref msg);
        }

        //open event 
        private Boolean isOpen = false;

        private void Btn_portOpen_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                try
                {
                    String comName = PortcomboBox.SelectedItem.ToString();
                    Boolean isOpenSuccess = usb.SetCom(PortcomboBox.SelectedItem.ToString());

                    //Timer tick
                    //System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
                    //myTimer.Tick += new EventHandler(timer1_Tick);
                    //myTimer.Enabled = true;
                    //myTimer.Interval = 10000;
                    //myTimer.Start();

                    //serial graph
                    //graph_serial();

                    if (isOpenSuccess)
                    {
                        isOpen = true;
                        btn_portOpen.Text = "Close";

                        lbl_status.Text = "The device is active";
                        //btn_start_sample.Enabled = true;
                        ToggleControls(false);

                        sendCount = 1;
                    }
                    else
                    {
                        isOpen = false;
                        btn_portOpen.Text = "Open";
                        lbl_status.Text = "Could not read any response";
                        ToggleControls(true);
                        btn_stop_sample.Enabled = false;
                        //  myTimer.Stop();
                    }


                }
                catch
                {
                    lbl_status.Text = "Check COM connection";

                }

            }
            else
            {
                stop_sample();   //stop sample
                usb.CloseCom();
                btn_portOpen.Text = "Open";
                isOpen = false;

                ToggleControls(true);
                btn_stop_sample.Enabled = false;
            }
        }
        Boolean isExit = false;

        private void foh100_state()
        {
            if (isOpen)
            {
                try
                {
                    //usb.SendData(tb_send.Text);
                    usb.SendData(foh100_state_command);
                    thread = new Thread(new ThreadStart(GetData_foh100_state));
                    thread.Start();
                }
                catch
                {
                    MessageBox.Show("串口数据写入错误", "错误");
                    usb.CloseCom();
                }
            }
        }
        private void foh100_onu()
        {
            if (isOpen)
            {
                try
                {
                    //usb.SendData(tb_send.Text);
                    usb.SendData(foh100_onu_command);
                    thread = new Thread(new ThreadStart(GetData_foh100_onu));
                    thread.Start();
                }
                catch
                {
                    MessageBox.Show("串口数据写入错误", "错误");
                    usb.CloseCom();
                }
            }
        }

        // Random rand = new Random();
      
        public void GetData_foh100_state()
        {
            String msg = "";

            Thread.Sleep(100);


            int i = 0;

            msg = usb.ReadData();


            if (msg.Contains("sys_power_flg")) // || msg.Contains( "onu_info.rx_lenth")
            {

                Action<int> action = (data) =>
                {
                    int start0 = msg.IndexOf("mcu_temperate");
                    int length0 = " = 36.71".Length;
                    String tmpValue0 = msg.Substring(start0 + 15, length0 - 1).Trim();

                    int start1 = msg.IndexOf("battary_volatge ");
                    int length1 = " = 4.30".Length;
                    String tmpValue1 = msg.Substring(start1 + 17, length1).Trim();

                    int start2 = msg.IndexOf("fan_speed_test");
                    int length2 = " = 0  ".Length;
                    String tmpValue2 = msg.Substring(start2 + 16, length2-2).Trim();

                    // ReceivedTextBox.Text += msg + "\r\n";

                                   

                    //温度计显示
                    userControl1_temperature.CurValue = float.Parse(tmpValue0);
                    userControl1_temperature.Refresh();

                    //最大温度值：
                    if ( float.Parse(tb_temperature_max.Text) < float.Parse(tmpValue0))
                    { tb_temperature_max.Text = tmpValue0; }
                   


                    String responseoutput = String.Empty;
                    responseoutput = msg;
                    //save info log
                    StreamWriter file = new StreamWriter("fohlog.txt", true);
                    file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + "        " + responseoutput);
                    file.Close();

                    //graph list
                    //string amount = string.Empty;
                    //if (!string.IsNullOrEmpty(tmpValue0) && (Regex.IsMatch(tmpValue0, @"^[1-9]\d*|0$"))) // || Regex.IsMatch(tmpValue0, @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$")
                    //{
                    //    amount = Convert.ToDecimal(tmpValue0).ToString();

                    //}
                    //else
                    //{
                    //    amount = "0.00";
                    //}


                    //string amount = string.Empty;
                    //amount = tmpValue0.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");

                    y1.Add(float.Parse(tmpValue0));

                    //让文本框获取焦点 
                    this.ReceivedTextBox.Focus();
                    //设置光标的位置到文本尾 
                    this.ReceivedTextBox.Select(this.ReceivedTextBox.TextLength, 0);
                    //滚动到控件光标处 
                    this.ReceivedTextBox.ScrollToCaret();
                    ReceivedTextBox.Text += "temperature: " + float.Parse(tmpValue0) + "\r\n" + "battary_volatge: " + tmpValue1 + "\r\n" + "fan_speed: " + tmpValue2 + "\r\n";
                    x1.Add(timerDrawI);

                    // y1.Add(float.Parse(tb_mcu_temperate.Text));
                    timerDrawI++;
                    LGraphTest.f_Refresh();

                    lbl_send_count.Text = "采样计数: " + sendCount++.ToString();
                };
                Invoke(action, i);
                i++;

                //  }
                Thread.Sleep(200);
                //    }   
            }
        }

        public void GetData_foh100_onu()
        {
            String msg = "";

            Thread.Sleep(100);


            int i = 0;

            msg = usb.ReadData();


            if (msg.Contains( "onu_info.rx_lenth")) 
            {

                Action<int> action = (data) =>
                {
                    int start0 = msg.IndexOf("onu_info.present: ");
                    int length0 = " 0".Length;
                    String numValue0 = msg.Substring(start0+17 , length0).Trim();



                    // ReceivedTextBox.Text += msg + "\r\n";


                    //最少ONU数：
                    if (Convert.ToInt32( tb_onu_min.Text) > Convert.ToInt32(numValue0))
                    { tb_onu_min.Text = numValue0; }



                    String responseoutput = String.Empty;
                    responseoutput = msg;
                    //save info log
                    StreamWriter file = new StreamWriter("fohlog.txt", true);
                    file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + "        " + responseoutput);
                    file.Close();



                    //  y1.Add(float.Parse(tmpValue0));

                    //让文本框获取焦点 
                    this.ReceivedTextBox.Focus();
                    //设置光标的位置到文本尾 
                    this.ReceivedTextBox.Select(this.ReceivedTextBox.TextLength, 0);
                    //滚动到控件光标处 
                    this.ReceivedTextBox.ScrollToCaret();

                    ReceivedTextBox.Text += "onu number: " + numValue0 + "\r\n";
                  //  x1.Add(timerDrawI);

                    // y1.Add(float.Parse(tb_mcu_temperate.Text));
                  //  timerDrawI++;
                  //  LGraphTest.f_Refresh();

                  //  lbl_send_count.Text = "采样计数: " + sendCount++.ToString();
                };
                Invoke(action, i);
                i++;

                //  }
                Thread.Sleep(200);
                //    }   
            }
        }
        #endregion

        private void Btn_start_sample_Click(object sender, EventArgs e)   //   Button1_Click
        {
            btn_start_sample.Enabled = false;
            Thread.Sleep(100);

            if (checkBox_manul.Checked)
            {
                sendCount = 1;
                ToggleControls(true);
                btn_start_sample.Enabled = false;
                btn_stop_sample.Enabled = true;
                lbl_test_time.Visible = true;


                this.Focus();


                x1.Clear();
                y1.Clear();

                // x2.Clear();
                // y2.Clear();
                //  x3.Clear();
                //  y3.Clear();
                //  x4.Clear();
                //  y4.Clear();
                LGraphTest.f_ClearAllPix();
                LGraphTest.f_reXY();
                if (checkBox_scatter.Checked) { LGraphTest.f_LoadOnePix(ref x1, ref y1, Color.Red, 2, LineJoin.Round, LineCap.NoAnchor, LILEI.UI.LGraph.DrawStyle.dot); }   // scatter
                else { LGraphTest.f_LoadOnePix(ref x1, ref y1, Color.Red, 2); }    //curve

                //    LGraphTest.f_AddPix(ref x2, ref y2, Color.Blue, 3);
                //  LGraphTest.f_AddPix(ref x3, ref y3, Color.FromArgb(0, 128, 192), 2);
                //  LGraphTest.f_AddPix(ref x4, ref y4, Color.Yellow, 3);

                f_timerDrawStart(); //start sample timer



                lbl_status.Text = "SAMPLING[Period " + tb_sample_frequency.Text + "s]";

                //test timer label
                //开始计时
                test_timer.Start();
                TimeCount = 0;
            }
            else      //采样周期
            {

                //ToggleControls(true);
                lbl_test_time.Visible = false;

                //list add serial data 

                this.Focus();

                tb_sample_frequency.Text = "";
                //  tb_sample_frequency.Enabled = false;


                // x1.Clear();
                // y1.Clear();
                // LGraphTest.f_ClearAllPix();
                LGraphTest.f_reXY();
                if (checkBox_scatter.Checked) { LGraphTest.f_LoadOnePix(ref x1, ref y1, Color.Red, 2, LineJoin.Round, LineCap.NoAnchor, LILEI.UI.LGraph.DrawStyle.dot); }   // scatter
                else
                {
                    LGraphTest.f_LoadOnePix(ref x1, ref y1, Color.Red, 2);
                }


                foh100_state();
                Thread.Sleep(500);
                foh100_onu();
                btn_start_sample.Enabled = true;
            }


            btn_clear_graph.Enabled = true;

        }

        private void BtnView_Click(object sender, EventArgs e)
        {

            try
            {
                string LogPath = System.Environment.CurrentDirectory + "//fohlog.txt";
                System.Diagnostics.Process.Start(LogPath);
            }
            catch
            {
                MessageBox.Show("未找到 fohlog.txt");
            }
        }


        //comboBox_devices
        private void init_comboBox_devices() {
          
            string item_1 = "FOH-100";
            string item_2 = "PMT-300";
            string item_3 = "FHP2A04";
            this.comboBox_devices.Items.Add(item_1);
           
            this.comboBox_devices.Items.Add(item_2);
            
            this.comboBox_devices.Items.Add(item_3);
        }
    }
}


