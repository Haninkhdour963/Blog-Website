﻿
namespace DataAccess
{
    public partial class BlogContext
    {
        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string ImageUrl { get; set; }
            public DateTime PublishedAt { get; set; }

        }

    }
}
