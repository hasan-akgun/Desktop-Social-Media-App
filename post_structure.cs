using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace social_media
{
    internal class post_structure
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        Main_Page main_page;
        LikeManager likeManager;
        public post_structure(Main_Page main) 
        {
            main_page = main;
            likeManager = new LikeManager();
            
        }
        public void AddPost(Panel panel, Post post , int i, bool isLiked)
        {
            // RichTextBox oluşturma ve forma ekleme
            RichTextBox postText = new RichTextBox();
            postText.Name = $"text{i}";
            postText.Multiline = true; // Çok satırlı RichTextBox
            postText.ReadOnly = true; // Sadece okunabilir yap
            postText.Width = 650; // RichTextBox genişliği   
            postText.BorderStyle = BorderStyle.None;
            postText.BackColor = Color.WhiteSmoke;
            postText.Margin = new Padding(0, 0, 0, 0);
            postText.Font = new Font("Arial", 15, FontStyle.Regular); // Font ayarı          
            postText.Rtf = post.Text;
            postText.Height = 500; //Satır sayısını sayarken GetLine metodunun doğru çalışması için 
            postText.AutoWordSelection = true;
            postText.ScrollBars = RichTextBoxScrollBars.None;
            int dynamicHeight = DynamicHeight(postText);
            postText.Height = dynamicHeight;

            panel.MouseMove += (sender, e) => HideCaret(postText.Handle);
            postText.MouseClick += (sender, e) => HideCaret(postText.Handle);

            PictureBox avatar = new PictureBox
            {
                Name = post.Username,
                AccessibleName = post.Name,
                Size = new Size(80, 80), // PictureBox boyutları
                SizeMode = PictureBoxSizeMode.Zoom, // Resim boyutlama modu
                Cursor = Cursors.Hand,
            };
            avatar.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(post.pp_id);
            avatar.Click += new EventHandler(Avatar_Click);

            Button like = new Button()
            {
                Width = 27,
                Height = 25,
                BackColor = Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat,
                Name = post.post_id,
                Cursor = Cursors.Hand,
                ImageAlign = ContentAlignment.MiddleCenter,
                AccessibleName = isLiked.ToString(),
                Margin = new Padding(3, 20, 3, 3),
                         
            };
            like.FlatAppearance.BorderSize = 0;
            like.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            like.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            
            if (isLiked == true)
            {
                like.Image = Properties.Resources.liked;
            }
            else
            {
                like.Image = Properties.Resources.like;
            }
            like.Click += new EventHandler(Like_Click);

            Button comment = new Button()
            {
                Width = 27,
                Height = 25,
                BackColor = Color.WhiteSmoke,
                Cursor = Cursors.Hand,
                FlatStyle= FlatStyle.Flat,
                Margin = new Padding(100, 20, 3, 3),
                AccessibleName = "S",
                Name = $"{i}"
                
            };
            comment.Image = Properties.Resources.commentshow;
            comment.FlatAppearance.BorderSize = 0;
            comment.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            comment.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke;
            comment.Click += new EventHandler(Comment_Click);
            

            FlowLayoutPanel postPanel = new FlowLayoutPanel()
            {
                Width = panel.Width - 30,
                BorderStyle = BorderStyle.FixedSingle,
                Height = dynamicHeight + 115,
                Name = $"Post{post.post_id}"
            };




            FlowLayoutPanel avatarPanel = new FlowLayoutPanel()
            {
                Name = "avatarPanel",
                Width = 83,
                Height = 83,
                BorderStyle = BorderStyle.None,
            };


            FlowLayoutPanel labelPanel = new FlowLayoutPanel()
            {
                Width = postPanel.Width - 100,
                Height = postPanel.Height,
                BorderStyle = BorderStyle.None,
            };

            FlowLayoutPanel textPanel = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.None,
                Width = labelPanel.Width,
                Height = dynamicHeight + 60,
            };

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel()
            {
                Width = textPanel.Width,
                Height = 55,
                BorderStyle = BorderStyle.None,
                Name = "butonPanel"

            };

            Label lblName = new Label();
            lblName.Text = post.Name;
            lblName.AutoSize = true;
            lblName.Margin = new Padding(0, 1, 0, 0);
            lblName.Font = new Font("Arial", 15, FontStyle.Bold);

            Label lblUsername = new Label();
            lblUsername.Text = "@"+post.Username;
            lblUsername.AutoSize = true;
            lblUsername.Margin = new Padding(0, 1, 0, 0);
            lblUsername.Font = new Font("Arial", 15, FontStyle.Regular);
            lblUsername.ForeColor = Color.Gray;


            Label lblNumLike = new Label()
            {
                AutoSize = true,
                Text = post.likes_count.ToString(),
                Name = "like",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Margin = new Padding(0, 20, 0, 0)
            };

            Label lblNumcomm = new Label()
            {
                AutoSize = true,
                Text = post.comment_count.ToString(),
                Name = "commentNum",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Margin = new Padding(0, 20, 0, 0)
            };


            int pad = 450-(lblNumLike.Width + lblNumcomm.Width);
            Label lblTime = new Label();
            lblTime.Text = post.created_at;
            lblTime.Width = 200;
            lblTime.Height = 20;
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            lblTime.Margin = new Padding(pad, 30, 0, 0);
            lblTime.Font = new Font("Arial", 10, FontStyle.Regular);
            lblTime.ForeColor = Color.Gray;

            // RichTextBox'ı panelin içine ekle
            panel.Controls.Add(postPanel);
            postPanel.Controls.Add(avatarPanel);
            postPanel.Controls.Add(labelPanel);
            labelPanel.Controls.Add(lblName);
            labelPanel.Controls.Add(lblUsername);
            labelPanel.Controls.Add(textPanel);
            avatarPanel.Controls.Add(avatar);
            textPanel.Controls.Add(postText);
            textPanel.Controls.Add(buttonPanel);
            buttonPanel.Controls.Add(like);
            buttonPanel.Controls.Add(lblNumLike);
            buttonPanel.Controls.Add(comment);
            buttonPanel.Controls.Add(lblNumcomm);
            buttonPanel.Controls.Add(lblTime);


        }

        private int DynamicHeight(RichTextBox richTextBox)
        {
            int lineHeight = richTextBox.Font.Height;
            int lineCount = richTextBox.GetLineFromCharIndex(richTextBox.Text.Length - 1) + 1;
            return (lineCount * lineHeight) + 15; // Satır sayısı * satır yüksekliği + biraz boşluk
        }

        private async void Comment_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            FlowLayoutPanel panel = FindParentPanel(button, "Post");
            int index = int.Parse(button.Name);
            if (button.AccessibleName == "S") 
            {
                await main_page.ShowComm(panel.Name, index, button.AccessibleName);
                button.AccessibleName = "H";
                button.Image = Properties.Resources.commenthide;
            }
            else
            {
                await main_page.ShowComm(panel.Name, index, button.AccessibleName);
                button.AccessibleName = "S";
                button.Image = Properties.Resources.commentshow;
            }
        }
        private void Like_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            likeManager.Like(main_page.loginusername,button.Name);

            FlowLayoutPanel panel = FindParentPanel(button, "butonPanel");
            Label lblLike = panel.Controls[1] as Label;

            int newlike = int.Parse(lblLike.Text);
            if (button.AccessibleName == "False")
            {
                newlike++;
                lblLike.Text = newlike.ToString();
                button.AccessibleName = "True";
                button.Image = Properties.Resources.liked;
            }
            else
            {
                newlike--;
                lblLike.Text = newlike.ToString();
                button.AccessibleName = "False";
                button.Image = Properties.Resources.like;

            }


        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            PictureBox avatar = sender as PictureBox;
            main_page.ClickAvatar(avatar.Name, avatar.AccessibleName);
        }
        private FlowLayoutPanel FindParentPanel(Control control, string keyword)
        {
            // Üst kontrol zincirinde gezinerek FlowLayoutPanel'i bul
            Control parent = control.Parent;
            while (parent != null && !(parent.Name.Contains(keyword)))
            {
                parent = parent.Parent;
            }
            return parent as FlowLayoutPanel;
        }



    }




}
