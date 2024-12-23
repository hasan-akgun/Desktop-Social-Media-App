namespace social_media
{
    partial class ChangeScreen
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
            avatarpanel = new FlowLayoutPanel();
            lblAvatar = new Label();
            avatar = new PictureBox();
            lblBio = new Label();
            Bio = new RichTextBox();
            lblBack = new Label();
            btnClear = new Button();
            btnChange = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)avatar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // avatarpanel
            // 
            avatarpanel.AutoScroll = true;
            avatarpanel.Location = new Point(158, 50);
            avatarpanel.Name = "avatarpanel";
            avatarpanel.Size = new Size(462, 205);
            avatarpanel.TabIndex = 15;
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Font = new Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAvatar.ForeColor = Color.CornflowerBlue;
            lblAvatar.Location = new Point(332, 9);
            lblAvatar.Margin = new Padding(20, 0, 3, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(94, 38);
            lblAvatar.TabIndex = 16;
            lblAvatar.Text = "Avatar";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // avatar
            // 
            avatar.BorderStyle = BorderStyle.FixedSingle;
            avatar.Location = new Point(346, 287);
            avatar.Name = "avatar";
            avatar.Size = new Size(80, 80);
            avatar.SizeMode = PictureBoxSizeMode.Zoom;
            avatar.TabIndex = 22;
            avatar.TabStop = false;
            // 
            // lblBio
            // 
            lblBio.AutoSize = true;
            lblBio.Font = new Font("Yu Gothic UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBio.ForeColor = Color.CornflowerBlue;
            lblBio.Location = new Point(312, 390);
            lblBio.Margin = new Padding(20, 0, 3, 0);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(142, 38);
            lblBio.TabIndex = 21;
            lblBio.Text = "Biography";
            lblBio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Bio
            // 
            Bio.AutoWordSelection = true;
            Bio.BorderStyle = BorderStyle.None;
            Bio.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Bio.Location = new Point(-1, -1);
            Bio.MaxLength = 150;
            Bio.Name = "Bio";
            Bio.Size = new Size(462, 254);
            Bio.TabIndex = 17;
            Bio.Text = "";
            // 
            // lblBack
            // 
            lblBack.AutoSize = true;
            lblBack.Cursor = Cursors.Hand;
            lblBack.FlatStyle = FlatStyle.Flat;
            lblBack.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBack.ForeColor = Color.Red;
            lblBack.Location = new Point(334, 879);
            lblBack.Margin = new Padding(20, 0, 3, 0);
            lblBack.Name = "lblBack";
            lblBack.Padding = new Padding(0, 10, 0, 0);
            lblBack.Size = new Size(106, 51);
            lblBack.TabIndex = 20;
            lblBack.Text = "Cancel";
            lblBack.TextAlign = ContentAlignment.MiddleCenter;
            lblBack.Click += lblBack_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.WhiteSmoke;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Yu Gothic UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnClear.ForeColor = Color.Navy;
            btnClear.Location = new Point(262, 816);
            btnClear.Margin = new Padding(3, 10, 3, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(252, 51);
            btnClear.TabIndex = 19;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.Navy;
            btnChange.Cursor = Cursors.Hand;
            btnChange.FlatAppearance.BorderSize = 0;
            btnChange.FlatStyle = FlatStyle.Flat;
            btnChange.Font = new Font("Yu Gothic UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnChange.ForeColor = Color.WhiteSmoke;
            btnChange.Location = new Point(262, 752);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(252, 51);
            btnChange.TabIndex = 18;
            btnChange.Text = "CHANGE";
            btnChange.UseVisualStyleBackColor = false;
            btnChange.Click += btnChange_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(Bio);
            panel1.Location = new Point(158, 431);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 254);
            panel1.TabIndex = 23;
            // 
            // ChangeScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(828, 1080);
            Controls.Add(panel1);
            Controls.Add(avatar);
            Controls.Add(lblBio);
            Controls.Add(lblBack);
            Controls.Add(btnClear);
            Controls.Add(btnChange);
            Controls.Add(lblAvatar);
            Controls.Add(avatarpanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChangeScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangeScreen";
            Load += ChangeScreen_Load;
            ((System.ComponentModel.ISupportInitialize)avatar).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel avatarpanel;
        private Label lblAvatar;
        private PictureBox avatar;
        private Label lblBio;
        private RichTextBox Bio;
        private Label lblBack;
        private Button btnClear;
        private Button btnChange;
        private Panel panel1;
    }
}