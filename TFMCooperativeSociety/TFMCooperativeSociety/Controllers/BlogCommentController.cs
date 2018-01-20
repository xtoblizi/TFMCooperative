using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFMCooperativeSociety.Models;
using TFMCooperativeSociety.Models.ViewModels;

namespace TFMCooperativeSociety.Controllers
{
    public class BlogCommentController : Controller
    {

        private TFMCooperativeDB db = new TFMCooperativeDB();
        public ActionResult Index()
        {

            BlogCommentViewModel Bcm = new BlogCommentViewModel();
            Bcm.Blog = GetBlogModel();
            Bcm.Comments = GetCommentModel();

            return View(Bcm);
        }


        public ActionResult IndexTuple()
        {

            var TupleBCM = new Tuple<Blog, List<Comment>>(GetBlogModel(), GetCommentModel());

            return View(TupleBCM);
        }
        // GET: BlogComment/Details/5
        public Blog GetBlogModel()
        {
            Blog b = new Blog()
            {
                BlogId = 1,
                BlogTitle = "Mvc Blog",
                Description = "this is a blog",
                DateCreated = DateTime.Now
            };
            return (b);
        }

        // GET: BlogComment/Create
        public List<Comment> GetCommentModel()
        {
            List<Comment> clist = new List<Comment>
            {
                new Comment() { CommentId = 1,Message = "Xto Speaks",CommentBy = "XtoBoss" ,BlogId = 1},
                new Comment() {CommentId = 2, Message = "Frmi speaks too", CommentBy = "Femi",BlogId = 1},
                new Comment() {CommentId = 3,Message="Mr Princeton Speaks",CommentBy = "Mr Princeton",BlogId = 1}

            };



            return clist;
        }

        // POST: BlogComment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogComment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogComment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogComment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogComment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
