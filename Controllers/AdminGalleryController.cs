using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminGalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Galeries.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateImage(Gallery gallery)
        {
            gallery.Status = true;
            context.Galeries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateImage(int id)
        {
            var image = context.Galeries.Find(id);

            return View(image);
        }
        [HttpPost]
        public ActionResult UpdateImage(Gallery gallery)
        {
            var image = context.Galeries.Find(gallery.GalleryId);
            image.ImageUrl = gallery.ImageUrl;
            image.Status = gallery.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteImage(int id)
        {
            var image = context.Galeries.Find(id);
            context.Galeries.Remove(image);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SetStatusFalse(int id)
        {
            var image = context.Galeries.Find(id);
            image.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SetStatusTrue(int id)
        {
            var image = context.Galeries.Find(id);
            image.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}