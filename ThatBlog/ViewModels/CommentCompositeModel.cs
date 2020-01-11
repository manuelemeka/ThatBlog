using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThatBlog.Models;

namespace ThatBlog.ViewModels
{
    public class CommentCompositeModel
    {
        public BlogModel Blog { get; set; }
        public List<CommentModel> BlogComment { get; set; }
        
    }
}