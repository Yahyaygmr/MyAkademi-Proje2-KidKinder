using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminTestimonialController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var testimonials = context.Testimonials.ToList();
            return View(testimonials);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            return View(testimonial);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var tst = context.Testimonials.Find(testimonial.TestimonialId);
            tst.NameSurname = testimonial.NameSurname;
            tst.ImageUrl = testimonial.ImageUrl;
            tst.Title = testimonial.Title;
            tst.Comment = testimonial.Comment;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            context.Testimonials.Remove(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}