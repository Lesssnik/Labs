using System;
using System.Linq;
using System.Web.Mvc;
using MvсTester.Models;

namespace MvсTester.Controllers
{
    public class UserController : Controller
    {
        TesterEntities testerDB = new TesterEntities();

        public ActionResult User()
        {
            string login = String.Empty;
            if (Request["user"] == null)
                login = Session["UserLogin"].ToString();
            else login = Request["user"].ToString();
            var user = testerDB.Users.Where(u => u.Login.CompareTo(login) == 0);
            if (user.Count() != 0)
                return View(user.First());
            else return View();
        }

        public ActionResult EditUser() { return View(); }

        [HttpPost]
        public ActionResult EditUser(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                string login = Session["UserLogin"].ToString();
                var user = testerDB.Users.Where(u => u.Login.CompareTo(login) == 0).First();
                if (model.Name != null)
                    user.Name = model.Name;
                if (model.Surname != null)
                    user.Surname = model.Surname;
                if (model.Email != null)
                    user.Email = model.Email;
                if (model.City != null)
                    user.City = model.City;
                if (model.NewPassword != null && model.OldPassword != null)
                    if (model.OldPassword.CompareTo(user.Password) == 0)
                        user.Password = model.NewPassword;

                testerDB.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult MyTests()
        {
            string login = Session["UserLogin"].ToString();
            return View(testerDB.Tests.Where(t => t.Author.CompareTo(login) == 0).ToList());
        }

        public ActionResult MyStatistic()
        {
            string login = Session["UserLogin"].ToString();
            Guid Id = testerDB.Users.Where(u => u.Login.CompareTo(login) == 0).First().ID;
            var lst = testerDB.Statistics.Where(s => s.UserId.CompareTo(Id) == 0).ToList();
            return View(lst);
        }
    }
}
