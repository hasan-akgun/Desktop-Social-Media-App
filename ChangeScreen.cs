using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace social_media
{
    public partial class ChangeScreen : Form
    {
        GetUserInfo info;
        Main_Page main_Page;

        private string avatarid;
        private string loginuser;
        public ChangeScreen(Main_Page main)
        {
            InitializeComponent();
            info = new GetUserInfo();
            loginuser = main.loginusername;
            main_Page = main;
        }

        private async void ChangeScreen_Load(object sender, EventArgs e)
        {
            await info.LoadInfoAsync(loginuser, loginuser);
            avatar.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(info.info.pp_id);
            Bio.Rtf = info.info.bio;
            Bio.KeyDown += Bio_KeyDown;
            for (int i = 1; i <= 117; i++)
            {
                string imageName = $"{i}";

                // Dinamik olarak resme eriş
                var image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(imageName);

                // Resim null ise hata vermemek için kontrol ekleyin


                PictureBox pictureBox = new PictureBox()
                {
                    Width = 80,
                    Height = 80,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.None,
                    Name = imageName,
                    Image = image,
                    Cursor = Cursors.Hand,
                };
                avatarpanel.Controls.Add(pictureBox);
                pictureBox.Click += new EventHandler(Avatar_Click);
            }
        }

        private void Avatar_Click(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            avatar.Image = picture.Image;
            avatarid = picture.Name;
        }

        private void Bio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private async void btnChange_Click(object sender, EventArgs e)
        {
            if (await ChooseAvatarBioUser(loginuser, avatarid, Bio))
            {
                main_Page.Enabled = true;
                main_Page.Show();
                main_Page.Activate();
                this.Close();
            }
        }
        private async Task<bool> ChooseAvatarBioUser(string username, string ppId, RichTextBox bio)
        {
            string bioContent = bio.Rtf;
            using (HttpClient client = new HttpClient())
            {
                // API'ya gönderilecek veriler
                var values = new Dictionary<string, string>
                {
                    { "loginUser", username },
                    { "ppId", ppId },
                    { "bioContent", bioContent },
                };

                // Verileri form-encoded olarak gönder
                var content = new FormUrlEncodedContent(values);
                try
                {
                    var response = await client.PostAsync("https://link.php", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // API yanıtını oku
                        var responseString = await response.Content.ReadAsStringAsync();
                        try
                        {
                            // Yanıtı dinamik olarak JSON ayrıştır
                            dynamic responseObject = JsonConvert.DeserializeObject(responseString);

                            if (responseObject.status == "success")
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show((string)responseObject.message);
                            }
                        }
                        catch (JsonReaderException ex)
                        {
                            MessageBox.Show("JSON Ayrıştırma Hatası: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("API çağrısı başarısız oldu. Durum kodu: " + response.StatusCode);
                    }
                }
                catch
                {
                    MessageBox.Show("Bağlantı Hatası");
                    return false;
                }
                // API'ya POST isteği gönder


                return false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Bio.Clear();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            main_Page.Enabled = true;
            main_Page.Show();
            main_Page.Activate();
            this.Close();
        }
    }
}
