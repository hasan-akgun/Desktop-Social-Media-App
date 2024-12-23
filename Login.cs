using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace social_media
{

    public partial class Login : Form
    {
        Register registerform;
        public string Username { get; set; }
        private bool connected = true;
        public Login()
        {
            InitializeComponent();
            txtPassword.KeyPress += TextBox_KeyPress;
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            registerform = new Register();
            gifloading.Visible = false;
            gifloading.Enabled = false;
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerform.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            LoadingScreen(true);
            // Kullanıcı adı ve şifreyi kontrol et
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                LoadingScreen(false);
                MessageBox.Show("Please enter username and password!");
                this.Enabled = true;
                return;
            }

            // Kullanıcı doğrulama
            if (await ValidateUser(username, password))
            {
                LoadingScreen(false);
                Username = username;
                Main_Page main_Page = new Main_Page(this);
                main_Page.Show();
                this.Hide();
            }
            else if (connected)
            {
                LoadingScreen(false);
                MessageBox.Show("Invalid username or password!");
                txtPassword.Clear();
                txtUsername.Clear();
            }
            else
            {
                LoadingScreen(false);
                MessageBox.Show("Connection Error");
            }
        }

        private void LoadingScreen(bool on)
        {
            lblCreateAccount.Enabled = !on;
            lblPassword.Enabled = !on;
            lblLogin.Enabled = !on;
            lblDontHave.Enabled = !on;
            lbUsername.Enabled = !on;
            txtPassword.Enabled = !on;
            txtUsername.Enabled = !on;
            chkPassword.Enabled = !on;
            btnClear.Enabled = !on;
            btnLogin.Enabled = !on;
            gifloading.Enabled = on;
            gifloading.Visible = on;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boşluk karakteri tespit edilirse işlemi iptal etme
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; // Boşluk karakterini iptal et
            }
        }
        // Kullanıcıyı doğrulayan fonksiyon
        private async Task<bool> ValidateUser(string id, string password)
        {
            connected = true;
            using (HttpClient client = new HttpClient())
            {
                // API'ya gönderilecek veriler
                var values = new Dictionary<string, string>
                {
                    { "loginUser", id },
                    { "loginPass", password }
                };

                // Verileri form-encoded olarak gönder
                var content = new FormUrlEncodedContent(values);
                // API'ya POST isteği gönder
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

                }
                catch
                {
                    MessageBox.Show("hata");
                    connected = false;
                    
                }           
                return false;
            }
        }
    }
}
