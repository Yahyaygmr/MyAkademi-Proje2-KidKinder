using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Scope;

namespace KidKinder.Controllers
{
    public class AdminAdressController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var adress = context.Adresses.Find(id);
            return View(adress);
        }
        [HttpPost]
        public ActionResult Index(Adress adress)
        {
            var adrs = context.Adresses.Find(adress.AdressId);
            adrs.Description = adress.Description;
            adrs.AdressDetail = adress.AdressDetail;
            adrs.Phone = adress.Phone;
            adrs.Email = adress.Email;
            adrs.OpeningHours = adress.OpeningHours;
            context.SaveChanges();
            return View();
        }
    }
}