using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace social_media
{
    internal class UserProfileStructure
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        Main_Page mainPage;

        public UserProfileStructure(Main_Page main)
        {
            mainPage = main;
        }
        public void AddProfile(Panel panelfoll, User foll)
        {
            string shortbio;
            // RichTextBox oluşturma ve forma ekleme
            RichTextBox profileText = new RichTextBox();
            profileText.Multiline = true; // Çok satırlı RichTextBox
            profileText.ReadOnly = true; // Sadece okunabilir yap
            profileText.Width = 300; // RichTextBox genişliği   
            profileText.BorderStyle = BorderStyle.None;
            profileText.MaxLength = 30;
            profileText.BackColor = Color.WhiteSmoke;
            profileText.Margin = new Padding(0, 0, 0, 0);
            profileText.Font = new Font("Arial", 12, FontStyle.Regular); // Font ayarı          
            profileText.Height = 400; //Satır sayısını sayarken GetLine metodunun doğru çalışması için 
            profileText.Rtf = foll.bio;

            shortbio = profileText.Text;
            if(shortbio.Length >= 30)
            {
                shortbio = shortbio.Substring(0, 27) + "...";
                profileText.Text = shortbio;
            }  

            profileText.AutoWordSelection = true;
            profileText.ScrollBars = RichTextBoxScrollBars.None;
            int dynamicheight = DynamicHeight(profileText);
            profileText.Height = dynamicheight;
            profileText.Name = "comment";

            mainPage.MouseHover += (sender, e) => HideCaret(profileText.Handle);
            profileText.MouseClick += (sender, e) => HideCaret(profileText.Handle);

            PictureBox avatar = new PictureBox
            {
                Name = foll.username,
                Size = new Size(64, 64), // PictureBox boyutları
                SizeMode = PictureBoxSizeMode.Zoom, // Resim boyutlama modu
                Cursor = Cursors.Hand,
                AccessibleName = foll.name,
            };
            avatar.Click += Avatar_Click;
            avatar.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(foll.pp_id);


            

            FlowLayoutPanel profilePanel = new FlowLayoutPanel()
            {
                Width = 430,
                BorderStyle = BorderStyle.FixedSingle,
                Height = dynamicheight+42,
                Margin = new Padding(3, 3, 3, 3)
            };




            FlowLayoutPanel avatarPanel = new FlowLayoutPanel()
            {
                Width = 67,
                Height = 67,
                BorderStyle = BorderStyle.None,
            };


            FlowLayoutPanel labelPanel = new FlowLayoutPanel()
            {
                Width = profilePanel.Width - 84,
                Height = profilePanel.Height,
                BorderStyle = BorderStyle.None,
            };

            FlowLayoutPanel textPanel = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.None,
                Width = labelPanel.Width,
                Height = dynamicheight+5,
            };


            Label lblName = new Label();
            lblName.Text = foll.name;
            lblName.AutoSize = true;
            lblName.Margin = new Padding(0, 1, 0, 0);
            lblName.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblUsername = new Label();
            lblUsername.Text = "@"+ foll.username;
            lblUsername.AutoSize = true;
            lblUsername.Margin = new Padding(0, 1, 0, 0);
            lblUsername.Font = new Font("Arial", 12, FontStyle.Regular);
            lblUsername.ForeColor = Color.Gray;

            panelfoll.Controls.Add(profilePanel);
            profilePanel.Controls.Add(avatarPanel);
            profilePanel.Controls.Add(labelPanel);
            labelPanel.Controls.Add(lblName);
            labelPanel.Controls.Add(lblUsername);
            labelPanel.Controls.Add(textPanel);
            avatarPanel.Controls.Add(avatar);
            textPanel.Controls.Add(profileText);
        }
        private void Avatar_Click(object sender, EventArgs e)
        {
            PictureBox avatar = sender as PictureBox;
            mainPage.ClickAvatar(avatar.Name, avatar.AccessibleName);
        }
        private int DynamicHeight(RichTextBox richTextBox)
        {
            int lineHeight = richTextBox.Font.Height;
            int lineCount = richTextBox.GetLineFromCharIndex(richTextBox.Text.Length - 1) + 1;
            return (lineCount * lineHeight) + 10; // Satır sayısı * satır yüksekliği + biraz boşluk
        }
    }
}
