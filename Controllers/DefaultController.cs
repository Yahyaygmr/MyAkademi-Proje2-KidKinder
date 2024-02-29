using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialServices()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout(int id = 1)
        {
            var values = context.Abouts.Find(id);
            return PartialView(values);
        }
        public PartialViewResult PartialAboutList()
        {
            var values = context.AboutLists.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialClassRooms()
        {
            var values = context.ClassRooms
                .OrderByDescending(x =>x.ClassRoomId)
                .Take(3)
                .ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialBookASeat()
        {
            ViewBag.ClassRooms = new SelectList(context.ClassRooms, "ClassRoomId", "Title");
            return PartialView();
        }
        public PartialViewResult PartialTeachers()
        {
            var values = context.Teachers.Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonials()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
        public PartialViewResult PartialNewsletter()
        {
            return PartialView();
        }
        public PartialViewResult PartialGetInTouch(int id = 1)
        {
            var gint = context.Adresses.Find(id);
            return PartialView(gint);
        }
        [HttpPost]
        public ActionResult BookASeat(BookASeat bookASeat)
        {
            context.bookASeats.Add(bookASeat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Newsletter(MailSubscribe mailSubscribe)
        {
            context.MailSubscribes.Add(mailSubscribe);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}