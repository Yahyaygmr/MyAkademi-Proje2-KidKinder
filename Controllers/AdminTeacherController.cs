using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace KidKinder.Controllers
{
    public class AdminTeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult TeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            //    if (teacher.ImageUrl != null)
            //    {
            //        string filename = Path.GetFileName(teacher.ImageUrl);
            //        string folderPath = Server.MapPath("~/UploadedFiles/");

            //        // Eğer belirtilen klasör mevcut değilse oluştur
            //        if (!Directory.Exists(folderPath))
            //        {
            //            Directory.CreateDirectory(folderPath);
            //        }

            //        // Dosya yolunu oluştur
            //        string filePath = folderPath + filename;

            //        // Dosyayı yükle
            //        teacher.ImageUrl = filePath;
            //    }
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }
        public ActionResult DeleteTeacher(int id)
        {
            var teacher = context.Teachers.Find(id);
            context.Teachers.Remove(teacher);
            context.SaveChanges();
            return RedirectToAction("TeacherList");
        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            var teacher = context.Teachers.Find(id);

            return View(teacher);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            var tch = context.Teachers.Find(teacher.TeacherId);
            tch.NameSurname = teacher.NameSurname;
            tch.Title = teacher.Title;
            tch.ImageUrl = teacher.ImageUrl;
            context.SaveChanges();

            return RedirectToAction("TeacherList");
        }
    }
}