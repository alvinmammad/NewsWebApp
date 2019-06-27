using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class NewsTag
    {
        public int Id { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
