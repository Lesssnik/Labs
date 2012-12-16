using System;
using System.Linq;
using System.Web.Mvc;
using MvсTester.Models;

namespace MvсTester.Controllers
{
    public class AdminController : Controller
    {
        private TesterEntities db = new TesterEntities();

        public ActionResult Index()
        {
            if (Session["UserLogin"] == null || Session["UserLogin"].ToString().CompareTo("Admin") != 0)
                    return RedirectToAction("Index", "Home");
            return View(db.Tests.ToList());
        }

        public ActionResult Create()
        {
            return RedirectToAction("AddTest", "Test");
        }

        public ActionResult Edit(Guid id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("EditTest", "Test", new { Id = test.Id });
        }

        public ActionResult Delete(Guid id)
        {
            if (Session["UserLogin"] == null || Session["UserLogin"].ToString().CompareTo("Admin") != 0)
                   return RedirectToAction("Index", "Home");
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (Session["UserLogin"] == null || Session["UserLogin"].ToString().CompareTo("Admin") != 0)
                   return RedirectToAction("Index", "Home");
            Test test = db.Tests.Find(id);
            var lst = test.Questions.ToList();
            foreach (var q in lst)
                test.Questions.Remove(q);
            db.Tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}