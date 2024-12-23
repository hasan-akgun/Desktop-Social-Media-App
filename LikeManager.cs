using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;


namespace social_media
{
    internal class LikeManager
    {
        public async Task<bool> Like(string username, string postid)
        {
            using (HttpClient client = new HttpClient())
            {
                // API'ya gönderilecek veriler
                var values = new Dictionary<string, string>
                {
                    { "loginUser", username },
                    { "postId", postid }
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
                }
                return false;
            }
        }
    }
}
