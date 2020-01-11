using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThatBlog.Models;
using ThatBlog.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.Entity;

namespace ThatBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(string report)
        {

            var uname = User.Identity.GetUserName();
            var db = new ApplicationDbContext();
            List<BlogModel> mbm = db.Blogs.Where(m => m.author == uname ).ToList<BlogModel>();
            List<BlogModel> pbm = db.Blogs.Where(m => m.author != uname).Take(10).ToList<BlogModel>();

            var compositeModel = new CompositeModel
            {
                UserBlog = mbm,
                DomainBlog =pbm
            };
            ViewBag.Report = report;
            return View(compositeModel);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id, string report)
        {
            if (ModelState.IsValid)
            {

                var db = new ApplicationDbContext();
                BlogModel bm = db.Blogs.Where(m =>m.id ==  id).FirstOrDefault<BlogModel>();
                List<CommentModel> bcm = db.Comment.Where(cm => cm.blogid == (""+id)).ToList<CommentModel>();
                CommentCompositeModel ccModel = new CommentCompositeModel
                {
                    Blog = bm,
                    BlogComment = bcm
                };



                ViewBag.Report = report;
                return View(ccModel);
            }

            else
            {
                return View();
            }
            
        }
        // POST: Blog/Create
        [HttpPost]
        public ActionResult Details(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var blogID =  collection.Get("bid");
                    var db = new ApplicationDbContext();
                    var mod = db.Comment.Add(new CommentModel { comment = collection.Get("comment"),blogid= blogID, commenter = User.Identity.GetUserName() });
                    db.SaveChanges();


                    
                    return RedirectToAction("Details", "Blog", new { id = blogID, report = "Thanks for Dropping a Comment" });
                }

                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

            // GET: Blog/Create
            public ActionResult Create()
        {

            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(BlogModel model)//FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    var db = new ApplicationDbContext();
                   var mod =  db.Blogs.Add(new BlogModel { title = model.title, blog = model.blog, photo = model.photo, author = User.Identity.GetUserName() });
                    db.SaveChanges();
                    return RedirectToAction("Details", "Blog",new { id= mod.id, report="Blog Posted Successfully"} );
                }

                else {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)


        {
            var db = new ApplicationDbContext();
            var bm = db.Blogs.Where(m => m.id == id).FirstOrDefault<BlogModel>();
            return View(((BlogModel)bm));
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,  BlogModel mod)
        {
            try
            {
                
                    // TODO: Add update logic here
                    var db = new ApplicationDbContext();
                    var bid = db.Blogs.FirstOrDefault(r => r.id == id);
                    // AND UPDATE r.resumeId with viewModel.ResumeId
                    if (bid != null)
                    {
                        bid.id = mod.id;
                        bid.title = mod.title;
                        bid.blog = mod.blog;
                        bid.photo = mod.photo;
                        db.Entry(bid).State = EntityState.Modified;
                        db.SaveChanges();
                        
                    }
                    return RedirectToAction("Details", "Blog", new { id = id, report = "Blog Updated Successfully"});


                
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                var db = new ApplicationDbContext();
                var bm = db.Blogs.Where(m => m.id == id).FirstOrDefault<BlogModel>();




                return View(((BlogModel)bm));
            }

            else
            {
                return View();
            }
            
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var db = new ApplicationDbContext();
                var bm = db.Blogs.Where(m => m.id == id).FirstOrDefault<BlogModel>();
                db.Blogs.Remove(bm);
                db.SaveChanges();
                return RedirectToAction("Index" , new { report= "Blog Deleted Successfully"});
            }
            catch
            {
                return View();
            }
        }
    }
}
