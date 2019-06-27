using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class NewsPhoto
    {
        public int Id { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
        public string Photo { get; set; }
    }
}
