using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Areas.Admin.Models;
using NewsWebApp.Data;
using NewsWebApp.Models;

namespace NewsWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class NewsController : Controller
    {
        private readonly NewsDbContext db;
        public NewsController(NewsDbContext _Db)
        {
            db = _Db;
        }
        public async Task<IActionResult> Index()
        {
            List<News> news = await db.News.Include(n => n.SubCategory)
                                                .Include(n => n.Photos)
                                                        .ToListAsync();


            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            List<Category> Categories = await db.Categories.ToListAsync();
            return View(Categories);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(News news)
        {
            if (ModelState.IsValid)
            {
                News new_news = new News();
                new_news.SubCategoryId = news.SubCategoryId;
                new_news.ShortDesc = news.ShortDesc;
                new_news.Text = news.Text;
                new_news.CreatedDate = DateTime.Now;

                db.News.Add(new_news);

                foreach(var photo in news.PhotoNames)
                {
                    NewsPhoto newsPhoto = new NewsPhoto();
                    newsPhoto.News = new_news;
                    newsPhoto.Photo = photo;
                    db.NewsPhotos.Add(newsPhoto);
                }

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> FillCategories(string id)
        {
            if(id == null)
            {
                return Json(new { status = 400, message = "Bele bir id li category yoxdur!" });
            }

            List<SubCategory> subCategories = await db.SubCategories
                                                        .Where(s => s.CategoryId == Convert.ToInt32(id))
                                                            .ToListAsync();

            return Json(new { data = subCategories,status = 200 });
        }


        [HttpPost]
        public JsonResult AddPhoto()
        {
            List<IFormFile> photos = Request.Form.Files.ToList();

            List<object> photo_infos = new List<object>();

            foreach (var photo in photos)
            {
                string filename = DateTime.Now.ToShortDateString().Replace("/", "") + photo.FileName;
                //create path
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "News", DateTime.Now.ToShortDateString().Replace("/","") + photo.FileName);
                if (System.IO.File.Exists(path))
                {
                    var guid = new Guid();
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "News", guid + DateTime.Now.ToShortDateString().Replace("/", "") + photo.FileName);
                    filename = guid + DateTime.Now.ToShortDateString().Replace("/", "") + photo.FileName;
                }

                //add photo to folder
                using(FileStream stream = new FileStream(path,FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                var  photo_info = new
                {
                    src = "/Uploads/News/" + filename,
                    name = filename
                };
                photo_infos.Add(photo_info);
            }
            return Json(new { status = 200, data = photo_infos });

        }


        [HttpPost]
        public JsonResult DeletePhoto(string filename)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads","News", filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return Json(new { status = 200 });

            }
            else
            {
                return Json(new { status = 400 });
            }
        }
    }
}