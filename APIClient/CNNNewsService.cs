using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.BlogContext;



namespace APIClient
{
    public class CNNNewsService
    {
        private readonly HttpClient _httpClient;

        public CNNNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Article>> GetLatestNewsAsync()
        {
            //API from this  https://newsapi.org/account

            var response = await _httpClient.GetFromJsonAsync<CNNNewsResponse>("aa12ec824ce745c08e9994f6e2291f23");
            return response.Articles.Select(a => new Article
            {
                Title = a.Title,
                Content = a.Description,
                ImageUrl = a.UrlToImage,
                PublishedAt = a.PublishedAt
            }).ToList();
        }

        public class CNNNewsResponse
        {
            public List<NewsArticle> Articles { get; set; }
        }
        public class NewsArticle
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string UrlToImage { get; set; }
            public DateTime PublishedAt { get; set; }
        }

    }


}
