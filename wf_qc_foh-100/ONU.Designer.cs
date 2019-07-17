namespace wf_qc_foh_100
{
    partial class ONU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gradientPanel2 = new System.Windows.Forms.Panel();
            this.ReceivedTextBox = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.tbxView = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lbl_fan_speed = new System.Windows.Forms.Label();
            this.lbl_battary_volatge = new System.Windows.Forms.Label();
            this.lbl_mcu_temperate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortOpen = new System.Windows.Forms.Button();
            this.PortSearch = new System.Windows.Forms.Button();
            this.PortcomboBox = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gradientPanel1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_sample_period = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_auto = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_manual = new System.Windows.Forms.CheckBox();
            this.tb_sample_frequency = new System.Windows.Forms.TextBox();
            this.btn_clear_graph = new System.Windows.Forms.Button();
            this.btn_stop_sample = new System.Windows.Forms.Button();
            this.btn_start_sample = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.gradientPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradientPanel2.Controls.Add(this.ReceivedTextBox);
            this.gradientPanel2.Controls.Add(this.panel5);
            this.gradientPanel2.Controls.Add(this.pnlHeader);
            this.gradientPanel2.Location = new System.Drawing.Point(526, 0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(226, 449);
            this.gradientPanel2.TabIndex = 4;
            // 
            // ReceivedTextBox
            // 
            this.ReceivedTextBox.AutoWordSelection = true;
            this.ReceivedTextBox.EnableAutoDragDrop = true;
            this.ReceivedTextBox.Location = new System.Drawing.Point(4, 270);
            this.ReceivedTextBox.Name = "ReceivedTextBox";
            this.ReceivedTextBox.Size = new System.Drawing.Size(214, 26);
            this.ReceivedTextBox.TabIndex = 0;
            this.ReceivedTextBox.Text = "";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTime);
            this.panel5.Controls.Add(this.tbxView);
            this.panel5.Controls.Add(this.btnView);
            this.panel5.Location = new System.Drawing.Point(3, 299);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(214, 93);
            this.panel5.TabIndex = 896;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(22, 72);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 12);
            this.lblTime.TabIndex = 897;
            this.lblTime.Text = "Time";
            this.lblTime.Click += new System.EventHandler(this.LblTime_Click);
            // 
            // tbxView
            // 
            this.tbxView.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tbxView.Location = new System.Drawing.Point(5, 3);
            this.tbxView.Name = "tbxView";
            this.tbxView.ReadOnly = true;
            this.tbxView.Size = new System.Drawing.Size(209, 21);
            this.tbxView.TabIndex = 893;
            this.tbxView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(170, 30);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(44, 23);
            this.btnView.TabIndex = 894;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lbl_fan_speed);
            this.pnlHeader.Controls.Add(this.lbl_battary_volatge);
            this.pnlHeader.Controls.Add(this.lbl_mcu_temperate);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.PortOpen);
            this.pnlHeader.Controls.Add(this.PortSearch);
            this.pnlHeader.Controls.Add(this.PortcomboBox);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Location = new System.Drawing.Point(4, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(214, 233);
            this.pnlHeader.TabIndex = 891;
            // 
            // lbl_fan_speed
            // 
            this.lbl_fan_speed.AutoSize = true;
            this.lbl_fan_speed.Location = new System.Drawing.Point(8, 147);
            this.lbl_fan_speed.Name = "lbl_fan_speed";
            this.lbl_fan_speed.Size = new System.Drawing.Size(65, 12);
            this.lbl_fan_speed.TabIndex = 906;
            this.lbl_fan_speed.Text = "fan_speed:";
            // 
            // lbl_battary_volatge
            // 
            this.lbl_battary_volatge.AutoSize = true;
            this.lbl_battary_volatge.Location = new System.Drawing.Point(8, 121);
            this.lbl_battary_volatge.Name = "lbl_battary_volatge";
            this.lbl_battary_volatge.Size = new System.Drawing.Size(101, 12);
            this.lbl_battary_volatge.TabIndex = 905;
            this.lbl_battary_volatge.Text = "battary_volatge:";
            // 
            // lbl_mcu_temperate
            // 
            this.lbl_mcu_temperate.AutoSize = true;
            this.lbl_mcu_temperate.Location = new System.Drawing.Point(8, 97);
            this.lbl_mcu_temperate.Name = "lbl_mcu_temperate";
            this.lbl_mcu_temperate.Size = new System.Drawing.Size(89, 12);
            this.lbl_mcu_temperate.TabIndex = 903;
            this.lbl_mcu_temperate.Text = "mcu_temperate:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 898;
            this.label1.Text = "Send Count:";
            // 
            // PortOpen
            // 
            this.PortOpen.Location = new System.Drawing.Point(152, 9);
            this.PortOpen.Name = "PortOpen";
            this.PortOpen.Size = new System.Drawing.Size(55, 23);
            this.PortOpen.TabIndex = 895;
            this.PortOpen.Text = "Open";
            this.PortOpen.UseVisualStyleBackColor = true;
            this.PortOpen.Click += new System.EventHandler(this.PortOpen_Click);
            // 
            // PortSearch
            // 
            this.PortSearch.Location = new System.Drawing.Point(91, 10);
            this.PortSearch.Name = "PortSearch";
            this.PortSearch.Size = new System.Drawing.Size(55, 23);
            this.PortSearch.TabIndex = 721;
            this.PortSearch.Text = "Search";
            this.PortSearch.UseVisualStyleBackColor = true;
            this.PortSearch.Click += new System.EventHandler(this.PortSearch_Click);
            // 
            // PortcomboBox
            // 
            this.PortcomboBox.FormattingEnabled = true;
            this.PortcomboBox.Location = new System.Drawing.Point(10, 12);
            this.PortcomboBox.Name = "PortcomboBox";
            this.PortcomboBox.Size = new System.Drawing.Size(75, 20);
            this.PortcomboBox.TabIndex = 720;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(7, 198);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 25);
            this.lblStatus.TabIndex = 719;
            this.lblStatus.Text = "label3";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.AutoSize = true;
            this.gradientPanel1.BackColor = System.Drawing.Color.White;
            this.gradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradientPanel1.Controls.Add(this.panel2);
            this.gradientPanel1.Controls.Add(this.panel1);
            this.gradientPanel1.Location = new System.Drawing.Point(-2, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(522, 449);
            this.gradientPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 189);
            this.panel1.TabIndex = 903;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(8, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 12);
            this.label7.TabIndex = 911;
            this.label7.Text = "串口通讯状态:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 906;
            this.label2.Text = "fan_speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 905;
            this.label3.Text = "battary_volatge:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 903;
            this.label4.Text = "mcu_temperate:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 898;
            this.label5.Text = "Send Count:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 895;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 23);
            this.button2.TabIndex = 721;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 20);
            this.comboBox1.TabIndex = 720;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(7, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 25);
            this.label6.TabIndex = 719;
            this.label6.Text = "label3";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tb_sample_period);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.checkBox_auto);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.checkBox_manual);
            this.panel2.Controls.Add(this.tb_sample_frequency);
            this.panel2.Controls.Add(this.btn_clear_graph);
            this.panel2.Controls.Add(this.btn_stop_sample);
            this.panel2.Controls.Add(this.btn_start_sample);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(303, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 199);
            this.panel2.TabIndex = 905;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 922;
            this.label8.Text = "采样时间";
            // 
            // tb_sample_period
            // 
            this.tb_sample_period.Location = new System.Drawing.Point(73, 106);
            this.tb_sample_period.Name = "tb_sample_period";
            this.tb_sample_period.Size = new System.Drawing.Size(48, 21);
            this.tb_sample_period.TabIndex = 921;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(8, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 920;
            this.label9.Text = "采集方式:";
            // 
            // checkBox_auto
            // 
            this.checkBox_auto.AutoSize = true;
            this.checkBox_auto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_auto.Location = new System.Drawing.Point(73, 138);
            this.checkBox_auto.Name = "checkBox_auto";
            this.checkBox_auto.Size = new System.Drawing.Size(48, 16);
            this.checkBox_auto.TabIndex = 919;
            this.checkBox_auto.Text = "自动";
            this.checkBox_auto.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 917;
            this.label10.Text = "采样频率";
            // 
            // checkBox_manual
            // 
            this.checkBox_manual.AutoSize = true;
            this.checkBox_manual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_manual.Location = new System.Drawing.Point(127, 138);
            this.checkBox_manual.Name = "checkBox_manual";
            this.checkBox_manual.Size = new System.Drawing.Size(48, 16);
            this.checkBox_manual.TabIndex = 918;
            this.checkBox_manual.Text = "手动";
            this.checkBox_manual.UseVisualStyleBackColor = true;
            // 
            // tb_sample_frequency
            // 
            this.tb_sample_frequency.Location = new System.Drawing.Point(73, 80);
            this.tb_sample_frequency.Name = "tb_sample_frequency";
            this.tb_sample_frequency.Size = new System.Drawing.Size(48, 21);
            this.tb_sample_frequency.TabIndex = 915;
            // 
            // btn_clear_graph
            // 
            this.btn_clear_graph.Location = new System.Drawing.Point(10, 164);
            this.btn_clear_graph.Name = "btn_clear_graph";
            this.btn_clear_graph.Size = new System.Drawing.Size(43, 23);
            this.btn_clear_graph.TabIndex = 913;
            this.btn_clear_graph.Text = "清空";
            this.btn_clear_graph.UseVisualStyleBackColor = true;
            // 
            // btn_stop_sample
            // 
            this.btn_stop_sample.Location = new System.Drawing.Point(75, 164);
            this.btn_stop_sample.Name = "btn_stop_sample";
            this.btn_stop_sample.Size = new System.Drawing.Size(46, 23);
            this.btn_stop_sample.TabIndex = 912;
            this.btn_stop_sample.Text = "停止";
            this.btn_stop_sample.UseVisualStyleBackColor = true;
            // 
            // btn_start_sample
            // 
            this.btn_start_sample.Location = new System.Drawing.Point(145, 164);
            this.btn_start_sample.Name = "btn_start_sample";
            this.btn_start_sample.Size = new System.Drawing.Size(45, 23);
            this.btn_start_sample.TabIndex = 911;
            this.btn_start_sample.Text = "采样";
            this.btn_start_sample.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(6, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 12);
            this.label11.TabIndex = 910;
            this.label11.Text = "数据显示设置:";
            // 
            // ONU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 470);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "ONU";
            this.Text = "ONU";
            this.Load += new System.EventHandler(this.ONU_Load);
            this.gradientPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.gradientPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gradientPanel2;
        private System.Windows.Forms.Panel gradientPanel1;
        private System.Windows.Forms.RichTextBox ReceivedTextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox tbxView;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lbl_fan_speed;
        private System.Windows.Forms.Label lbl_battary_volatge;
        private System.Windows.Forms.Label lbl_mcu_temperate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PortOpen;
        private System.Windows.Forms.Button PortSearch;
        private System.Windows.Forms.ComboBox PortcomboBox;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_sample_period;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_auto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_manual;
        private System.Windows.Forms.TextBox tb_sample_frequency;
        private System.Windows.Forms.Button btn_clear_graph;
        private System.Windows.Forms.Button btn_stop_sample;
        private System.Windows.Forms.Button btn_start_sample;
        private System.Windows.Forms.Label label11;
    }
}