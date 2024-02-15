using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            ViewBag.header = "Contact";
            return View();
        }
        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult ContactAdressPartial()
        {
            ViewBag.descripton = context.Adresses.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Adresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.adress = context.Adresses.Select(x => x.AdressDetail).FirstOrDefault();
            ViewBag.email = context.Adresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.openingHours = context.Adresses.Select(x => x.OpeningHours).FirstOrDefault();
            return PartialView();
        }
    }
}