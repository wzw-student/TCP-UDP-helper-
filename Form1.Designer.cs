namespace Communication
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_send_options = new System.Windows.Forms.Panel();
            this.button_send = new System.Windows.Forms.Button();
            this.panel_receive = new System.Windows.Forms.Panel();
            this.textBox_receive = new System.Windows.Forms.TextBox();
            this.panel_send = new System.Windows.Forms.Panel();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.panel_receive_options = new System.Windows.Forms.Panel();
            this.button_MessageClear = new System.Windows.Forms.Button();
            this.button_MessageSave = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.comboBox_PortNum = new System.Windows.Forms.ComboBox();
            this.comboBox_IPNum = new System.Windows.Forms.ComboBox();
            this.comboBox_select_func = new System.Windows.Forms.ComboBox();
            this.label_portNum = new System.Windows.Forms.Label();
            this.label_ipNum = new System.Windows.Forms.Label();
            this.label_slect_func = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_send_options.SuspendLayout();
            this.panel_receive.SuspendLayout();
            this.panel_send.SuspendLayout();
            this.panel_receive_options.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_send_options
            // 
            this.panel_send_options.BackColor = System.Drawing.Color.Beige;
            this.panel_send_options.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_send_options.Controls.Add(this.button_send);
            this.panel_send_options.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_send_options.Location = new System.Drawing.Point(12, 502);
            this.panel_send_options.Name = "panel_send_options";
            this.panel_send_options.Size = new System.Drawing.Size(336, 248);
            this.panel_send_options.TabIndex = 1;
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(76, 164);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(206, 52);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.Button_send_Click);
            // 
            // panel_receive
            // 
            this.panel_receive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_receive.BackColor = System.Drawing.Color.Linen;
            this.panel_receive.Controls.Add(this.textBox_receive);
            this.panel_receive.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_receive.Location = new System.Drawing.Point(357, 38);
            this.panel_receive.Name = "panel_receive";
            this.panel_receive.Size = new System.Drawing.Size(619, 457);
            this.panel_receive.TabIndex = 2;
            // 
            // textBox_receive
            // 
            this.textBox_receive.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_receive.Location = new System.Drawing.Point(0, 1);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_receive.Size = new System.Drawing.Size(619, 457);
            this.textBox_receive.TabIndex = 0;
            // 
            // panel_send
            // 
            this.panel_send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_send.BackColor = System.Drawing.Color.Beige;
            this.panel_send.Controls.Add(this.textBox_send);
            this.panel_send.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_send.Location = new System.Drawing.Point(354, 502);
            this.panel_send.Name = "panel_send";
            this.panel_send.Size = new System.Drawing.Size(622, 248);
            this.panel_send.TabIndex = 3;
            // 
            // textBox_send
            // 
            this.textBox_send.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_send.Location = new System.Drawing.Point(0, 0);
            this.textBox_send.Multiline = true;
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_send.Size = new System.Drawing.Size(619, 248);
            this.textBox_send.TabIndex = 0;
            // 
            // panel_receive_options
            // 
            this.panel_receive_options.BackColor = System.Drawing.Color.Linen;
            this.panel_receive_options.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_receive_options.Controls.Add(this.button_MessageClear);
            this.panel_receive_options.Controls.Add(this.button_MessageSave);
            this.panel_receive_options.Controls.Add(this.button_connect);
            this.panel_receive_options.Controls.Add(this.comboBox_PortNum);
            this.panel_receive_options.Controls.Add(this.comboBox_IPNum);
            this.panel_receive_options.Controls.Add(this.comboBox_select_func);
            this.panel_receive_options.Controls.Add(this.label_portNum);
            this.panel_receive_options.Controls.Add(this.label_ipNum);
            this.panel_receive_options.Controls.Add(this.label_slect_func);
            this.panel_receive_options.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_receive_options.Location = new System.Drawing.Point(12, 39);
            this.panel_receive_options.Name = "panel_receive_options";
            this.panel_receive_options.Size = new System.Drawing.Size(334, 457);
            this.panel_receive_options.TabIndex = 0;
            // 
            // button_MessageClear
            // 
            this.button_MessageClear.Location = new System.Drawing.Point(179, 304);
            this.button_MessageClear.Name = "button_MessageClear";
            this.button_MessageClear.Size = new System.Drawing.Size(148, 53);
            this.button_MessageClear.TabIndex = 6;
            this.button_MessageClear.Text = "清空消息";
            this.button_MessageClear.UseVisualStyleBackColor = true;
            this.button_MessageClear.Click += new System.EventHandler(this.Button_MessageClear_Click);
            // 
            // button_MessageSave
            // 
            this.button_MessageSave.Location = new System.Drawing.Point(7, 304);
            this.button_MessageSave.Name = "button_MessageSave";
            this.button_MessageSave.Size = new System.Drawing.Size(143, 53);
            this.button_MessageSave.TabIndex = 6;
            this.button_MessageSave.Text = "保存消息";
            this.button_MessageSave.UseVisualStyleBackColor = true;
            this.button_MessageSave.Click += new System.EventHandler(this.Button_MessageSave_Click);
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.YellowGreen;
            this.button_connect.Location = new System.Drawing.Point(56, 181);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(206, 50);
            this.button_connect.TabIndex = 5;
            this.button_connect.Text = "连接";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.Button_connect_Click);
            // 
            // comboBox_PortNum
            // 
            this.comboBox_PortNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_PortNum.FormattingEnabled = true;
            this.comboBox_PortNum.Items.AddRange(new object[] {
            "8080"});
            this.comboBox_PortNum.Location = new System.Drawing.Point(107, 115);
            this.comboBox_PortNum.Name = "comboBox_PortNum";
            this.comboBox_PortNum.Size = new System.Drawing.Size(220, 32);
            this.comboBox_PortNum.TabIndex = 4;
            this.comboBox_PortNum.Text = "8080";
            // 
            // comboBox_IPNum
            // 
            this.comboBox_IPNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_IPNum.FormattingEnabled = true;
            this.comboBox_IPNum.Items.AddRange(new object[] {
            "127.0.0.1"});
            this.comboBox_IPNum.Location = new System.Drawing.Point(107, 61);
            this.comboBox_IPNum.Name = "comboBox_IPNum";
            this.comboBox_IPNum.Size = new System.Drawing.Size(220, 32);
            this.comboBox_IPNum.TabIndex = 4;
            // 
            // comboBox_select_func
            // 
            this.comboBox_select_func.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_select_func.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_select_func.FormattingEnabled = true;
            this.comboBox_select_func.Items.AddRange(new object[] {
            "TCP客户端",
            "TCP服务端",
            "UDP服务"});
            this.comboBox_select_func.Location = new System.Drawing.Point(107, 9);
            this.comboBox_select_func.Name = "comboBox_select_func";
            this.comboBox_select_func.Size = new System.Drawing.Size(220, 32);
            this.comboBox_select_func.TabIndex = 4;
            // 
            // label_portNum
            // 
            this.label_portNum.AutoSize = true;
            this.label_portNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_portNum.Location = new System.Drawing.Point(19, 117);
            this.label_portNum.Name = "label_portNum";
            this.label_portNum.Size = new System.Drawing.Size(82, 24);
            this.label_portNum.TabIndex = 3;
            this.label_portNum.Text = "端口号";
            // 
            // label_ipNum
            // 
            this.label_ipNum.AutoSize = true;
            this.label_ipNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ipNum.Location = new System.Drawing.Point(19, 66);
            this.label_ipNum.Name = "label_ipNum";
            this.label_ipNum.Size = new System.Drawing.Size(82, 24);
            this.label_ipNum.TabIndex = 3;
            this.label_ipNum.Text = "IP地址";
            // 
            // label_slect_func
            // 
            this.label_slect_func.AutoSize = true;
            this.label_slect_func.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_slect_func.Location = new System.Drawing.Point(3, 14);
            this.label_slect_func.Name = "label_slect_func";
            this.label_slect_func.Size = new System.Drawing.Size(106, 24);
            this.label_slect_func.TabIndex = 3;
            this.label_slect_func.Text = "协议类型";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(988, 32);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 788);
            this.Controls.Add(this.panel_send);
            this.Controls.Add(this.panel_receive);
            this.Controls.Add(this.panel_send_options);
            this.Controls.Add(this.panel_receive_options);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "网络助手";
            this.panel_send_options.ResumeLayout(false);
            this.panel_receive.ResumeLayout(false);
            this.panel_receive.PerformLayout();
            this.panel_send.ResumeLayout(false);
            this.panel_send.PerformLayout();
            this.panel_receive_options.ResumeLayout(false);
            this.panel_receive_options.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_send_options;
        private System.Windows.Forms.Panel panel_receive;
        private System.Windows.Forms.Panel panel_send;
        private System.Windows.Forms.Panel panel_receive_options;
        private System.Windows.Forms.Label label_portNum;
        private System.Windows.Forms.Label label_ipNum;
        private System.Windows.Forms.Label label_slect_func;
        private System.Windows.Forms.ComboBox comboBox_select_func;
        private System.Windows.Forms.ComboBox comboBox_PortNum;
        private System.Windows.Forms.ComboBox comboBox_IPNum;
        private System.Windows.Forms.TextBox textBox_receive;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_MessageClear;
        private System.Windows.Forms.Button button_MessageSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

