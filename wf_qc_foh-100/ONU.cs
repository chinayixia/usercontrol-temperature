using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;


namespace wf_qc_foh_100
{
    public partial class ONU : Form
    {

        List<string> expressions = new List<string>();  //save config
        //采样数据
        public List<float> temperature_x1 = new List<float>();
        public List<float> temperature_y1 = new List<float>();

        //SERIAL
        public byte[] a = new byte[13];
        //  private SerialPort com = new SerialPort();
        public USB usb;
        private Thread thread;
        public ONU()
        {
            InitializeComponent();
            //SERIAL
            usb = new USB();
            Init();

            //GRAPH
            //f_saveReadFirst(false);
           // f_reStyle();
        }

        #region  serial
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

        private void PortSearch_Click(object sender, EventArgs e)
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
        private void PortOpen_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {

                lblStatus.Text = "The device is active";

                //SendCommand.Enabled = true;  //button sendcommand enable
                //btn_switchGEPON.Enabled = true;
                //btn_Power.Enabled = true;

                PortOpen.Text = "Close";
                String comName = PortcomboBox.SelectedItem.ToString();
                Boolean isOpenSuccess = usb.SetCom(PortcomboBox.SelectedItem.ToString());

                //Timer tick
                System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
                myTimer.Tick += new EventHandler(timer1_Tick);
                myTimer.Enabled = true;
                myTimer.Interval = 10000;
                myTimer.Start();

                //serial graph
                //graph_serial();


                if (isOpenSuccess)
                {
                    isOpen = true;
                }
                else
                {
                    isOpen = false;
                    PortOpen.Text = "Open";
                    lblStatus.Text = "Could not read any response";
                    myTimer.Stop();
                }
            }
            else
            {
                usb.CloseCom();
                PortOpen.Text = "Open";
                isOpen = false;


            }
        }
        Boolean isExit = false;

        private void SendCommand_Click()
        {
            state();
          //  Thread.Sleep(1000);
            //onu();
          //  Thread.Sleep(1000);
             
           
        }

        //PMT-300温度、电压读取：
        string pmt300_state = "system,state" + "\r\n";

        //FOH-100
        string foh100_state = "system state" + "\r\n";
        string foh100_onu = "sys onu";


        private void state()
        {
            if (isOpen)
            {
                try
                {
                    //usb.SendData(tb_send.Text);
                    usb.SendData(foh100_state);
                    thread = new Thread(new ThreadStart(GetData));
                    thread.Start();                   
                }
                catch
                {
                    MessageBox.Show("串口数据写入错误", "错误");
                    usb.CloseCom();
                }
            }
        }

        private void onu()
        {
            // if (isOpen)
            // {
            try
            {
                usb.SendData(foh100_onu);
                thread = new Thread(new ThreadStart(GetData));
                thread.Start();               
            }
            catch
            {
                MessageBox.Show("串口数据写入错误", "错误");
                usb.CloseCom();
            }
            // }
        }


        public void GetData()
        {
            String msg = "";

            Thread.Sleep(500);


            int i = 0;

            msg = usb.ReadData();


            if (msg.Contains("sys_power_flg")) // || msg.Contains( "onu_info.rx_lenth")
            {
                Action<int> action = (data) =>
                {
                    int start0 = msg.IndexOf("mcu_temperate");
                    int length0 = " = 36.71".Length;
                    String tmpValue0 = msg.Substring(start0 + 15, length0).Trim();

                    int start1 = msg.IndexOf("battary_volatge ");
                    int length1 = " = 4.30".Length;
                    String tmpValue1 = msg.Substring(start1 + 17, length1).Trim();

                    int start2 = msg.IndexOf("fan_speed_test");
                    int length2 = " = 0  ".Length;
                    String tmpValue2 = msg.Substring(start2 + 16, length2).Trim();

                   // ReceivedTextBox.Text += msg + "\r\n";


                    lbl_mcu_temperate.Text = "mcu_temperate:" + tmpValue0;
                    lbl_battary_volatge.Text = "battary_volatge:" + tmpValue1;
                    lbl_fan_speed.Text = "fan_speed:" + tmpValue2;


                    String responseoutput = String.Empty;
                    responseoutput = msg;
                    //save info log
                    StreamWriter file = new StreamWriter("usblog.txt", true);
                    file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + "        " + responseoutput);
                    file.Close();

                    //graph list
                    string amount = string.Empty;
                    if (!string.IsNullOrEmpty(tmpValue0) && (Regex.IsMatch(tmpValue0, @"^[1-9]\d*|0$"))) // || Regex.IsMatch(tmpValue0, @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$")
                    {
                        amount = Convert.ToDecimal(tmpValue0).ToString("F2");

                    }
                    else
                    {
                        amount = "0.00";
                    }


                    //string amount = string.Empty;
                    //amount = tmpValue0.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                    temperature_y1.Add(float.Parse(amount));
                    ReceivedTextBox.Text += amount + "\r\n";
                };
                Invoke(action, i);
                i++;

                //  }
                Thread.Sleep(1000);
                //    }
            }
            //else
            //{
            //    try
            //    {

            //        vertest_again();
            //    }
            //    catch {
            //        MessageBox.Show("123123");
            //    }

            //}
        }


        //public void getOnu()
        //{
        //    String msg = "";

        //    Thread.Sleep(500);


        //    int i = 0;

        //    msg = usb.ReadData();


        //    if (msg.Contains("onu_info.rx_lenth"))
        //    {
        //        Action<int> action = (data) =>
        //        {
        //            int start0 = msg.IndexOf("mcu_temperate");
        //            int length0 = " = 36.71".Length;
        //            String tmpValue0 = msg.Substring(start0 + 15, length0).Trim();

        //            int start1 = msg.IndexOf("battary_volatge ");
        //            int length1 = " = 4.30".Length;
        //            String tmpValue1 = msg.Substring(start1 + 17, length1).Trim();

        //            int start2 = msg.IndexOf("fan_speed_test");
        //            int length2 = " = 0  ".Length;
        //            String tmpValue2 = msg.Substring(start2 + 16, length2).Trim();

        //            ReceivedTextBox.Text += msg + "\r\n";


        //            lbl_mcu_temperate.Text = "mcu_temperate:" + tmpValue0;
        //            lbl_battary_volatge.Text = "battary_volatge:" + tmpValue1;
        //            lbl_fan_speed.Text = "fan_speed:" + tmpValue2;


        //            String responseoutput = String.Empty;
        //            responseoutput = msg;
        //            //save info log
        //            StreamWriter file = new StreamWriter("usblog.txt", true);
        //            file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + "        " + responseoutput);
        //            file.Close();


        //        };
        //        Invoke(action, i);
        //        i++;

        //        //  }
        //        Thread.Sleep(1000);
        //        //    }
        //    }
        //}


            #endregion

            private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                string LogPath = System.Environment.CurrentDirectory + "//usblog.txt";
                System.Diagnostics.Process.Start(LogPath);
            }
            catch
            {
                MessageBox.Show("未找到 usblog.txt");
            }
        }

        private void LblTime_Click(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString();
        }

        private void ONU_Load(object sender, EventArgs e)
        {
            //log path
            tbxView.Text = System.Environment.CurrentDirectory + "\\usblog.txt";


        }

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString();
            //Thread.Sleep(10000);
            if (isOpen)
            {
                try
                {
                    SendCommand_Click();


                    count++;
                }
                catch
                {
                    MessageBox.Show("请检查串口连接！");
                }
            }


            label1.Text = "Send Count:" + count.ToString();

        }


        //#region GRAPH

        //private Color[] m_colors;
        //private float m_fstyle;
        //private int[] m_istyle;
        ///// <summary>
        ///// 获取初始的波形显示控件的样式或设置为初始样式
        ///// </summary>
        ///// <param name="isRead">获取ture | 设置false</param>
        //private void f_saveReadFirst(bool isRead)
        //{
        //    if (!isRead)
        //    {
        //        m_colors = new Color[18];
        //        m_istyle = new int[2];
        //        m_istyle[0] = zGraphTest.m_titleSize;
        //        m_fstyle = zGraphTest.m_titlePosition;
        //        m_colors[0] = zGraphTest.m_titleColor;
        //        m_colors[1] = zGraphTest.m_titleBorderColor;
        //        m_colors[2] = zGraphTest.m_backColorL;
        //        m_colors[3] = zGraphTest.m_backColorH;
        //        m_colors[4] = zGraphTest.m_coordinateLineColor;
        //        m_colors[5] = zGraphTest.m_coordinateStringColor;
        //        m_colors[6] = zGraphTest.m_coordinateStringTitleColor;
        //        m_istyle[1] = zGraphTest.m_iLineShowColorAlpha;
        //        m_colors[7] = zGraphTest.m_iLineShowColor;
        //        m_colors[8] = zGraphTest.m_GraphBackColor;
        //        m_colors[9] = zGraphTest.m_ControlItemBackColor;
        //        m_colors[10] = zGraphTest.m_ControlButtonBackColor;
        //        m_colors[11] = zGraphTest.m_ControlButtonForeColorL;
        //        m_colors[12] = zGraphTest.m_ControlButtonForeColorH;
        //        m_colors[13] = zGraphTest.m_DirectionBackColor;
        //        m_colors[14] = zGraphTest.m_DirectionForeColor;
        //        m_colors[15] = zGraphTest.m_BigXYBackColor;
        //        m_colors[16] = zGraphTest.m_BigXYButtonBackColor;
        //        m_colors[17] = zGraphTest.m_BigXYButtonForeColor;
        //    }
        //    else
        //    {
        //        //样式
               

        //    }
        //}
        ///// <summary>
        ///// 获取波形显示控件基本属性和样式，并更新到该程序界面
        ///// </summary>
        ////private void f_reStyle()
        ////{
        ////    //基本属性
        ////    textBox标题.Text = zGraphTest.m_SyStitle.ToString();
        ////    textBoxX轴名称.Text = zGraphTest.m_SySnameX.ToString();
        ////    textBoxY轴名称.Text = zGraphTest.m_SySnameY.ToString();
        ////    //样式
        ////    textBox标题字体大小.Text = zGraphTest.m_titleSize.ToString();
        ////    textBox标题位置.Text = zGraphTest.m_titlePosition.ToString();
        ////    button标题颜色.BackColor = zGraphTest.m_titleColor;
        ////    button标题描边颜色.BackColor = zGraphTest.m_titleBorderColor;
        ////    button背景色渐进起始颜色.BackColor = zGraphTest.m_backColorL;
        ////    button背景色渐进终止颜色.BackColor = zGraphTest.m_backColorH;
        ////    button坐标线颜色.BackColor = zGraphTest.m_coordinateLineColor;
        ////    button坐标值颜色.BackColor = zGraphTest.m_coordinateStringColor;
        ////    button坐标标题颜色.BackColor = zGraphTest.m_coordinateStringTitleColor;
        ////    textBox网络线的透明度.Text = zGraphTest.m_iLineShowColorAlpha.ToString();
        ////    button网络线的颜色.BackColor = zGraphTest.m_iLineShowColor;
        ////    button波形显示区域背景色.BackColor = zGraphTest.m_GraphBackColor;
        ////    button工具栏背景色.BackColor = zGraphTest.m_ControlItemBackColor;
        ////    button工具栏按钮背景色.BackColor = zGraphTest.m_ControlButtonBackColor;
        ////    button工具栏按钮前景选中颜色.BackColor = zGraphTest.m_ControlButtonForeColorL;
        ////    button工具栏按钮前景未选中颜色.BackColor = zGraphTest.m_ControlButtonForeColorH;
        ////    button标签说明框背景颜色.BackColor = zGraphTest.m_DirectionBackColor;
        ////    button标签说明框文字颜色.BackColor = zGraphTest.m_DirectionForeColor;
        ////    button放大选取框背景颜色.BackColor = zGraphTest.m_BigXYBackColor;
        ////    button放大选取框按钮背景颜色.BackColor = zGraphTest.m_BigXYButtonBackColor;
        ////    button放大选取框按钮文字颜色.BackColor = zGraphTest.m_BigXYButtonForeColor;
        ////}

        //private void graph_serial()
        //{
        //    if (temperature_y1.Count > 0)
        //    {
        //        Thread.Sleep(2000);
        //        for (int i = 0; i < 10000; i++) { temperature_x1.Add(i); }
        //        zGraphTest.f_ClearAllPix();  //清空所有加载波形数据和显示
        //        zGraphTest.f_reXY();        //重新初始化坐标轴
        //        zGraphTest.f_LoadOnePix(ref temperature_x1, ref temperature_y1, Color.Red, 2);  //清空原有数据并加载一条波形数据，显示样式为曲线

        //        // f_timerDrawStart(); //开始TIMER
        //        zGraphTest.f_Refresh();

        //    }

        //}


        //private void f_timerDrawStart()
        //{
        //    timerDrawI = 0;
        //  //  timerDraw.Start();
        //}



        //private int timerDrawI = 0;
        //private void timerDraw_Tick(object sender, EventArgs e)
        //{
        //    ///TIME增加数据
        //    temperature_x1.Add(timerDrawI);
        //    temperature_y1.Add(timerDrawI % 100);
          
        //    timerDrawI++;
        //    zGraphTest.f_Refresh();
          
        //}
        //#endregion

    }
}
