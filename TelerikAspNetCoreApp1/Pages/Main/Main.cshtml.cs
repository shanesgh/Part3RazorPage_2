using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace TelerikAspNetCoreApp1.Pages.Main
{
    public class MainModel : PageModel
    {
        private readonly MyHttpClient _httpClient;

        public MainModel()
        {
            _httpClient = new MyHttpClient();
        }

        public List<MyData> DataList { get; set; }

        public async Task OnGetAsync()
        {
            // Call the method to retrieve JSON data
            var json_data = await _httpClient.GetDummyJsonDataAsync();

            // Deserialize JSON data into a list of MyData objects
            DataList = JsonSerializer.Deserialize<List<MyData>>(json_data);
        }
    }

    public class MyData
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class MyHttpClient
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string base_url = "https://jsonplaceholder.typicode.com"; 

        public async Task<string> GetDummyJsonDataAsync()
        {
            try
            {
                string endpoint = "/todos";

                HttpResponseMessage response = await client.GetAsync(base_url + endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Content {jsonContent}");
                    return jsonContent;
                }
                else
                {
                    Console.WriteLine($"Fetch Error {base_url + endpoint}. Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
