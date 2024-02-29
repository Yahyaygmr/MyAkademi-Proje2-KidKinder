using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminServiceController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var services = context.Services.ToList();
            return View(services);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = context.Services.Find(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var srv = context.Services.Find(service.ServiceId);
            srv.Title = service.Title;
            srv.Description = service.Description;
            srv.IconUrl = service.IconUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var service = context.Services.Find(id);
            context.Services.Remove(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}