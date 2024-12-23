using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_media
{
    public class User
    {
        public string username { get; set; }
        public string pp_id { get; set; }
        public string name { get; set; }
        public string bio { get; set; }

    }
    internal class GetUsers
    {
        public List<User> Users { get; private set; }


        public async Task LoadFollsAsync(string loginuser, string follType)
        {
            Users = await FetchFollsAsync(loginuser, follType);
        }

        private static async Task<List<User>> FetchFollsAsync(string loginuser, string follType)
        {
            using (HttpClient client = new HttpClient())
            {
                string url =$"https://link/{follType}.php";


                var values = new Dictionary<string, string>
                {
                    {"loginUser", loginuser},
                };

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseFollower>(responseString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.Data;
                    }
                    else
                    {
                        MessageBox.Show("API çağrısı başarısız: ");
                        return new List<User>();
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class ApiResponseFollower
    {
        public string Status { get; set; }
        public List<User> Data { get; set; }
    }
}
