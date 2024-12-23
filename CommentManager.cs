using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_media
{
    public class Comment
    {
        public string comment_id { get; set; }
        public string username { get; set; }
        public string pp_id { get; set; }
        public string name { get; set; }
        public string content { get; set; }

        public string created_at { get; set; }
        //public int likes_count { get; set; }
        //public bool isLiked { get; set; } = false;
    }
    internal class CommentManager
    {
        public List<Comment> Comments { get; private set; }
        public CommentManager()
        {
        }

        public async Task LoadCommsAsync(int coef, string postId)
        {
            Comments = await FetchCommsAsync(coef, postId);
        }
        public async Task<bool> SendComm(string username, string postid, RichTextBox richTextBox)
        {
            using (HttpClient client = new HttpClient())
            {
                string rtfContent = richTextBox.Rtf;
                // API'ya gönderilecek veriler
                var values = new Dictionary<string, string>
                {
                    { "loginUser", username },
                    { "postId", postid },
                    { "commentContent", rtfContent },
                };

                // Verileri form-encoded olarak gönder
                var content = new FormUrlEncodedContent(values);

                // API'ya POST isteği gönder
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
                            MessageBox.Show("Comment submitted!");
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

                return false;
            }
        }

        private static async Task<List<Comment>> FetchCommsAsync(int coef, string postId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://link.php?katsayi={coef}";


                var values = new Dictionary<string, string>
                {
                    {"postId", postId},
                };

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseComm>(responseString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.Data;
                    }
                    else
                    {
                        MessageBox.Show("API çağrısı başarısız: ");
                        return new List<Comment>();
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class ApiResponseComm
    {
        public string Status { get; set; }
        public List<Comment> Data { get; set; }
    }
}
