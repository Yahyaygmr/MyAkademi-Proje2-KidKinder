﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
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
            return PartialView();
        }
        public PartialViewResult PartialServices()
        {
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            return PartialView();
        }
        public PartialViewResult PartialClassRooms()
        {
            return PartialView();
        }
        public PartialViewResult PartialBookASeat()
        {
            return PartialView();
        }
        public PartialViewResult PartialTeachers()
        {
            return PartialView();
        }
        public PartialViewResult PartialTestimonials()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}