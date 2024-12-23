using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace social_media
{

    internal class Search
    {
        public List<User> UserSearched { get; private set; }
        public List<Categories> CategorySearched { get; private set; }

        public async Task LoadUserSearchedAsync(string query)
        {
            UserSearched = await FetchUserSearchedAsync(query);
        }

        public async Task LoadCategorySearchedAsync(string query)
        {
            CategorySearched = await FetchCategorySearchedAsync(query);
        }

        private static async Task<List<User>> FetchUserSearchedAsync(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://link.php";

                var values = new Dictionary<string, string>
                {
                    { "query", query},
                };
                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseSearch>(jsonString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.users;
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

        private static async Task<List<Categories>> FetchCategorySearchedAsync(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://oasisgamequizium.shop/OOPProject/GetSearch.php";

                var values = new Dictionary<string, string>
                {
                    { "query", query},
                };
                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseSearch>(jsonString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.categories;
                    }
                    else
                    {
                        MessageBox.Show("API çağrısı başarısız: ");
                        return new List<Categories>();
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class ApiResponseSearch
    {
        public string Status { get; set; }
        public List<User> users { get; set; }
        public List<Categories> categories { get; set; }
    }
}
