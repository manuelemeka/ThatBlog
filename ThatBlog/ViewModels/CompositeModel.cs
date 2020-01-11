using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThatBlog.Models;

namespace ThatBlog.ViewModels
{
    public class CompositeModel
    {
        public List<BlogModel> UserBlog { get; set; }
        public List<BlogModel> DomainBlog { get; set; }
    }
}