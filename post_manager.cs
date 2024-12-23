using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Text;

namespace social_media
{
    public class Post
    {
        public string post_id { get; set; }
        public string Username { get; set; }
        public string pp_id { get; set; }
        public string Name { get; set; }
        public string created_at { get; set; }
        public string Text { get; set; }
        public int likes_count {  get; set; }
        public int comment_count { get; set; }
        public bool isLiked {  get; set; } = false;
        public bool isShown { get; set; } = false;

    }
    internal class PostManager
    {
        public List<Post> Posts { get; private set; }
        public int coef { get; set; } = 0;
        public PostManager()
        {
        }

        public async Task LoadPostsAsync(string username, string targetUser, string postType)
        {
            Posts = await FetchPostsAsync(coef, username, targetUser, postType);
        }
        public async Task<bool> SendPost(string username, RichTextBox richTextBox)
        {
            using (HttpClient client = new HttpClient())
            {
                string rtfContent = richTextBox.Rtf;
                // API'ya gönderilecek veriler
                var values = new Dictionary<string, string>
                {
                    { "loginUser", username },
                    { "postContent", rtfContent },
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
        private static async Task<List<Post>> FetchPostsAsync(int coef, string username, string targetUser, string postType)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://link/Posts/{postType}.php?katsayi={coef}";
                var values = new Dictionary<string, string>
                    {
                    };
                if (postType == "GetUsersPosts")
                {
                     values = new Dictionary<string, string>
                     {
                        { "loginUser", username },
                        {"targetUser", targetUser },

                     };
                }
                else if (postType == "GetCategoriesPosts")
                {
                    values = new Dictionary<string, string>
                     {
                        { "loginUser", username },
                        {"categoryName", targetUser },
                     };
                }
                else
                {
                    values = new Dictionary<string, string>
                    {
                        { "loginUser", username },
                    };
                }
                
                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.Data;                  
                    }
                    else
                    {
                        MessageBox.Show("API çağrısı başarısız: ");
                        return new List<Post>();
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        
    }

    public class ApiResponse
    {
        public string Status { get; set; }
        public List<Post> Data { get; set; }
    }
}

