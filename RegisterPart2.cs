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

namespace social_media
{
    public partial class RegisterPart2 : Form
    {
        Login loginform;
        private string avatarid;
        public string username { get; set; }
        private string password;
        private string name;
        public RegisterPart2()
        {
            InitializeComponent();
            loginform = new Login();
            loginform.Hide();
        }

        private void RegisterPart2_Load(object sender, EventArgs e)
        {
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

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (await ChooseAvatarBioUser(username, avatarid, Bio))
            {
                loginform.Show();
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

        private void lblBackLogin_Click(object sender, EventArgs e)
        {
            loginform.Show();
            this.Close();
        }
    }
}
