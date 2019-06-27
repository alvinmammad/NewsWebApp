using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Core
{
    public static class LayoutInitializer
    {
        public async static Task FillCategories(NewsDbContext db,dynamic ViewBag)
        {
            ViewBag.Categories = await db.Categories.ToListAsync();
            ViewBag.SubCategories = await db.SubCategories.ToListAsync();
            ViewBag.Settings = await db.Settings.ToListAsync();

            ViewBag.LatestNews = await db.News
                                                .OrderByDescending(n => n.CreatedDate)
                                                        .Take(5)
                                                           .Include(n => n.SubCategory)
                                                             .ThenInclude(s => s.Category)
                                                                .ToListAsync();
        }
    }
}
