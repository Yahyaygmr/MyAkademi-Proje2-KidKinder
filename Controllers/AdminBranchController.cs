using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminBranchController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var branches = context.Branches.ToList();
            return View(branches);
        }
        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(Branch branch)
        {
            context.Branches.Add(branch);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBranch(int id)
        {
            var branch = context.Branches.Find(id);
            return View(branch);
        }
        [HttpPost]
        public ActionResult UpdateBranch(Branch branch)
        {
            var brc = context.Branches.Find(branch.BranchId);
            brc.Name = branch.Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBranch(int id)
        {
            var branch = context.Branches.Find(id);
            context.Branches.Remove(branch);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}