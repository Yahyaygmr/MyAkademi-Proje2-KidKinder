using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            //Branşı resim olan öğretmen sayısı

            int branchId = context.Branches.Where(x => x.Name == "Resim").Select(y => y.BranchId).FirstOrDefault();
            ViewBag.resimTeacherCount = context.Teachers.Where(x => x.BranchId == branchId).Count();

            //Eğitimlerin orlama ücreti
            ViewBag.avgClassroomPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");

            return View();
        }
    }
}