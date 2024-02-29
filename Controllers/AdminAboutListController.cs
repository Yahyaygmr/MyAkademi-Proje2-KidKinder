using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAboutListController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var list = context.AboutLists.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateAboutList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAboutList(AboutList aboutList)
        {
            context.AboutLists.Add(aboutList);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAboutList(int id)
        {
            var list = context.AboutLists.Find(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult UpdateAboutList(AboutList aboutList)
        {
            var list = context.AboutLists.Find(aboutList.AboutListId);
            list.Description = aboutList.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAboutList(int id)
        {
            var list = context.AboutLists.Find(id);
            context.AboutLists.Remove(list);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}