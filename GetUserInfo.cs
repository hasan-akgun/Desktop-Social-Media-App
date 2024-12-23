using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace social_media
{
    public class Info
    {
        public string name { get; set; }
        public string bio { get; set; }
        public string pp_id { get; set; }
        public string following_count { get; set; }
        public string follower_count { get; set; }
        public bool is_following { get; set; }
    }

    internal class GetUserInfo
    {
        public Info info { get; private set; }
        public async Task LoadInfoAsync(string loginuser, string targetuser)
        {
            info = await FetchInfoAsync(loginuser, targetuser);
        }
        private static async Task<Info> FetchInfoAsync(string loginuser, string targetuser)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://link.php";


                var values = new Dictionary<string, string>
                {
                    {"loginUser", loginuser},
                    {"targetUser", targetuser},
                };

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseInfo>(responseString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.Data;
                    }
                    else
                    {
                        MessageBox.Show("API çağrısı başarısız: ");
                        return new Info();
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class ApiResponseInfo
    {
        public string Status { get; set; }
        public Info Data { get; set; }
    }
}
