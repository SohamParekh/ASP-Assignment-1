﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Assignment_1.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public User user { get; set; }
    }
}
