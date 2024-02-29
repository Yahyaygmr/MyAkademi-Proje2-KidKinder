using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminFeatureController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var feature = context.Features.Find(id);
            return View(feature);
        }
        [HttpPost]
        public ActionResult Index(Feature feature)
        {
            var ftr = context.Features.Find(feature.FeatureId);
            ftr.Title = feature.Title;
            ftr.Header = feature.Header;
            ftr.Description = feature.Description;
            ftr.ImageUrl = feature.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}