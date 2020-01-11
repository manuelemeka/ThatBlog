using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ThatBlog.Models
{
    public class CommentModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "User")]
        public string commenter { get; set; }

        [Required]
        [Display(Name = "BlogID")]
        public string blogid { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string comment { get; set; }
    }
}