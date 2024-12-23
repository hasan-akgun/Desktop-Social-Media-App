using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_media
{
    public class Categories
    {
        public string name { get; set;}
        public string usage_count { get; set; }

    }
    internal class GetCategories
    {
        public List<Categories> Categories { get; private set; }


        public async Task LoadCategoriesAsync()
        {
            Categories = await FetchCategoriesAsync();
        }

        private static async Task<List<Categories>> FetchCategoriesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://link";


                var response = await client.GetAsync(url);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseCate>(jsonString);
                    if (apiResponse.Status == "success")
                    {
                        return apiResponse.Data;
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

    public class ApiResponseCate
    {
        public string Status { get; set; }
        public List<Categories> Data { get; set; }
    }
}
