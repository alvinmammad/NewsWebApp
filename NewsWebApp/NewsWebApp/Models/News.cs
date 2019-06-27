using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class News
    {
        
        public int Id { get; set; }
        public string ShortDesc { get; set; }
        public string Text { get; set; }
        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public bool Status { get; set; }

        public  List<NewsReview> Comments { get; set; }
    }
}
