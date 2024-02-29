using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var about = context.Abouts.Find(id);
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(About about)
        {
            var abt = context.Abouts.Find(about.AboutId);
            abt.AboutBigImageUrl = about.AboutBigImageUrl;
            abt.AboutSmallImageUrl = about.AboutSmallImageUrl;
            abt.Header = about.Header;
            abt.Title = about.Title;
            abt.Description = about.Description;
            context.SaveChanges();
            return View();
        }
    }
}