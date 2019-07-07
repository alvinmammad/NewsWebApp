using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class NewsReview
    {
        public int Id { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
