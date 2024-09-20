using APIClient;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.BlogContext;

namespace BusinessLogic
{
    public class BlogService
    {
        private readonly CNNNewsService _newsService;
        private readonly BlogContext _context;

        public BlogService(CNNNewsService newsService, BlogContext context)
        {
            _newsService = newsService;
            _context = context;
        }
        public async Task FetchAndSaveArticlesAsync()
        {
            var articles = await _newsService.GetLatestNewsAsync();
            foreach (var article in articles)
            {
                if (!_context.Articles.Any(a => a.Title == article.Title))
                {
                    _context.Articles.Add(article);
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task<List<Article>> GetArticlesAsync()
        {

            return await _context.Articles.ToListAsync();
        }
    }
}