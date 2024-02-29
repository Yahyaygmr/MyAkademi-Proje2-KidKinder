using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
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
            int res = context.Teachers.Where(x => x.BranchId == branchId).Count();
            ViewBag.resimTeacherCount = res;
            //Eğitimlerin orlama ücreti
            ViewBag.avgClassroomPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");

            //Toplam Öğretmen Sayısı
            int teacherCount = context.Teachers.Count();
            int tec = teacherCount;
            ViewBag.teacherCount = teacherCount;

            //Müzik
            int branchId1 = context.Branches.Where(x => x.Name == "Müzik").Select(y => y.BranchId).FirstOrDefault();

            int muz = context.Teachers.Where(x => x.BranchId == branchId1).Count();
            ViewBag.muzikTeacherCount = muz;
            //Matematik
            int branchId2 = context.Branches.Where(x => x.Name == "Matematik").Select(y => y.BranchId).FirstOrDefault();
            int mat = context.Teachers.Where(x => x.BranchId == branchId2).Count();
            ViewBag.matTeacherCount = mat;
            //İspanyolca
            int branchId3 = context.Branches.Where(x => x.Name == "İspanyolca").Select(y => y.BranchId).FirstOrDefault();
            int isp = context.Teachers.Where(x => x.BranchId == branchId3).Count();
            ViewBag.ispTeacherCount = isp;
            //Edebiyat
            int branchId4 = context.Branches.Where(x => x.Name == "Edebiyat").Select(y => y.BranchId).FirstOrDefault();
            int edb = context.Teachers.Where(x => x.BranchId == branchId4).Count();
            ViewBag.edTeacherCount = edb;

            //google chart
            ViewBag.edb = (decimal)(edb / tec);
            ViewBag.isp = (decimal)(isp / tec);
            ViewBag.mat = (decimal)(mat / tec);
            ViewBag.muz = (decimal)(muz / tec);
            ViewBag.res = (decimal)(res / tec);

            //Gelen Mesaj Sayısı
            ViewBag.mesageCount = context.Contacts.Count();

            //Sınıf Sayısı
            ViewBag.sinifCount = context.ClassRooms.Count();

            //Referans Sayısı
            ViewBag.refCount = context.Testimonials.Count();

            //Mail listesi abone sayısı

            ViewBag.newsletter = context.MailSubscribes.Count();

            //Enyüksek Ücretli kurs Fiyatı
            ViewBag.coursePrice = context.ClassRooms.OrderBy(x => x.Price).First().Price.ToString("0.00");


            //Enyüksek Ücretli kurs Adı
            ViewBag.coursePriceCource = context.ClassRooms.OrderBy(x => x.Price).First().Title;



            return View();
        }
        public PartialViewResult PartialTecherList()
        {
            var values = context.Teachers.OrderByDescending(x => x.TeacherId).Take(4).ToList();
            return PartialView(values);
        }
    }
}