namespace social_media
{
    partial class Main_Page
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
            mainPanel = new FlowLayoutPanel();
            lblSee = new Label();
            followersPanel = new FlowLayoutPanel();
            numFollowers = new Label();
            followers = new Label();
            followingPanel = new FlowLayoutPanel();
            numFollowing = new Label();
            following = new Label();
            createPostButton = new Button();
            createPanel = new TableLayoutPanel();
            btnClear = new Button();
            btnSend = new Button();
            button1 = new Button();
            rtxbSendingPost = new RichTextBox();
            numChar = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnHeart = new Button();
            btnSmile = new Button();
            btnLaugh = new Button();
            btnShocked = new Button();
            btnSad = new Button();
            btnCry = new Button();
            btnThankfull = new Button();
            btnReset = new Button();
            avatarofuser = new PictureBox();
            lblNameUser = new Label();
            lblusernameofuser = new Label();
            bio = new RichTextBox();
            btnForYour = new Button();
            btnFollowingpage = new Button();
            btnfollow = new Button();
            panel1 = new Panel();
            logo = new PictureBox();
            lblLogo = new Label();
            btnSettings = new Button();
            panelFoll = new FlowLayoutPanel();
            btnProfile = new Button();
            btnMainpage = new Button();
            btnReturn = new Button();
            recomendpanel = new FlowLayoutPanel();
            topicpanel = new FlowLayoutPanel();
            SearchBar = new TextBox();
            searchpanel = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            mainPanel.SuspendLayout();
            followersPanel.SuspendLayout();
            followingPanel.SuspendLayout();
            createPanel.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatarofuser).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(lblSee);
            mainPanel.Location = new Point(553, 80);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(828, 921);
            mainPanel.TabIndex = 0;
            // 
            // lblSee
            // 
            lblSee.Cursor = Cursors.Hand;
            lblSee.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblSee.ForeColor = Color.Navy;
            lblSee.Location = new Point(3, 0);
            lblSee.Name = "lblSee";
            lblSee.Size = new Size(798, 68);
            lblSee.TabIndex = 13;
            lblSee.Text = "See more";
            lblSee.TextAlign = ContentAlignment.MiddleCenter;
            lblSee.Click += lblSee_Click;
            // 
            // followersPanel
            // 
            followersPanel.Controls.Add(numFollowers);
            followersPanel.Controls.Add(followers);
            followersPanel.Location = new Point(30, 494);
            followersPanel.Name = "followersPanel";
            followersPanel.Size = new Size(438, 34);
            followersPanel.TabIndex = 4;
            followersPanel.Visible = false;
            // 
            // numFollowers
            // 
            numFollowers.AutoSize = true;
            numFollowers.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            numFollowers.Location = new Point(0, 0);
            numFollowers.Margin = new Padding(0);
            numFollowers.Name = "numFollowers";
            numFollowers.Size = new Size(55, 30);
            numFollowers.TabIndex = 5;
            numFollowers.Text = "100";
            // 
            // followers
            // 
            followers.Cursor = Cursors.Hand;
            followers.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            followers.Location = new Point(55, 0);
            followers.Margin = new Padding(0);
            followers.Name = "followers";
            followers.Size = new Size(114, 30);
            followers.TabIndex = 6;
            followers.Text = "followers";
            followers.Click += followers_Click;
            // 
            // followingPanel
            // 
            followingPanel.Controls.Add(numFollowing);
            followingPanel.Controls.Add(following);
            followingPanel.Location = new Point(30, 534);
            followingPanel.Name = "followingPanel";
            followingPanel.Size = new Size(438, 34);
            followingPanel.TabIndex = 8;
            followingPanel.Visible = false;
            // 
            // numFollowing
            // 
            numFollowing.AutoSize = true;
            numFollowing.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            numFollowing.Location = new Point(0, 0);
            numFollowing.Margin = new Padding(0);
            numFollowing.Name = "numFollowing";
            numFollowing.Size = new Size(69, 30);
            numFollowing.TabIndex = 5;
            numFollowing.Text = "2550";
            // 
            // following
            // 
            following.Cursor = Cursors.Hand;
            following.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            following.Location = new Point(72, 0);
            following.Name = "following";
            following.Size = new Size(114, 30);
            following.TabIndex = 6;
            following.Text = "following";
            following.Click += following_Click;
            // 
            // createPostButton
            // 
            createPostButton.BackColor = Color.WhiteSmoke;
            createPostButton.Cursor = Cursors.Hand;
            createPostButton.FlatAppearance.BorderColor = Color.Navy;
            createPostButton.FlatAppearance.BorderSize = 0;
            createPostButton.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            createPostButton.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            createPostButton.FlatStyle = FlatStyle.Flat;
            createPostButton.Font = new Font("Arial", 15F, FontStyle.Bold);
            createPostButton.ForeColor = Color.Navy;
            createPostButton.Image = Properties.Resources.sendicon;
            createPostButton.ImageAlign = ContentAlignment.MiddleLeft;
            createPostButton.Location = new Point(30, 319);
            createPostButton.Name = "createPostButton";
            createPostButton.Size = new Size(197, 38);
            createPostButton.TabIndex = 9;
            createPostButton.Text = "  Send Post";
            createPostButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            createPostButton.UseVisualStyleBackColor = false;
            createPostButton.Click += createPostButton_Click;
            // 
            // createPanel
            // 
            createPanel.BackColor = Color.Navy;
            createPanel.ColumnCount = 4;
            createPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            createPanel.ColumnStyles.Add(new ColumnStyle());
            createPanel.ColumnStyles.Add(new ColumnStyle());
            createPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            createPanel.Controls.Add(btnClear, 0, 1);
            createPanel.Controls.Add(btnSend, 3, 1);
            createPanel.Controls.Add(button1, 3, 0);
            createPanel.Controls.Add(rtxbSendingPost, 2, 1);
            createPanel.Controls.Add(numChar, 3, 2);
            createPanel.Controls.Add(flowLayoutPanel3, 2, 2);
            createPanel.Location = new Point(554, 260);
            createPanel.Name = "createPanel";
            createPanel.RowCount = 3;
            createPanel.RowStyles.Add(new RowStyle());
            createPanel.RowStyles.Add(new RowStyle());
            createPanel.RowStyles.Add(new RowStyle());
            createPanel.Size = new Size(811, 407);
            createPanel.TabIndex = 10;
            createPanel.Visible = false;
            createPanel.Paint += createPanel_Paint;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Left;
            btnClear.BackColor = Color.Navy;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseDownBackColor = Color.Navy;
            btnClear.FlatAppearance.MouseOverBackColor = Color.Navy;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Image = Properties.Resources.trashwhite;
            btnClear.Location = new Point(10, 153);
            btnClear.Margin = new Padding(10, 0, 0, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(60, 65);
            btnClear.TabIndex = 11;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Left;
            btnSend.BackColor = Color.Transparent;
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatAppearance.MouseDownBackColor = Color.Navy;
            btnSend.FlatAppearance.MouseOverBackColor = Color.Navy;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Image = Properties.Resources.sendbutton60white;
            btnSend.Location = new Point(736, 150);
            btnSend.Margin = new Padding(0);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(60, 70);
            btnSend.TabIndex = 4;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(766, 3);
            button1.Margin = new Padding(30, 3, 3, 3);
            button1.Name = "button1";
            button1.Size = new Size(32, 34);
            button1.TabIndex = 1;
            button1.Text = "x";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // rtxbSendingPost
            // 
            rtxbSendingPost.AutoWordSelection = true;
            rtxbSendingPost.BorderStyle = BorderStyle.None;
            rtxbSendingPost.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtxbSendingPost.Location = new Point(78, 43);
            rtxbSendingPost.MaxLength = 300;
            rtxbSendingPost.Name = "rtxbSendingPost";
            rtxbSendingPost.Size = new Size(650, 285);
            rtxbSendingPost.TabIndex = 0;
            rtxbSendingPost.Text = "";
            rtxbSendingPost.TextChanged += rtxbSendingPost_TextChanged;
            // 
            // numChar
            // 
            numChar.AutoSize = true;
            numChar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            numChar.ForeColor = Color.White;
            numChar.Location = new Point(739, 331);
            numChar.Name = "numChar";
            numChar.Size = new Size(43, 24);
            numChar.TabIndex = 9;
            numChar.Text = "300";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnHeart);
            flowLayoutPanel3.Controls.Add(btnSmile);
            flowLayoutPanel3.Controls.Add(btnLaugh);
            flowLayoutPanel3.Controls.Add(btnShocked);
            flowLayoutPanel3.Controls.Add(btnSad);
            flowLayoutPanel3.Controls.Add(btnCry);
            flowLayoutPanel3.Controls.Add(btnThankfull);
            flowLayoutPanel3.Location = new Point(78, 334);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(655, 73);
            flowLayoutPanel3.TabIndex = 8;
            // 
            // btnHeart
            // 
            btnHeart.Anchor = AnchorStyles.Left;
            btnHeart.AutoSize = true;
            btnHeart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHeart.BackColor = Color.White;
            btnHeart.FlatStyle = FlatStyle.Flat;
            btnHeart.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnHeart.Location = new Point(0, 0);
            btnHeart.Margin = new Padding(0);
            btnHeart.Name = "btnHeart";
            btnHeart.Size = new Size(87, 63);
            btnHeart.TabIndex = 12;
            btnHeart.Text = "❤";
            btnHeart.UseVisualStyleBackColor = false;
            btnHeart.Click += btnHeart_Click;
            // 
            // btnSmile
            // 
            btnSmile.Anchor = AnchorStyles.Left;
            btnSmile.AutoSize = true;
            btnSmile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSmile.BackColor = Color.White;
            btnSmile.FlatStyle = FlatStyle.Flat;
            btnSmile.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSmile.Location = new Point(94, 0);
            btnSmile.Margin = new Padding(7, 0, 0, 0);
            btnSmile.Name = "btnSmile";
            btnSmile.Size = new Size(87, 63);
            btnSmile.TabIndex = 13;
            btnSmile.Text = "😃";
            btnSmile.UseVisualStyleBackColor = false;
            btnSmile.Click += btnSmile_Click;
            // 
            // btnLaugh
            // 
            btnLaugh.Anchor = AnchorStyles.Left;
            btnLaugh.AutoSize = true;
            btnLaugh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLaugh.BackColor = Color.White;
            btnLaugh.FlatStyle = FlatStyle.Flat;
            btnLaugh.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLaugh.Location = new Point(188, 0);
            btnLaugh.Margin = new Padding(7, 0, 0, 0);
            btnLaugh.Name = "btnLaugh";
            btnLaugh.Size = new Size(87, 63);
            btnLaugh.TabIndex = 14;
            btnLaugh.Text = "😂";
            btnLaugh.UseVisualStyleBackColor = false;
            btnLaugh.Click += btnLaugh_Click;
            // 
            // btnShocked
            // 
            btnShocked.Anchor = AnchorStyles.Left;
            btnShocked.AutoSize = true;
            btnShocked.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnShocked.BackColor = Color.White;
            btnShocked.FlatStyle = FlatStyle.Flat;
            btnShocked.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnShocked.Location = new Point(282, 0);
            btnShocked.Margin = new Padding(7, 0, 0, 0);
            btnShocked.Name = "btnShocked";
            btnShocked.Size = new Size(87, 63);
            btnShocked.TabIndex = 15;
            btnShocked.Text = "😨";
            btnShocked.UseVisualStyleBackColor = false;
            btnShocked.Click += btnShocked_Click;
            // 
            // btnSad
            // 
            btnSad.Anchor = AnchorStyles.Left;
            btnSad.AutoSize = true;
            btnSad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSad.BackColor = Color.White;
            btnSad.FlatStyle = FlatStyle.Flat;
            btnSad.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSad.Location = new Point(376, 0);
            btnSad.Margin = new Padding(7, 0, 0, 0);
            btnSad.Name = "btnSad";
            btnSad.Size = new Size(87, 63);
            btnSad.TabIndex = 16;
            btnSad.Text = "😢";
            btnSad.UseVisualStyleBackColor = false;
            btnSad.Click += btnSad_Click;
            // 
            // btnCry
            // 
            btnCry.Anchor = AnchorStyles.Left;
            btnCry.AutoSize = true;
            btnCry.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCry.BackColor = Color.White;
            btnCry.FlatStyle = FlatStyle.Flat;
            btnCry.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCry.Location = new Point(470, 0);
            btnCry.Margin = new Padding(7, 0, 0, 0);
            btnCry.Name = "btnCry";
            btnCry.Size = new Size(87, 63);
            btnCry.TabIndex = 17;
            btnCry.Text = "😭";
            btnCry.UseVisualStyleBackColor = false;
            btnCry.Click += btnCry_Click;
            // 
            // btnThankfull
            // 
            btnThankfull.Anchor = AnchorStyles.Left;
            btnThankfull.AutoSize = true;
            btnThankfull.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnThankfull.BackColor = Color.White;
            btnThankfull.FlatStyle = FlatStyle.Flat;
            btnThankfull.Font = new Font("Arial", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnThankfull.Location = new Point(564, 0);
            btnThankfull.Margin = new Padding(7, 0, 0, 0);
            btnThankfull.Name = "btnThankfull";
            btnThankfull.Size = new Size(87, 63);
            btnThankfull.TabIndex = 18;
            btnThankfull.Text = "🙏";
            btnThankfull.UseVisualStyleBackColor = false;
            btnThankfull.Click += btnThankfull_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Left;
            btnReset.BackColor = Color.Transparent;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Image = Properties.Resources.refresh;
            btnReset.Location = new Point(1386, 0);
            btnReset.Margin = new Padding(5, 0, 5, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(60, 60);
            btnReset.TabIndex = 12;
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // avatarofuser
            // 
            avatarofuser.BackColor = Color.Transparent;
            avatarofuser.Location = new Point(30, 30);
            avatarofuser.Margin = new Padding(30, 30, 3, 3);
            avatarofuser.Name = "avatarofuser";
            avatarofuser.Size = new Size(120, 120);
            avatarofuser.SizeMode = PictureBoxSizeMode.Zoom;
            avatarofuser.TabIndex = 13;
            avatarofuser.TabStop = false;
            avatarofuser.Visible = false;
            // 
            // lblNameUser
            // 
            lblNameUser.AutoSize = true;
            lblNameUser.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblNameUser.Location = new Point(30, 153);
            lblNameUser.Name = "lblNameUser";
            lblNameUser.Size = new Size(153, 30);
            lblNameUser.TabIndex = 14;
            lblNameUser.Text = "nameofuser";
            lblNameUser.Visible = false;
            // 
            // lblusernameofuser
            // 
            lblusernameofuser.AutoSize = true;
            lblusernameofuser.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblusernameofuser.ForeColor = Color.Gray;
            lblusernameofuser.Location = new Point(30, 183);
            lblusernameofuser.Name = "lblusernameofuser";
            lblusernameofuser.Size = new Size(150, 28);
            lblusernameofuser.TabIndex = 15;
            lblusernameofuser.Text = "@username";
            lblusernameofuser.Visible = false;
            // 
            // bio
            // 
            bio.BackColor = Color.WhiteSmoke;
            bio.BorderStyle = BorderStyle.None;
            bio.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            bio.Location = new Point(30, 214);
            bio.Name = "bio";
            bio.ReadOnly = true;
            bio.ScrollBars = RichTextBoxScrollBars.None;
            bio.Size = new Size(446, 274);
            bio.TabIndex = 16;
            bio.Text = "";
            bio.Visible = false;
            bio.TextChanged += bio_TextChanged;
            // 
            // btnForYour
            // 
            btnForYour.BackColor = Color.Navy;
            btnForYour.Cursor = Cursors.Hand;
            btnForYour.FlatAppearance.BorderColor = Color.Navy;
            btnForYour.FlatAppearance.BorderSize = 3;
            btnForYour.FlatStyle = FlatStyle.Flat;
            btnForYour.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnForYour.ForeColor = Color.White;
            btnForYour.Location = new Point(553, 12);
            btnForYour.Name = "btnForYour";
            btnForYour.Size = new Size(412, 38);
            btnForYour.TabIndex = 19;
            btnForYour.Text = "For You";
            btnForYour.UseVisualStyleBackColor = false;
            btnForYour.Click += btnForYour_Click;
            // 
            // btnFollowingpage
            // 
            btnFollowingpage.BackColor = Color.White;
            btnFollowingpage.Cursor = Cursors.Hand;
            btnFollowingpage.FlatAppearance.BorderColor = Color.Navy;
            btnFollowingpage.FlatAppearance.BorderSize = 3;
            btnFollowingpage.FlatStyle = FlatStyle.Flat;
            btnFollowingpage.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnFollowingpage.ForeColor = Color.Navy;
            btnFollowingpage.Location = new Point(964, 12);
            btnFollowingpage.Name = "btnFollowingpage";
            btnFollowingpage.Size = new Size(414, 38);
            btnFollowingpage.TabIndex = 20;
            btnFollowingpage.Text = "Following";
            btnFollowingpage.UseVisualStyleBackColor = false;
            btnFollowingpage.Click += btnFollowingpage_Click;
            // 
            // btnfollow
            // 
            btnfollow.BackColor = Color.White;
            btnfollow.Cursor = Cursors.Hand;
            btnfollow.FlatAppearance.BorderColor = Color.Navy;
            btnfollow.FlatAppearance.BorderSize = 3;
            btnfollow.FlatStyle = FlatStyle.Flat;
            btnfollow.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnfollow.ForeColor = Color.Navy;
            btnfollow.Location = new Point(312, 153);
            btnfollow.Name = "btnfollow";
            btnfollow.Size = new Size(164, 41);
            btnfollow.TabIndex = 22;
            btnfollow.Text = "Follow";
            btnfollow.UseVisualStyleBackColor = false;
            btnfollow.Visible = false;
            btnfollow.Click += btnfollow_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(logo);
            panel1.Controls.Add(lblLogo);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(panelFoll);
            panel1.Controls.Add(btnProfile);
            panel1.Controls.Add(btnMainpage);
            panel1.Controls.Add(avatarofuser);
            panel1.Controls.Add(btnfollow);
            panel1.Controls.Add(lblusernameofuser);
            panel1.Controls.Add(createPostButton);
            panel1.Controls.Add(lblNameUser);
            panel1.Controls.Add(bio);
            panel1.Controls.Add(followersPanel);
            panel1.Controls.Add(followingPanel);
            panel1.Location = new Point(0, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(548, 1057);
            panel1.TabIndex = 23;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.logo1;
            logo.Location = new Point(30, 31);
            logo.Name = "logo";
            logo.Size = new Size(120, 120);
            logo.TabIndex = 28;
            logo.TabStop = false;
            // 
            // lblLogo
            // 
            lblLogo.Cursor = Cursors.Hand;
            lblLogo.Font = new Font("Corbel", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblLogo.ForeColor = Color.Navy;
            lblLogo.Location = new Point(11, 153);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(150, 39);
            lblLogo.TabIndex = 30;
            lblLogo.Text = "FLOCKR";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.WhiteSmoke;
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderColor = Color.Navy;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnSettings.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Arial", 15F, FontStyle.Bold);
            btnSettings.ForeColor = Color.Navy;
            btnSettings.Image = Properties.Resources.settingsicon;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(30, 363);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(406, 38);
            btnSettings.TabIndex = 27;
            btnSettings.Text = "  Change Avatar Or Biography";
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // panelFoll
            // 
            panelFoll.AutoScroll = true;
            panelFoll.Location = new Point(30, 574);
            panelFoll.Name = "panelFoll";
            panelFoll.Size = new Size(478, 450);
            panelFoll.TabIndex = 26;
            panelFoll.Visible = false;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.WhiteSmoke;
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.FlatAppearance.BorderColor = Color.Navy;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnProfile.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Arial", 15F, FontStyle.Bold);
            btnProfile.ForeColor = Color.Navy;
            btnProfile.Image = Properties.Resources.profile;
            btnProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfile.Location = new Point(30, 275);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(150, 38);
            btnProfile.TabIndex = 25;
            btnProfile.Text = "  Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnMainpage
            // 
            btnMainpage.BackColor = Color.WhiteSmoke;
            btnMainpage.Cursor = Cursors.Hand;
            btnMainpage.FlatAppearance.BorderColor = Color.Navy;
            btnMainpage.FlatAppearance.BorderSize = 0;
            btnMainpage.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            btnMainpage.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            btnMainpage.FlatStyle = FlatStyle.Flat;
            btnMainpage.Font = new Font("Arial", 15F, FontStyle.Bold);
            btnMainpage.ForeColor = Color.Navy;
            btnMainpage.Image = Properties.Resources.homeicon;
            btnMainpage.ImageAlign = ContentAlignment.MiddleLeft;
            btnMainpage.Location = new Point(30, 231);
            btnMainpage.Name = "btnMainpage";
            btnMainpage.Size = new Size(197, 38);
            btnMainpage.TabIndex = 24;
            btnMainpage.Text = "  Main Page";
            btnMainpage.TextAlign = ContentAlignment.MiddleLeft;
            btnMainpage.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMainpage.UseVisualStyleBackColor = false;
            btnMainpage.Click += btnMainpage_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.Transparent;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.BorderColor = Color.Navy;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnReturn.ForeColor = Color.White;
            btnReturn.Image = Properties.Resources.home;
            btnReturn.Location = new Point(914, 12);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(91, 62);
            btnReturn.TabIndex = 26;
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Visible = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // recomendpanel
            // 
            recomendpanel.Location = new Point(1415, 558);
            recomendpanel.Name = "recomendpanel";
            recomendpanel.Size = new Size(438, 474);
            recomendpanel.TabIndex = 28;
            // 
            // topicpanel
            // 
            topicpanel.Location = new Point(1418, 80);
            topicpanel.Name = "topicpanel";
            topicpanel.Size = new Size(438, 472);
            topicpanel.TabIndex = 30;
            // 
            // SearchBar
            // 
            SearchBar.Font = new Font("Arial", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            SearchBar.Location = new Point(1454, 12);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(394, 36);
            SearchBar.TabIndex = 31;
            SearchBar.TextChanged += SearchBar_TextChanged;
            // 
            // searchpanel
            // 
            searchpanel.BackColor = Color.WhiteSmoke;
            searchpanel.BorderStyle = BorderStyle.FixedSingle;
            searchpanel.Location = new Point(1452, 54);
            searchpanel.Name = "searchpanel";
            searchpanel.Size = new Size(438, 472);
            searchpanel.TabIndex = 31;
            searchpanel.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.searchicon;
            pictureBox1.Location = new Point(1854, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 36);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // Main_Page
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pictureBox1);
            Controls.Add(searchpanel);
            Controls.Add(SearchBar);
            Controls.Add(recomendpanel);
            Controls.Add(topicpanel);
            Controls.Add(panel1);
            Controls.Add(btnReturn);
            Controls.Add(btnFollowingpage);
            Controls.Add(btnReset);
            Controls.Add(btnForYour);
            Controls.Add(createPanel);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Main_Page";
            Text = "Flockr";
            WindowState = FormWindowState.Maximized;
            Load += Main_Page_Load;
            mainPanel.ResumeLayout(false);
            followersPanel.ResumeLayout(false);
            followersPanel.PerformLayout();
            followingPanel.ResumeLayout(false);
            followingPanel.PerformLayout();
            createPanel.ResumeLayout(false);
            createPanel.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)avatarofuser).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel mainPanel;
        private FlowLayoutPanel followersPanel;
        private Label numFollowers;
        private Label followers;
        private FlowLayoutPanel followingPanel;
        private Label numFollowing;
        private Label following;
        private Button createPostButton;
        private TableLayoutPanel createPanel;
        private Button button1;
        private RichTextBox rtxbSendingPost;
        private Button btnSend;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label numChar;
        private Button btnClear;
        private Button btnHeart;
        private Button btnSmile;
        private Button btnLaugh;
        private Button btnShocked;
        private Button btnSad;
        private Button btnCry;
        private Button btnThankfull;
        private Button btnReset;
        private Label lblSee;
        private PictureBox avatarofuser;
        private Label lblNameUser;
        private Label lblusernameofuser;
        private RichTextBox bio;
        private Button btnForYour;
        private Button btnFollowingpage;
        private Button btnfollow;
        private Panel panel1;
        private Button btnMainpage;
        private Button btnProfile;
        private Button btnReturn;
        private FlowLayoutPanel panelFoll;
        private Button btnSettings;
        private FlowLayoutPanel recomendpanel;
        private FlowLayoutPanel topicpanel;
        private TextBox SearchBar;
        private FlowLayoutPanel searchpanel;
        private PictureBox pictureBox1;
        private PictureBox logo;
        private Label lblLogo;
    }
}