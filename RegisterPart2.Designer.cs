namespace social_media
{
    partial class RegisterPart2
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
            btnRegister = new Button();
            btnClear = new Button();
            lblBackLogin = new Label();
            panel1 = new Panel();
            Bio = new RichTextBox();
            avatarpanel = new FlowLayoutPanel();
            lblAvatar = new Label();
            lblBio = new Label();
            avatar = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatar).BeginInit();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Navy;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Yu Gothic UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnRegister.ForeColor = Color.WhiteSmoke;
            btnRegister.Location = new Point(117, 517);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(252, 51);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.WhiteSmoke;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Yu Gothic UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnClear.ForeColor = Color.Navy;
            btnClear.Location = new Point(117, 581);
            btnClear.Margin = new Padding(3, 10, 3, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(252, 51);
            btnClear.TabIndex = 10;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblBackLogin
            // 
            lblBackLogin.AutoSize = true;
            lblBackLogin.Cursor = Cursors.Hand;
            lblBackLogin.FlatStyle = FlatStyle.Flat;
            lblBackLogin.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBackLogin.ForeColor = Color.Navy;
            lblBackLogin.Location = new Point(171, 635);
            lblBackLogin.Margin = new Padding(20, 0, 3, 0);
            lblBackLogin.Name = "lblBackLogin";
            lblBackLogin.Padding = new Padding(0, 10, 0, 0);
            lblBackLogin.Size = new Size(140, 38);
            lblBackLogin.TabIndex = 12;
            lblBackLogin.Text = "Back To LOGIN";
            lblBackLogin.TextAlign = ContentAlignment.MiddleCenter;
            lblBackLogin.Click += lblBackLogin_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(Bio);
            panel1.Location = new Point(12, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 152);
            panel1.TabIndex = 13;
            // 
            // Bio
            // 
            Bio.AutoWordSelection = true;
            Bio.BorderStyle = BorderStyle.None;
            Bio.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Bio.Location = new Point(-1, -1);
            Bio.MaxLength = 150;
            Bio.Name = "Bio";
            Bio.Size = new Size(462, 152);
            Bio.TabIndex = 0;
            Bio.Text = "";
            // 
            // avatarpanel
            // 
            avatarpanel.AutoScroll = true;
            avatarpanel.Location = new Point(12, 50);
            avatarpanel.Name = "avatarpanel";
            avatarpanel.Size = new Size(462, 205);
            avatarpanel.TabIndex = 14;
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Font = new Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAvatar.ForeColor = Color.CornflowerBlue;
            lblAvatar.Location = new Point(12, 9);
            lblAvatar.Margin = new Padding(20, 0, 3, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(94, 38);
            lblAvatar.TabIndex = 13;
            lblAvatar.Text = "Avatar";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBio
            // 
            lblBio.AutoSize = true;
            lblBio.Font = new Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBio.ForeColor = Color.CornflowerBlue;
            lblBio.Location = new Point(12, 318);
            lblBio.Margin = new Padding(20, 0, 3, 0);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(142, 38);
            lblBio.TabIndex = 15;
            lblBio.Text = "Biography";
            lblBio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // avatar
            // 
            avatar.BorderStyle = BorderStyle.FixedSingle;
            avatar.Location = new Point(194, 261);
            avatar.Name = "avatar";
            avatar.Size = new Size(80, 80);
            avatar.SizeMode = PictureBoxSizeMode.Zoom;
            avatar.TabIndex = 16;
            avatar.TabStop = false;
            // 
            // RegisterPart2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(486, 682);
            Controls.Add(avatar);
            Controls.Add(lblBio);
            Controls.Add(lblAvatar);
            Controls.Add(avatarpanel);
            Controls.Add(panel1);
            Controls.Add(lblBackLogin);
            Controls.Add(btnClear);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterPart2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterPart2";
            Load += RegisterPart2_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)avatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegister;
        private Button btnClear;
        private Label lblBackLogin;
        private Panel panel1;
        private FlowLayoutPanel avatarpanel;
        private RichTextBox Bio;
        private Label lblAvatar;
        private Label lblBio;
        private PictureBox avatar;
    }
}