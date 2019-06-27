using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models.ViewModels
{
    public class HomeModel
    {
        public List<News> SliderNews { get; set; }
        public List<News> LatestNews { get; set; }
        public List<News> PopularNews { get; set; }
        public List<NewsPhoto> NewsPhotos { get; set; }
        public List<News> MostCommenteds { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
