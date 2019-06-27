using Microsoft.EntityFrameworkCore;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Data
{
    public class NewsDbContext:DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> option) : base(option) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsPhoto> NewsPhotos { get; set; }
        public DbSet<NewsReview> NewsReviews { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
