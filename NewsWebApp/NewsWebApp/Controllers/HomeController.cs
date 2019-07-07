using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Core;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.Models.ViewModels;

namespace NewsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsDbContext db;
        public HomeController(NewsDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            await LayoutInitializer.FillCategories(db, ViewBag);

            List<News> popular_news = await db.News
                                                .OrderByDescending(n => n.ViewCount)
                                                        .Take(10)
                                                            .Include(n => n.SubCategory)
                                                             .ThenInclude(s => s.Category)
                                                                 .ToListAsync();

            List<News> latest_news = await db.News
                                                .OrderByDescending(n => n.CreatedDate)
                                                        .Take(5)
                                                           .Include(n => n.SubCategory)
                                                             .ThenInclude(s => s.Category)
                                                                .ToListAsync();

            List<News> slider_news = new List<News>();

            List<Category> categories = await db.Categories.ToListAsync();
            foreach (var category in categories)
            {
                var news = await db.News.OrderByDescending(n => n.CreatedDate)
                                              .Where(n => n.SubCategory.Category.Id == category.Id)
                                                    .Include(n => n.SubCategory)
                                                             .ThenInclude(s => s.Category)
                                                                        .FirstOrDefaultAsync();
                if (news != null)
                    slider_news.Add(news);
            }

            List<NewsPhoto> photos = await db.NewsPhotos.ToListAsync();


           
            HomeModel model = new HomeModel()
            {
                PopularNews = popular_news,
                LatestNews = latest_news,
                SliderNews = slider_news,
                NewsPhotos = photos,
                Tags = await db.Tags.ToListAsync(),
                MostCommenteds = await db.News.OrderByDescending(n=>n.Comments.Count).Take(5).ToListAsync()
            };

            return View(model);
        }

    }
}