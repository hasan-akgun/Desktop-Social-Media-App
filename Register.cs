using System.Text.RegularExpressions;
using Newtonsoft.Json;
namespace social_media
{
    public partial class Register : Form
    {
        Login loginform;
        RegisterPart2 part2;
        private string username;
        private string password;
        private string name;
        public Register()
        {
            InitializeComponent();
            txtPassword.KeyPress += TextBox_KeyPress;
            txtConfirm.KeyPress += TextBox_KeyPress;
        }
        private void Register_Load(object sender, EventArgs e)
        {
            part2 = new RegisterPart2();
            part2.Hide();
            loginform = new Login();
        }

        private void getStarted_Click(object sender, EventArgs e)
        {

        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            name = txtName.Text.Trim();
            password = txtPassword.Text;
            username = txtUsername.Text.Trim();
            part2.username = username;

            // GÝRDÝLERÝN GEÇERLÝ OLUP OLMADIÐININ KONTROLÜ
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please Enter ID, Name and Password!");
                return;
            }
            else if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("ID can not include special characters!");
                return;
            }
            else if (name.Length > 20)
            {
                MessageBox.Show("Username must be below 20 character!");
                return;
            }
            else if (password.Length < 7)
            {
                MessageBox.Show("Password must be contain at least 8 characters!");
                return;
            }
            else if (txtConfirm.Text != txtPassword.Text)
            {
                MessageBox.Show("Check the password!");
                return;
            }
            if (await RegisterUser(username, password, name))
            {
                this.Hide();
                part2.Show();
            }
            
            
        }

            //ÞÝFRE GÖSTER/GÝZLE
            private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !(txtPassword.UseSystemPasswordChar);
            txtConfirm.UseSystemPasswordChar = !(txtConfirm.UseSystemPasswordChar);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtConfirm.Text = "";
        }

        private void lblBackLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform.Show();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Boþluk karakteri tespit edilirse iþlemi iptal etme
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true; // Boþluk karakterini iptal et
            }
        }


        private async Task<bool> RegisterUser(string username, string password, string name)
        {
            this.Enabled = false;
            using (HttpClient client = new HttpClient())
            {
                // API'ya gönderilecek veriler
                var values = new Dictionary<string, string>
                {
                    { "loginUser", username },
                    { "loginName", name },
                    { "loginPass", password },
                };

                // Verileri form-encoded olarak gönder
                var content = new FormUrlEncodedContent(values);
                try
                {
                    var response = await client.PostAsync("https://link.php", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // API yanýtýný oku
                        var responseString = await response.Content.ReadAsStringAsync();

                        try
                        {
                            // Yanýtý dinamik olarak JSON ayrýþtýr
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
                            MessageBox.Show("JSON Ayrýþtýrma Hatasý: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("API çaðrýsý baþarýsýz oldu. Durum kodu: " + response.StatusCode);
                    }
                }
                catch
                {
                    MessageBox.Show("Baðlantý Hatasý");
                    return false;
                }
                // API'ya POST isteði gönder
                

                return false;
            }
        }

    }
}
