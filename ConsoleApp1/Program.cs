// Использование C# для GET запроса
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://localhost:7041/posts");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                List<Post>? real = JsonConvert.DeserializeObject<List<Post>>(json);
            }
        }
    }
}


/* Использование C# для POST запроса
using System.Text;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
                Post newPost = new Post()
                {
                    Title = "Test Post",
                    Body = "Hello world!",
                    UserId = 44
                };
                string newPostText = JsonConvert.SerializeObject(newPost);
                var payload = new StringContent(newPostText, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
*/