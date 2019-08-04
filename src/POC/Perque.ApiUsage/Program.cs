using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Perque.ApiUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var hr = new HurriyetApi();
            Task.Run(async () =>
            {
                var articles = await hr.GetArticles();
                foreach (var article in articles)
                {
                    Console.WriteLine(article.Title);
                }
            });

            Console.ReadKey();
        }
    }

    class HurriyetApi
    {
        public async Task<List<HotArticle>> GetArticles()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.hurriyet.com.tr/v1/"),

            };
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("apikey", "24a5be4fa4d34ca8831b1fdb17a99f4a");
            var response = await client.GetAsync("articles?$select=Title");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<HotArticle>>(content);
        }
    }

    class HotArticle
    {
        public string Title { get; set; }
    }
}
