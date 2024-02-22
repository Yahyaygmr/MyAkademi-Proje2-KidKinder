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
    [Authorize]
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
            ViewBag.branches = GetBranches();
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
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
            ViewBag.branches = GetBranches();
            var teacher = context.Teachers.Find(id);

            return View(teacher);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            var tch = context.Teachers.Find(teacher.TeacherId);
            tch.NameSurname = teacher.NameSurname;
            tch.BranchId = teacher.BranchId;
            tch.ImageUrl = teacher.ImageUrl;
            context.SaveChanges();

            return RedirectToAction("TeacherList");
        }

        public List<SelectListItem> GetBranches()
        {
            return (from x in context.Branches.ToList()
                    select new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.BranchId.ToString()
                    }).ToList();
        }
    }
}