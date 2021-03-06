﻿using System.Web.Mvc;

namespace WEB_BASE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult AccessDenied()
        {
            ViewBag.UrlDenied = Session["UrlDenied"].ToString();
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}