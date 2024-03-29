﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<NewsReview> Comments { get; set; }
        public List<NewsTag> Tags { get; set; }
        public  List<NewsPhoto> Photos { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        [NotMapped]
        public List<string> PhotoNames { get; set; }
    }
}
