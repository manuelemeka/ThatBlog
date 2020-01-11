using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ThatBlog.Models
{
    public class BlogModel
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Blog")]
        [MinLength(160)]
        public string blog { get; set; }

        [Required]
        [Display(Name = "photo")]
        public string photo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Author")]
        public string author { get; set; }

    }


}