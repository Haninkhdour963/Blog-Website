using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }

    }
}
