using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminClassController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var classes = context.ClassRooms.ToList();
            return View(classes);
        }
        public ActionResult ClassDetails(int id)
        {
            var cls = context.ClassRooms.Find(id);
            return View(cls);
        }
        [HttpGet]
        public ActionResult CreateClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateClass(ClassRoom classRoom)
        {
            context.ClassRooms.Add(classRoom);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateClass(int id)
        {
            var cls = context.ClassRooms.Find(id);
            return View(cls);
        }
        [HttpPost]
        public ActionResult UpdateClass(ClassRoom classRoom)
        {
            var cls = context.ClassRooms.Find(classRoom.ClassRoomId);
            cls.Description = classRoom.Description;
            cls.Title = classRoom.Title;
            cls.TotalSeats = classRoom.TotalSeats;
            cls.ImageUrl = classRoom.ImageUrl;
            cls.AgeOfKids = classRoom.AgeOfKids;
            cls.Price = classRoom.Price;
            cls.ClassTime = classRoom.ClassTime;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteClass(int id)
        {
            var cls = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(cls);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}