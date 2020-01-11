using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThatBlog.Models;
using Microsoft.AspNet.Identity;

namespace ThatBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var uname = User.Identity.GetUserName();
            //var db = new ApplicationDbContext();
            //List<BlogModel> pbm = db.Blogs.Where(m => m.author != uname).Take(3).ToList<BlogModel>();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}