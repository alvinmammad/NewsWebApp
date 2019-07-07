using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Core;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.Models.ViewModels;

namespace NewsWebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsDbContext db;
        public NewsController(NewsDbContext _db)
        {
            db = _db;
        }


        public async Task<IActionResult> Index(int? Id, string key,string sinif, bool take)
        {
            //Kateqoriya ve Subkateqoriyalari layoutda doldurmaq
            await LayoutInitializer.FillCategories(db, ViewBag);

            List<News> news = new List<News>();

            //Eger key null xususi bir anlayasia gore yigmaq
            if (key != null)
            {
                //news = await db.News.OrderByDescending(n => n.GetType().GetProperty(key) == null ? n.Comments.GetType().GetProperty(key) : n.GetType().GetProperty(key))
                //                              .Include(n => n.Photos)
                //                                  .Take(take ? 50 : 5)
                //                                     .Include(n => n.Comments)
                //                                        .ToListAsync();

              
                //Viewbag da key ve take deyerlerini saxlamaq
                ViewBag.key = key;
                ViewBag.IsCombine = take;
            }
            else
            {
                return NotFound();
            }

            //Eger id null deyilse xususi xeberi gostermek lazimdir
            News specificNews = await db.News.Where(n => Id != null ? n.Id == Id : false).FirstOrDefaultAsync();

            //Eger Id null deyilse Newstag lari yigmaq lazimdir
            List<NewsTag> tags = await db.NewsTags.Include(n => n.Tag).Where(nt => Id != null ? nt.NewsId == Id : false).ToListAsync();


            //view model duzeltmek
            NewsModel model = new NewsModel()
            {
                News = news,

                MostCommenteds = await db.News
                                            .OrderByDescending(n => n.Comments.Count)
                                                    .Take(5)
                                                        .ToListAsync(),

                RecentCommenteds = await db.NewsReviews
                                                .OrderByDescending(nr => nr.CreatedDate)
                                                        .Include(nr => nr.News)
                                                            .Take(5)
                                                                .ToListAsync(),
                Tags = tags,
                SpecificNews = specificNews
            };
            return View(model);

        }
    }
}