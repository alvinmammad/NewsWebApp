using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models.ViewModels
{
    public class NewsModel
    {
        public List<News> News { get; set; }
        public News SpecificNews { get; set; }
        public List<News> MostCommenteds { get; set; }
        public List<NewsReview> RecentCommenteds { get; set; }
        public List<NewsTag> Tags { get; set; }
    }
}
