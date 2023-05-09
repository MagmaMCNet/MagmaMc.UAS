namespace MagmaMc.UAS
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.betterPanel1 = new MagmaMc.BetterForms.BetterPanel();
            this.UD_Email = new System.Windows.Forms.Label();
            this.UD_Icon = new MagmaMc.BetterForms.RoundedPictureBox();
            this.LoginButton = new MagmaMc.BetterForms.BetterButton();
            this.Username_Input = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedPictureBox1 = new MagmaMc.BetterForms.RoundedPictureBox();
            this.ConnectionGIF = new MagmaMc.BetterForms.GIFPlayer();
            this.ConnectionHandler = new System.Windows.Forms.Timer(this.components);
            this.LoadingGIF = new MagmaMc.BetterForms.GIFPlayer();
            this.Password_Input = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.roundedPictureBox2 = new MagmaMc.BetterForms.RoundedPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createacccount_Link = new System.Windows.Forms.LinkLabel();
            this.Login_Progress = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.betterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UD_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionGIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingGIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Magma\'s Universal Accounts";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // betterPanel1
            // 
            this.betterPanel1.BorderColor = System.Drawing.Color.White;
            this.betterPanel1.BorderCurve = 15F;
            this.betterPanel1.BorderSize = 4F;
            this.betterPanel1.Controls.Add(this.UD_Email);
            this.betterPanel1.Controls.Add(this.UD_Icon);
            this.betterPanel1.Location = new System.Drawing.Point(3, 3);
            this.betterPanel1.Name = "betterPanel1";
            this.betterPanel1.Size = new System.Drawing.Size(300, 34);
            this.betterPanel1.TabIndex = 2;
            this.betterPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.betterPanel1_Paint);
            // 
            // UD_Email
            // 
            this.UD_Email.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UD_Email.ForeColor = System.Drawing.Color.White;
            this.UD_Email.Location = new System.Drawing.Point(49, 6);
            this.UD_Email.Name = "UD_Email";
            this.UD_Email.Size = new System.Drawing.Size(221, 22);
            this.UD_Email.TabIndex = 1;
            this.UD_Email.Text = "t";
            this.UD_Email.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // UD_Icon
            // 
            this.UD_Icon.BackColor = System.Drawing.Color.Transparent;
            this.UD_Icon.Location = new System.Drawing.Point(14, 2);
            this.UD_Icon.Name = "UD_Icon";
            this.UD_Icon.Size = new System.Drawing.Size(30, 30);
            this.UD_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UD_Icon.TabIndex = 0;
            this.UD_Icon.TabStop = false;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.LoginButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.LoginButton.BorderColor = System.Drawing.Color.White;
            this.LoginButton.BorderRadius = 18;
            this.LoginButton.BorderSize = 4;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(73, 317);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(160, 50);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextColor = System.Drawing.Color.White;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Value = null;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Username_Input
            // 
            this.Username_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.Username_Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_Input.ForeColor = System.Drawing.Color.White;
            this.Username_Input.Location = new System.Drawing.Point(62, 92);
            this.Username_Input.MaxLength = 30;
            this.Username_Input.Name = "Username_Input";
            this.Username_Input.Size = new System.Drawing.Size(198, 19);
            this.Username_Input.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(62, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 2);
            this.panel1.TabIndex = 5;
            // 
            // roundedPictureBox1
            // 
            this.roundedPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.roundedPictureBox1.Image = global::MagmaMc.UAS.Resources.usericon;
            this.roundedPictureBox1.Location = new System.Drawing.Point(31, 89);
            this.roundedPictureBox1.Name = "roundedPictureBox1";
            this.roundedPictureBox1.Size = new System.Drawing.Size(28, 28);
            this.roundedPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roundedPictureBox1.TabIndex = 1;
            this.roundedPictureBox1.TabStop = false;
            // 
            // ConnectionGIF
            // 
            this.ConnectionGIF.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionGIF.Image = global::MagmaMc.UAS.Resources.Connection;
            this.ConnectionGIF.Location = new System.Drawing.Point(12, 316);
            this.ConnectionGIF.Name = "ConnectionGIF";
            this.ConnectionGIF.Size = new System.Drawing.Size(55, 51);
            this.ConnectionGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ConnectionGIF.TabIndex = 0;
            this.ConnectionGIF.TabStop = false;
            // 
            // ConnectionHandler
            // 
            this.ConnectionHandler.Enabled = true;
            this.ConnectionHandler.Tick += new System.EventHandler(this.Connection_Update);
            // 
            // LoadingGIF
            // 
            this.LoadingGIF.BackColor = System.Drawing.Color.Transparent;
            this.LoadingGIF.Image = global::MagmaMc.UAS.Resources.LoadingRing;
            this.LoadingGIF.Location = new System.Drawing.Point(239, 317);
            this.LoadingGIF.Name = "LoadingGIF";
            this.LoadingGIF.Size = new System.Drawing.Size(55, 51);
            this.LoadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingGIF.TabIndex = 6;
            this.LoadingGIF.TabStop = false;
            // 
            // Password_Input
            // 
            this.Password_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(21)))));
            this.Password_Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Input.ForeColor = System.Drawing.Color.White;
            this.Password_Input.Location = new System.Drawing.Point(62, 148);
            this.Password_Input.MaxLength = 30;
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.Size = new System.Drawing.Size(198, 19);
            this.Password_Input.TabIndex = 7;
            this.Password_Input.UseSystemPasswordChar = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(62, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 2);
            this.panel2.TabIndex = 8;
            // 
            // roundedPictureBox2
            // 
            this.roundedPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.roundedPictureBox2.Image = global::MagmaMc.UAS.Resources.passicon;
            this.roundedPictureBox2.Location = new System.Drawing.Point(31, 147);
            this.roundedPictureBox2.Name = "roundedPictureBox2";
            this.roundedPictureBox2.Size = new System.Drawing.Size(28, 28);
            this.roundedPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roundedPictureBox2.TabIndex = 9;
            this.roundedPictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 46);
            this.label2.TabIndex = 10;
            this.label2.Text = "If you currently do not have a\r\nmagma\'s universal account create one here: ";
            // 
            // createacccount_Link
            // 
            this.createacccount_Link.Location = new System.Drawing.Point(90, 218);
            this.createacccount_Link.Name = "createacccount_Link";
            this.createacccount_Link.Size = new System.Drawing.Size(183, 14);
            this.createacccount_Link.TabIndex = 11;
            this.createacccount_Link.TabStop = true;
            this.createacccount_Link.Text = "Account.php";
            this.createacccount_Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateAcccount_Link_LinkClicked);
            // 
            // Login_Progress
            // 
            this.Login_Progress.Location = new System.Drawing.Point(-10, 371);
            this.Login_Progress.Minimum = 2;
            this.Login_Progress.Name = "Login_Progress";
            this.Login_Progress.Size = new System.Drawing.Size(327, 14);
            this.Login_Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Login_Progress.TabIndex = 12;
            this.Login_Progress.Value = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(20)))));
            this.panel3.Location = new System.Drawing.Point(1, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 3);
            this.panel3.TabIndex = 13;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(306, 380);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Login_Progress);
            this.Controls.Add(this.createacccount_Link);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roundedPictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Password_Input);
            this.Controls.Add(this.LoadingGIF);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roundedPictureBox1);
            this.Controls.Add(this.Username_Input);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.betterPanel1);
            this.Controls.Add(this.ConnectionGIF);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.RightToLeftLayout = true;
            this.Text = "UserForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.betterPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UD_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionGIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingGIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BetterForms.GIFPlayer ConnectionGIF;
        private BetterForms.BetterPanel betterPanel1;
        private BetterForms.BetterButton LoginButton;
        private BetterForms.RoundedPictureBox UD_Icon;
        private System.Windows.Forms.TextBox Username_Input;
        private BetterForms.RoundedPictureBox roundedPictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer ConnectionHandler;
        private BetterForms.GIFPlayer LoadingGIF;
        private System.Windows.Forms.TextBox Password_Input;
        private System.Windows.Forms.Panel panel2;
        private BetterForms.RoundedPictureBox roundedPictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel createacccount_Link;
        private System.Windows.Forms.Label UD_Email;
        private System.Windows.Forms.ProgressBar Login_Progress;
        private System.Windows.Forms.Panel panel3;
    }
}