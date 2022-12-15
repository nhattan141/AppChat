namespace client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PORT = new System.Windows.Forms.TextBox();
            this.IP = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.KQ = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.receiver = new System.Windows.Forms.TextBox();
            this.Logout = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.CreateGroup = new System.Windows.Forms.Button();
            this.Members = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GRP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.sendfile = new System.Windows.Forms.Button();
            this.namepath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(36)))), ((int)(((byte)(206)))));
            this.Connect.Location = new System.Drawing.Point(39, 175);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(111, 65);
            this.Connect.TabIndex = 7;
            this.Connect.Text = "LOGIN";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server IP";
            // 
            // PORT
            // 
            this.PORT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.PORT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.PORT.Location = new System.Drawing.Point(122, 90);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(213, 31);
            this.PORT.TabIndex = 3;
            this.PORT.Text = "2008";
            // 
            // IP
            // 
            this.IP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.IP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.IP.Location = new System.Drawing.Point(122, 41);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(213, 31);
            this.IP.TabIndex = 4;
            this.IP.Text = "192.168.213.253";
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.message.Location = new System.Drawing.Point(394, 577);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(473, 60);
            this.message.TabIndex = 4;
            this.message.Text = "MESSAGE";
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.Send.ForeColor = System.Drawing.Color.White;
            this.Send.Location = new System.Drawing.Point(902, 577);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(124, 60);
            this.Send.TabIndex = 8;
            this.Send.Text = "SEND";
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // KQ
            // 
            this.KQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.KQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.KQ.Location = new System.Drawing.Point(394, 64);
            this.KQ.Multiline = true;
            this.KQ.Name = "KQ";
            this.KQ.Size = new System.Drawing.Size(632, 399);
            this.KQ.TabIndex = 9;
            // 
            // UserName
            // 
            this.UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.UserName.Location = new System.Drawing.Point(122, 53);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(213, 31);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "A";
            // 
            // Pass
            // 
            this.Pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.Pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.Pass.Location = new System.Drawing.Point(122, 103);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(213, 31);
            this.Pass.TabIndex = 3;
            this.Pass.Text = "123";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pass";
            // 
            // receiver
            // 
            this.receiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.receiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.receiver.Location = new System.Drawing.Point(593, 15);
            this.receiver.Name = "receiver";
            this.receiver.Size = new System.Drawing.Size(274, 31);
            this.receiver.TabIndex = 3;
            this.receiver.Text = "B";
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(93)))));
            this.Logout.Enabled = false;
            this.Logout.ForeColor = System.Drawing.Color.White;
            this.Logout.Location = new System.Drawing.Point(12, 577);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(357, 60);
            this.Logout.TabIndex = 10;
            this.Logout.Text = "LOGOUT";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Register
            // 
            this.Register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.Register.Location = new System.Drawing.Point(180, 175);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(111, 65);
            this.Register.TabIndex = 11;
            this.Register.Text = "REGISTER";
            this.Register.UseVisualStyleBackColor = false;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // CreateGroup
            // 
            this.CreateGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.CreateGroup.Location = new System.Drawing.Point(30, 135);
            this.CreateGroup.Name = "CreateGroup";
            this.CreateGroup.Size = new System.Drawing.Size(216, 57);
            this.CreateGroup.TabIndex = 12;
            this.CreateGroup.Text = "CREATE";
            this.CreateGroup.UseVisualStyleBackColor = false;
            this.CreateGroup.Click += new System.EventHandler(this.CreateGroup_Click);
            // 
            // Members
            // 
            this.Members.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.Members.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.Members.Location = new System.Drawing.Point(123, 67);
            this.Members.Name = "Members";
            this.Members.Size = new System.Drawing.Size(123, 31);
            this.Members.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Group";
            // 
            // GRP
            // 
            this.GRP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.GRP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.GRP.Location = new System.Drawing.Point(123, 78);
            this.GRP.Name = "GRP";
            this.GRP.Size = new System.Drawing.Size(123, 31);
            this.GRP.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Members";
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.Add.Location = new System.Drawing.Point(32, 131);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(214, 58);
            this.Add.TabIndex = 13;
            this.Add.Text = "ADD";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // sendfile
            // 
            this.sendfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(48)))), ((int)(((byte)(90)))));
            this.sendfile.ForeColor = System.Drawing.Color.White;
            this.sendfile.Location = new System.Drawing.Point(902, 491);
            this.sendfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendfile.Name = "sendfile";
            this.sendfile.Size = new System.Drawing.Size(124, 58);
            this.sendfile.TabIndex = 14;
            this.sendfile.Text = "FILE";
            this.sendfile.UseVisualStyleBackColor = false;
            this.sendfile.Click += new System.EventHandler(this.sendfile_Click);
            // 
            // namepath
            // 
            this.namepath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.namepath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.namepath.Location = new System.Drawing.Point(452, 491);
            this.namepath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.namepath.Multiline = true;
            this.namepath.Name = "namepath";
            this.namepath.Size = new System.Drawing.Size(415, 58);
            this.namepath.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(394, 507);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Path:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.groupBox1.Controls.Add(this.UserName);
            this.groupBox1.Controls.Add(this.Pass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Controls.Add(this.Register);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 275);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOGIN";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.groupBox2.Controls.Add(this.IP);
            this.groupBox2.Controls.Add(this.PORT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 150);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IP ADDRESS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(542, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "To:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.GRP);
            this.groupBox3.Controls.Add(this.CreateGroup);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(1052, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 245);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NEW GROUP";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.groupBox4.Controls.Add(this.Members);
            this.groupBox4.Controls.Add(this.Add);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(1052, 360);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 222);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ADD MEMBER";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1328, 654);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.namepath);
            this.Controls.Add(this.sendfile);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.KQ);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.receiver);
            this.Controls.Add(this.message);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Connect;
        private Label label2;
        private Label label1;
        private TextBox PORT;
        private TextBox IP;
        private TextBox message;
        private Button Send;
        private TextBox KQ;
        private TextBox UserName;
        private TextBox Pass;
        private Label label3;
        private Label label4;
        private TextBox receiver;
        private Button Logout;
        private Button Register;
        private Button CreateGroup;
        private TextBox Members;
        private Label label5;
        private TextBox GRP;
        private Label label6;
        private Button Add;
        private Button sendfile;
        private TextBox namepath;
        private Label label7;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label8;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
    }
}