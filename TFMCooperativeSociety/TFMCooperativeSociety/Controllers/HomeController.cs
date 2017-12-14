using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TFMCooperativeSociety.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TestPage2()
        {
            return View();
        }
        public ActionResult TestPage()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to TFMCooperative Society Portal.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "You can reach us on via the following means.";

        //    return View();
        //}

        public PartialViewResult _MemberDashBoard()
        {
            var user = User.Identity.Name;
            ViewBag.Message = "Helllo " + user +""+ "! You are to be a member of TFMCooperative Society";
            return PartialView();
        }

        public PartialViewResult _AdminDashBoard()
        {
            var user = User.Identity.Name;
            ViewBag.Message = "Helllo " + user + "" + "! You are to be a member of TFMCooperative Society";
            return PartialView();
        }

        [Authorize]
        public ActionResult DashBoard()
        {

            return View();
        }
    }
}