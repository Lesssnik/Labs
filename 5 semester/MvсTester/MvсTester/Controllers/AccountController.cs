using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using MvсTester.Models;

namespace MvсTester.Controllers
{
    public class AccountController : Controller
    {
        TesterEntities testerDB = new TesterEntities();

        public ActionResult CheckLogin(string username)
        {
            string result;

            if (String.IsNullOrEmpty(username))
                result = "Не указано имя пользователя";
            else
            {
                var users = testerDB.Users.Where(u => u.Login.CompareTo(username) == 0);
                result = users.Count() > 0 ?
                    "Такой пользователь уже существует" :
                    "Имя свободно";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Exit()
        {
            Session["UserLogin"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register() { return View(); }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (testerDB.Users.Where(u => u.Login.CompareTo(model.Name) == 0).Count() != 0)
                {
                    ModelState.AddModelError("WrongLoginError", "Пользователь с таким именем уже зарегистрирован");
                    return View(model);
                }
                if (!Regex.IsMatch(model.Email, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
                {
                    ModelState.AddModelError("WrongEmailError", "Email имеет неверный формат");
                    return View(model);
                }
                var user = new User(model.Name, model.Password);
                user.Email = model.Email;
                testerDB.Users.Add(user);
                testerDB.SaveChanges();
                Session["UserLogin"] = user.Login;
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult LogOn() { return View(); }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                var users = testerDB.Users.Where(u => u.Login.CompareTo(model.Name) == 0);
                if (users.Count() != 0)
                {
                    var user = users.First();
                    if (user.Password.CompareTo(model.Password) == 0)
                    {
                        Session["UserLogin"] = user.Login;
                        if (user.Login.CompareTo("Admin") == 0)
                            return RedirectToAction("Index", "Admin");
                        else return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("WrongPasswordError", "Неверный пароль");
                }
                else
                {
                    ModelState.AddModelError("WrongLoginError", "Неверный логин");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
