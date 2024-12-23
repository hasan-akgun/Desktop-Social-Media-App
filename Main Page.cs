using System.Runtime.InteropServices;


namespace social_media
{
    public partial class Main_Page : Form
    {

        PostManager PostManager;
        CommentManager CommentManager;
        FollowManager FollowManager;
        ChangeScreen changeScreen;
        post_structure post_structure;
        CommentStructure comment_structure;
        GetUserInfo info;
        GetUsers GetFoll;
        GetCategories getCategories;
        Search Search;
        UserProfileStructure profileStructure;
        Login login;
        Random random;
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private int pre_char = 0;
        private int numchar = 300;
        private int curr_char;
        private int see = 1;
        private int list_post_num;
        private int curr_post_num = 0;
        private int randomize;
        private int pre_list = 0;
        private int index_post = 0;
        private int counter = 0;
        private bool sent;
        private bool isClickedMain = true;
        private string postType = "GetAllPosts";
        private string targetUser = "";
        private int loginFollowing;
        private System.Windows.Forms.Timer timer;
        public string loginusername { get; private set; }
        public Main_Page(Login loginform)
        {
            InitializeComponent();
            this.FormClosing += Main_Page_FormClosing;
            PostManager = new PostManager();
            post_structure = new post_structure(this);
            comment_structure = new CommentStructure(this);
            CommentManager = new CommentManager();
            GetFoll = new GetUsers();
            getCategories = new GetCategories();
            FollowManager = new FollowManager();
            Search = new Search();
            profileStructure = new UserProfileStructure(this);
            info = new GetUserInfo();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 300;
            timer.Tick += Timer_Tick;
            login = loginform;
            random = new Random();
            lblSee.Visible = false;
            this.MouseClick += new MouseEventHandler(Form_MouseClick);
            panelFoll.MouseClick += new MouseEventHandler(Form_MouseClick);
            recomendpanel.MouseClick += new MouseEventHandler(Form_MouseClick);
            mainPanel.MouseClick += new MouseEventHandler(Form_MouseClick);
            panel1.MouseClick += new MouseEventHandler(Form_MouseClick);
            topicpanel.MouseClick += new MouseEventHandler(Form_MouseClick);
        }

        private void Main_Page_Load(object sender, EventArgs e)
        {
            mainPanel.MouseMove += (sender, e) => HideCaret(bio.Handle);
            bio.MouseClick += (sender, e) => HideCaret(bio.Handle);
            bio.Height = DynamicHeight();
            loginusername = login.Username;
            lblusernameofuser.Text = "@" + loginusername;
            LoadPosts();
            RecommendUsers();
            LoadCategories();
        }

        private async void LoadPosts()
        {
            int Rancoef = random.Next(0, 5);
            if (counter < 5 && see == 1)
            {
                PostManager.coef = Rancoef;
            }
            else if (counter >= 5 && see == 1)
            {
                PostManager.coef = 0;
            }
            await PostManager.LoadPostsAsync(loginusername, targetUser, postType);
            if (PostManager.Posts != null)
            {
                list_post_num = PostManager.Posts.Count;
            }
            else
            {
                list_post_num = 0;
            }
            if (list_post_num > 9)
            {
                counter = 0;
                while (curr_post_num < see * 10)
                {
                    DisplayPosts();
                }
                mainPanel.Controls.Add(lblSee);
                lblSee.Visible = true;
            }
            else if (list_post_num == 0 && postType == "GetAllPosts")
            {
                Refresh();
                counter++;
                LoadPosts();
            }
            else
            {
                DisplayPosts();
                mainPanel.Controls.Add(lblSee);
                lblSee.Visible = true;
            }

        }

        private void DisplayPosts()
        {
            if (PostManager.Posts != null)
            {
                foreach (var post in PostManager.Posts)
                {
                    if (postType == "GetAllPosts")
                    {
                        randomize = random.Next(1, 5);
                    }
                    else
                    {
                        randomize = 2;
                    }
                    if (!post.isShown && randomize == 2)
                    {
                        post_structure.AddPost(mainPanel, post, index_post, post.isLiked);
                        post.isShown = true;
                        index_post++;
                        CountPosts();
                    }

                    if (curr_post_num > (see * 10) - 1)
                    {
                        lblSee.Visible = true;
                        return;
                    }
                };
                lblSee.Visible = true;
            }

        }

        private void Main_Page_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void createPostButton_Click(object sender, EventArgs e)
        {
            createPanel.Show();
        }

        private void createPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public async Task ShowComm(string postId, int buttonIndex, string show)
        {
            int index = GetControlIndexByName(postId, buttonIndex);
            string id = postId.Substring(4);
            await CommentManager.LoadCommsAsync(0, id);
            if (show == "S")
            {
                FlowLayoutPanel panelComm = new FlowLayoutPanel();
                panelComm.AutoSize = true;

                Label commSee = new Label()
                {
                    ForeColor = Color.Navy,
                    Width = 640,
                    Margin = new Padding(80, 3, 3, 3),
                    Height = 30,
                    Text = "See more comments",
                    Name = "0",
                    Tag = id,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    Font = new Font("Arial", 12, FontStyle.Bold)

                };
                commSee.Click += new EventHandler(SeeMoreComm_Click);

                Panel textboxPanel = new Panel()
                {
                    BackColor = Color.WhiteSmoke,
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = 600,
                    Margin = new Padding(80, 3, 3, 3)
                };

                RichTextBox commRtxb = new RichTextBox()
                {
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Width = 600,
                    Margin = new Padding(80, 3, 3, 3),
                    BorderStyle = BorderStyle.None,
                    MaxLength = 300

                };

                Button sendComm = new Button()
                {
                    Height = 40,
                    Width = 40,
                    Margin = new Padding(3, 15, 0, 0),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Image = Properties.Resources.sendbutton30,
                    Name = id
                };
                sendComm.FlatAppearance.BorderSize = 0;
                sendComm.Click += new EventHandler(SendComButton_Click);

                mainPanel.Controls.Add(panelComm);
                mainPanel.Controls.SetChildIndex(panelComm, index + 1);
                if (CommentManager.Comments != null)
                {
                    foreach (var comm in CommentManager.Comments)
                    {
                        comment_structure.AddComm(panelComm, comm);
                    }
                }

                panelComm.Controls.Add(textboxPanel);
                textboxPanel.Controls.Add(commRtxb);
                panelComm.Controls.Add(sendComm);
                panelComm.Controls.Add(commSee);


                index_post++;
            }
            else
            {
                mainPanel.Controls.RemoveAt(index + 1);
                index_post--;
            }

        }
        private int GetControlIndexByName(string postId, int buttonIndex)
        {
            for (int i = buttonIndex; i < mainPanel.Controls.Count; i++)
            {
                if (mainPanel.Controls[i].Name == (postId))
                {
                    return i; // Kontrolcünün indeksini döndür
                }
            }
            return -1; // Kontrolcü bulunamazsa -1 döndür
        }

        private void SendComButton_Click(object sender, EventArgs e)
        {
            Button buton = sender as Button;
            FlowLayoutPanel panelcomm = buton.Parent as FlowLayoutPanel;
            int numPanel = panelcomm.Controls.Count;
            Panel textPanel = panelcomm.Controls[numPanel - 3] as Panel;
            RichTextBox richTextBox = textPanel.Controls[0] as RichTextBox;
            if (richTextBox.Text != "")
            {
                CommentManager.SendComm(loginusername, buton.Name, richTextBox);
                richTextBox.Text = "";
            }

        }
        private async void SeeMoreComm_Click(object sender, EventArgs e)
        {
            Label seemore = sender as Label;
            FlowLayoutPanel panelCom = seemore.Parent as FlowLayoutPanel;
            int numPanel = panelCom.Controls.Count;
            Panel textPanel = panelCom.Controls[numPanel - 3] as Panel;
            Button btnSend = panelCom.Controls[numPanel - 2] as Button;
            int comCoef = int.Parse(seemore.Name);
            comCoef++;
            seemore.Name = comCoef.ToString();
            await CommentManager.LoadCommsAsync(comCoef, seemore.Tag.ToString());
            if (CommentManager.Comments != null)
            {
                foreach (var comm in CommentManager.Comments)
                {
                    comment_structure.AddComm(panelCom, comm);
                }
            }
            else
            {
                seemore.Visible = false;
            }
            panelCom.Controls.Add(textPanel);
            panelCom.Controls.Add(btnSend);
            panelCom.Controls.Add(seemore);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Rtf = null;
            numchar = 300;
            numChar.Text = "300";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createPanel.Hide();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (rtxbSendingPost.Text != "")
            {
                sent = await PostManager.SendPost(login.Username, rtxbSendingPost);
            }
            if (sent)
            {
                rtxbSendingPost.Text = "";
                createPanel.Hide();
            }
            else
                MessageBox.Show("Error");
        }

        private void rtxbSendingPost_TextChanged(object sender, EventArgs e)
        {
            curr_char = rtxbSendingPost.Text.Length;
            if (curr_char > pre_char)
            {
                numchar -= (curr_char - pre_char);
                numChar.Text = numchar.ToString();
                pre_char = curr_char;
                if (numchar == 0)
                {
                    numChar.ForeColor = Color.Red;
                }
            }
            else
            {
                numchar += (pre_char - curr_char);
                numChar.Text = numchar.ToString();
                pre_char = curr_char;
                if (numchar != 0)
                {
                    numChar.ForeColor = Color.White;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RecommendUsers();
            LoadCategories();
            Refresh();
            LoadPosts();
        }
        private void Refresh()
        {
            lblSee.Visible = false;
            searchpanel.Visible = false;
            SearchBar.Clear();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(lblSee);
            see = 1;
            index_post = 0;
            curr_post_num = 0;
            pre_list = 0;
            counter = 5;           
        }

        private void lblSee_Click(object sender, EventArgs e)
        {
            if (PostManager.Posts != null)
            {
                see++;
                lblSee.Visible = false;
                list_post_num = PostManager.Posts.Count;

                if (list_post_num + pre_list == curr_post_num)
                {
                    pre_list = list_post_num;
                    PostManager.coef++;
                    LoadPosts();
                    lblSee.Visible = true;
                    return;
                }
                if (list_post_num + pre_list > see * 10)
                {
                    while (curr_post_num < see * 10)
                    {
                        DisplayPosts();
                    }
                }
                else
                {
                    int remain_post_num = (list_post_num + pre_list) - curr_post_num;
                    while (remain_post_num != 0)
                    {
                        DisplayPosts();
                        remain_post_num = (list_post_num + pre_list) - curr_post_num;
                    }
                }
                mainPanel.Controls.Add(lblSee);
            }

        }

        private void CountPosts()
        {
            for (int i = index_post; i < mainPanel.Controls.Count; i++)
            {
                Control control = mainPanel.Controls[i];
                if (control.Name.Contains("Post"))
                {
                    curr_post_num++;
                }
            }


        }

        private async void ShowProfile()
        {
            await info.LoadInfoAsync(loginusername, targetUser);

            lblusernameofuser.Visible = true;
            lblusernameofuser.Text = "@" + targetUser;
            lblNameUser.Visible = true;
            lblNameUser.Text = info.info.name;
            avatarofuser.Visible = true;
            avatarofuser.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(info.info.pp_id);
            bio.Visible = true;
            bio.Rtf = info.info.bio;
            bio.Font = new Font("Arial", 15, FontStyle.Regular);
            followersPanel.Visible = true;
            numFollowers.Text = info.info.follower_count;
            followingPanel.Visible = true;
            numFollowing.Text = info.info.following_count;
            btnMainpage.Visible = false;
            btnProfile.Visible = false;
            createPostButton.Visible = false;
            btnSettings.Visible = false;
            btnFollowingpage.Visible = false;
            btnForYour.Visible = false;
            logo.Visible = false;
            lblLogo.Visible = false;
            btnReturn.Visible = true;
            if (loginusername != targetUser)
            {
                btnfollow.Visible = true;
                if (info.info.is_following == true)
                {
                    btnfollow.Text = "Following";
                    btnfollow.BackColor = Color.Navy;
                    btnfollow.ForeColor = Color.White;
                }
                else
                {
                    btnfollow.Text = "Follow";
                    btnfollow.BackColor = Color.White;
                    btnfollow.ForeColor = Color.Navy;
                }
            }
            else
            {
                btnfollow.Visible = false;
            }
            bio.Height = DynamicHeight();
            int position = bio.Location.Y + bio.Height;
            followersPanel.Location = new Point(30, position);
            followingPanel.Location = new Point(30, position + 35);
            SetPanelFoll();
            panelFoll.Controls.Clear();
            panelFoll.Visible = true;

        }
        private void HideProfile()
        {
            lblusernameofuser.Visible = false;
            lblNameUser.Visible = false;
            avatarofuser.Visible = false;
            bio.Visible = false;
            followersPanel.Visible = false;
            followingPanel.Visible = false;
            btnProfile.Visible = true;
            btnMainpage.Visible = true;
            createPostButton.Visible = true;
            btnForYour.Visible = true;
            btnSettings.Visible = true;
            btnFollowingpage.Visible = true;
            btnReturn.Visible = false;
            btnfollow.Visible = false;
            panelFoll.Visible = false;
            logo.Visible = true;
            lblLogo.Visible = true;

        }

        private void SetPanelFoll()
        {
            int temploc = panelFoll.Location.Y;
            panelFoll.Location = new Point(30, followingPanel.Location.Y + 40);
            panelFoll.Height += (temploc - panelFoll.Location.Y);
        }

        public void ClickAvatar(string username, string name)
        {
            lblNameUser.Text = name;
            lblusernameofuser.Text = "@" + username;
            targetUser = username;
            postType = "GetUsersPosts";
            ShowProfile();
            Refresh();
            LoadPosts();
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnForYour_Click(object sender, EventArgs e)
        {
            if (isClickedMain)
            {
                return;
            }
            else
            {
                postType = "GetAllPosts";
                isClickedMain = true;
                btnForYour.BackColor = Color.Navy;
                btnForYour.ForeColor = Color.White;
                btnFollowingpage.BackColor = Color.White;
                btnFollowingpage.ForeColor = Color.Navy;
                Refresh();
                LoadPosts();
            }
        }

        private async void btnFollowingpage_Click(object sender, EventArgs e)
        {
            await info.LoadInfoAsync(loginusername, loginusername);
            loginFollowing = int.Parse(info.info.following_count);
            if (!isClickedMain)
            {
                return;
            }
            else
            {
                postType = "GetFollowsPosts";
                isClickedMain = false;
                btnFollowingpage.BackColor = Color.Navy;
                btnFollowingpage.ForeColor = Color.White;
                btnForYour.BackColor = Color.White;
                btnForYour.ForeColor = Color.Navy;
                if (loginFollowing > 0)
                {
                    Refresh();
                    LoadPosts();
                }
                else
                {
                    mainPanel.Controls.Clear();
                }

            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            isClickedMain = true;
            btnForYour.BackColor = Color.Navy;
            btnForYour.ForeColor = Color.White;
            btnFollowingpage.BackColor = Color.White;
            btnFollowingpage.ForeColor = Color.Navy;
            postType = "GetAllPosts";
            HideProfile();
            Refresh();
            LoadPosts();
        }
        private int DynamicHeight()
        {
            int lineHeight = bio.Font.Height;
            int lineCount = bio.GetLineFromCharIndex(bio.Text.Length - 1) + 1;
            return (lineCount * lineHeight) + 15; // Satır sayısı * satır yüksekliği + biraz boşluk
        }

        private void bio_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnfollow_Click(object sender, EventArgs e)
        {
            if (btnfollow.BackColor == Color.White)
            {
                btnfollow.Text = "Following";
                btnfollow.BackColor = Color.Navy;
                btnfollow.ForeColor = Color.White;
            }
            else
            {
                btnfollow.Text = "Follow";
                btnfollow.BackColor = Color.White;
                btnfollow.ForeColor = Color.Navy;
            }
            await FollowManager.Follow(loginusername, targetUser);
            ShowProfile();
        }

        private async void btnProfile_Click(object sender, EventArgs e)
        {
            targetUser = loginusername;
            postType = "GetUsersPosts";

            ShowProfile();
            Refresh();
            LoadPosts();
        }

        private async void followers_Click(object sender, EventArgs e)
        {
            panelFoll.Controls.Clear();
            Label lblFollower = new Label()
            {
                Text = "Followers",
                Font = new Font("Arial", 15, FontStyle.Bold),
                ForeColor = Color.Navy,
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 430,
                Height = 40
            };
            panelFoll.Controls.Add(lblFollower);
            await GetFoll.LoadFollsAsync(targetUser, "GetFollowers");
            if (GetFoll.Users != null)
            {
                foreach (var foll in GetFoll.Users)
                {
                    profileStructure.AddProfile(panelFoll, foll);
                }
            }

        }

        private async void following_Click(object sender, EventArgs e)
        {
            panelFoll.Controls.Clear();
            Label lblFollowing = new Label()
            {
                Text = "Followings",
                Font = new Font("Arial", 15, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Navy,
                Width = 430,
                Height = 40
            };
            panelFoll.Controls.Add(lblFollowing);
            await GetFoll.LoadFollsAsync(targetUser, "GetFollows");
            if (GetFoll.Users != null)
            {
                foreach (var foll in GetFoll.Users)
                {
                    profileStructure.AddProfile(panelFoll, foll);
                }
            }
        }

        private async void RecommendUsers()
        {
            recomendpanel.Controls.Clear();
            Label lblRecc = new Label()
            {
                Font = new Font("Arial", 15, FontStyle.Bold),
                Text = "Recommended Users",
                ForeColor = Color.Navy,
                Width = 435,
                Height = 39,
            };
            recomendpanel.Controls.Add(lblRecc);

            await GetFoll.LoadFollsAsync(loginusername, "GetRecommendedUsers");
            if (GetFoll.Users != null)
            {
                foreach (var recomend in GetFoll.Users)
                {
                    profileStructure.AddProfile(recomendpanel, recomend);
                }
            }
        }

        private async void LoadCategories()
        {
            topicpanel.Controls.Clear();
            Label lblTopic = new Label()
            {
                Font = new Font("Arial", 15, FontStyle.Bold),
                Text = "Popular Topics",
                ForeColor = Color.Navy,
                Width = 435,
                Height = 39,
            };
            topicpanel.Controls.Add(lblTopic);
            await getCategories.LoadCategoriesAsync();
            if (getCategories.Categories != null)
            {
                foreach (var c in getCategories.Categories)
                {
                    CreateCategorieLbl(c, topicpanel);
                }
            }

        }
        private void CreateCategorieLbl(Categories c, Panel panel)
        {

            FlowLayoutPanel categoryPanel = new FlowLayoutPanel()
            {
                Width = 430,
                Height = 35,
            };
            Label categoriename = new Label()
            {
                Font = new Font("Arial", 15, FontStyle.Bold),
                Text = "#" + c.name,
                Name = c.name,
                Cursor = Cursors.Hand,
                ForeColor = Color.Blue,
                AutoSize = true
            };
            categoriename.Click += CategorieName_Click;
            Label categorycount = new Label()
            {
                Font = new Font("Arial", 12, FontStyle.Regular),
                Text = "• " + c.usage_count + " post sent",
                ForeColor = Color.Gray,
                Margin = new Padding(0, 5, 0, 0),
                AutoSize = true
            };
            panel.Controls.Add(categoryPanel);
            categoryPanel.Controls.Add(categoriename);
            categoryPanel.Controls.Add(categorycount);
        }
        private void CategorieName_Click(object sender, EventArgs e)
        {
            Label categoryname = sender as Label;
            postType = "GetCategoriesPosts";
            targetUser = categoryname.Name;
            HideProfile();
            btnForYour.Visible = false;
            btnFollowingpage.Visible = false;
            Refresh();
            LoadPosts();
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            DoSearch();
        }
        private async void DoSearch()
        {
            int totalheight = 0;
            searchpanel.Visible = true;
            searchpanel.Controls.Clear();
            string searchtext = "";
            if (Search.CategorySearched != null)
                Search.CategorySearched.Clear();
            if (Search.UserSearched != null)
                Search.UserSearched.Clear();
            if (SearchBar.Text.StartsWith("@"))
            {
                searchtext = SearchBar.Text.Substring(1);
                await Search.LoadUserSearchedAsync(searchtext);
            }
            else if (SearchBar.Text.StartsWith("#"))
            {
                searchtext = SearchBar.Text.Substring(1);
                await Search.LoadCategorySearchedAsync(searchtext);
            }
            else
            {
                searchtext = SearchBar.Text;
                await Search.LoadUserSearchedAsync(searchtext);
                await Search.LoadCategorySearchedAsync(searchtext);
            }

            if (Search.UserSearched != null && searchpanel.Controls.Count == 0)
            {
                foreach (var userSearch in Search.UserSearched)
                {
                    profileStructure.AddProfile(searchpanel, userSearch);
                }
            }
            if (Search.CategorySearched != null && searchpanel.Controls.Count == 0)
            {
                foreach (var categorySearch in Search.CategorySearched)
                {
                    CreateCategorieLbl(categorySearch, searchpanel);
                }
            }

            foreach (Control control in searchpanel.Controls)
            {
                totalheight += control.Height;
            }
            if (totalheight > 0)
            {
                searchpanel.Height = totalheight + (searchpanel.Controls.Count + 1) * 6;
            }
            else
            {
                searchpanel.Height = 0;
            }
        }

        private void btnMainpage_Click(object sender, EventArgs e)
        {
            isClickedMain = true;
            btnForYour.Visible= true;
            btnFollowingpage.Visible= true;
            btnForYour.BackColor = Color.Navy;
            btnForYour.ForeColor = Color.White;
            btnFollowingpage.BackColor = Color.White;
            btnFollowingpage.ForeColor = Color.Navy;
            postType = "GetAllPosts";
            HideProfile();
            Refresh();
            LoadPosts();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            changeScreen = new ChangeScreen(this);
            changeScreen.Show();
            this.Enabled = false;
        }

        private void btnHeart_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnHeart.Text;
        }

        private void btnSmile_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnSmile.Text;
        }

        private void btnLaugh_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnLaugh.Text;
        }

        private void btnShocked_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnShocked.Text;
        }

        private void btnSad_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnSad.Text;
        }

        private void btnCry_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnCry.Text;
        }

        private void btnThankfull_Click(object sender, EventArgs e)
        {
            rtxbSendingPost.Text += btnThankfull.Text;
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            searchpanel.Visible = false;
        }
    }
}
