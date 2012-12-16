using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvсTester.Models;

namespace MvсTester.Controllers
{
    public class HomeController : Controller
    {
        TesterEntities testerDB = new TesterEntities();
        public ActionResult Index(int? page)
        {
            var tests = testerDB.Tests.ToList();
            if (page == null)
                page = 1;

            int pages = 0;
            double page_coeff = testerDB.Tests.Count() / 10f;
            int page_coeff_int = (int)page_coeff;
            if (page_coeff > page_coeff_int)
                pages = page_coeff_int + 1;
            else pages = page_coeff_int;

            ViewBag.Pages = pages;

            if (page <= pages)
            {
                var lst = new List<Test>();
                for (int i = ((int)page - 1) * 10; i < (int)page * 10; i++)
                {
                    if (i < testerDB.Tests.Count())
                        lst.Add(tests[i]);
                }

                return View(lst);
            }
            else return RedirectToAction("404");
        }
    }
}
