using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace social_media
{
    internal class CommentStructure
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        Main_Page mainPage;

        public CommentStructure(Main_Page main)
        {
            mainPage = main;

        }
        public void AddComm(Panel panelcom, Comment comm)
        {
            // RichTextBox oluşturma ve forma ekleme
            RichTextBox commText = new RichTextBox();
            commText.Multiline = true; // Çok satırlı RichTextBox
            commText.ReadOnly = true; // Sadece okunabilir yap
            commText.Width = 530; // RichTextBox genişliği   
            commText.BorderStyle = BorderStyle.None;
            commText.BackColor = Color.WhiteSmoke;
            commText.Margin = new Padding(0, 0, 0, 0);
            commText.Font = new Font("Arial", 12, FontStyle.Regular); // Font ayarı          
            commText.Height = 500; //Satır sayısını sayarken GetLine metodunun doğru çalışması için 
            commText.Rtf = comm.content;
            commText.AutoWordSelection = true;
            commText.ScrollBars = RichTextBoxScrollBars.None;
            commText.Name = "comment";
            int dynamicHeight = DynamicHeight(commText);
            commText.Height = dynamicHeight;

            commText.MouseClick += (sender, e) => HideCaret(commText.Handle);

            PictureBox avatar = new PictureBox
            {
                Name = comm.username,
                Size = new Size(64, 64), // PictureBox boyutları
                SizeMode = PictureBoxSizeMode.Zoom, // Resim boyutlama modu
                Cursor = Cursors.Hand,
                AccessibleName= comm.name,
            };
            avatar.Click += Avatar_Click;
            avatar.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(comm.pp_id);

;

            FlowLayoutPanel commPanel = new FlowLayoutPanel()
            {
                Width = 640,
                BorderStyle = BorderStyle.FixedSingle,
                Height = dynamicHeight + 92,
                Margin = new Padding(80,3,3,3)
            };




            FlowLayoutPanel avatarPanel = new FlowLayoutPanel()
            {
                Width = 67,
                Height = 67,
                BorderStyle = BorderStyle.None,
            };


            FlowLayoutPanel labelPanel = new FlowLayoutPanel()
            {
                Width = commPanel.Width - 84,
                Height = commPanel.Height,
                BorderStyle = BorderStyle.None,
            };

            FlowLayoutPanel textPanel = new FlowLayoutPanel()
            {
                BorderStyle = BorderStyle.None,
                Width = labelPanel.Width,
                Height = dynamicHeight + 48,
            };

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel()
            {
                Width = textPanel.Width,
                Height = 44,
                BorderStyle = BorderStyle.None

            };

            Label lblName = new Label();
            lblName.Text = comm.name;
            lblName.AutoSize = true;
            lblName.Margin = new Padding(0, 1, 0, 0);
            lblName.Font = new Font("Arial", 12, FontStyle.Bold);

            Label lblUsername = new Label();
            lblUsername.Text = "@"+comm.username;
            lblUsername.AutoSize = true;
            lblUsername.Margin = new Padding(0, 1, 0, 0);
            lblUsername.Font = new Font("Arial", 12, FontStyle.Regular);
            lblUsername.ForeColor = Color.Gray;

            Label lblTime = new Label();
            lblTime.Text = comm.created_at;
            lblTime.AutoSize = true;
            lblTime.Margin = new Padding(415, 24, 0, 0);
            lblTime.Font = new Font("Arial", 8, FontStyle.Regular);
            lblTime.ForeColor = Color.Gray;

            panelcom.Controls.Add(commPanel);
            commPanel.Controls.Add(avatarPanel);
            commPanel.Controls.Add(labelPanel);
            labelPanel.Controls.Add(lblName);
            labelPanel.Controls.Add(lblUsername);
            labelPanel.Controls.Add(textPanel);
            avatarPanel.Controls.Add(avatar);
            textPanel.Controls.Add(commText);
            textPanel.Controls.Add(buttonPanel);
            buttonPanel.Controls.Add(lblTime);

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
