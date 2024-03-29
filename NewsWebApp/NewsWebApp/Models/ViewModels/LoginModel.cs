﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string UsernameEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPresistent { get; set; }
    }
}
