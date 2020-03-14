using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Assignment_1.Models
{
    public class SharePost
    {
        [Key]
        public int Share_post_id { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public Post post { get; set; }
    }
}
