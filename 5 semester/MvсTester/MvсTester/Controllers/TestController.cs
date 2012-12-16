using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvсTester.Models;

namespace MvсTester.Controllers
{
    public class TestController : Controller
    {
        TesterEntities testerDB = new TesterEntities();

        public ActionResult Search() { return View(testerDB.Tests.ToList()); }

        [HttpPost]
        public ActionResult Search(FormCollection values)
        {
            string text = values["SearchText"];
            return View(testerDB.Tests.Where(t => t.Name.Contains(text)).ToList());
        }

        public ActionResult AddTest() { return View(); }

        [HttpPost]
        public ActionResult AddTest(TestModel model)
        {
            if (ModelState.IsValid)
            {
                Test test = new Test();
                test.Author = Session["UserLogin"].ToString();
                test.Description = model.Description;
                test.Name = model.Name;
                testerDB.Tests.Add(test);
                testerDB.SaveChanges();
                return RedirectToAction("AddQuestions", new { testId = test.Id });
            }
            return View();
        }

        public ActionResult AddQuestions(QuestionsModel model)
        {
            if (model.Name != null)
            {
                var question = new Question();
                question.Text = model.Name;
                if (model.Question1 != null)
                    question.Answers.Add(new Answer() { Text = model.Question1, IsTrue = model.Question1Check });
                if (model.Question2 != null)
                    question.Answers.Add(new Answer() { Text = model.Question2, IsTrue = model.Question2Check });
                if (model.Question3 != null)
                    question.Answers.Add(new Answer() { Text = model.Question3, IsTrue = model.Question3Check });
                if (model.Question4 != null)
                    question.Answers.Add(new Answer() { Text = model.Question4, IsTrue = model.Question4Check });
                if (model.Question5 != null)
                    question.Answers.Add(new Answer() { Text = model.Question5, IsTrue = model.Question5Check });
                if (model.Question6 != null)
                    question.Answers.Add(new Answer() { Text = model.Question6, IsTrue = model.Question6Check });

                var Id = Guid.Empty;
                bool res = true;
                if (model.Id != Guid.Empty)
                    Id = model.Id;
                else
                    res = Guid.TryParse(Request["testId"], out Id);

                if (res)
                {
                    var test = testerDB.Tests.Where(t => t.Id.CompareTo(Id) == 0).First();
                    test.Questions.Add(question);
                    testerDB.SaveChanges();
                    return View(model);
                }
                else return RedirectToAction("404");
            }
            return View(model);
        }

        public ActionResult Clear()
        {
            return null;
        }

        public ActionResult EditTest(string id)
        {
            Guid Id = Guid.Empty;
            bool res = Guid.TryParse(id, out Id);
            if (res)
            {
                var test = testerDB.Tests.Where(t => t.Id.CompareTo(Id) == 0).First();
                return View(test);
            }
            else return RedirectToAction("404");
        }

        [HttpPost]
        public ActionResult EditTest(Test model)
        {
            if (ModelState.IsValid)
            {
                Test test = testerDB.Tests.Where(t => t.Id.CompareTo(model.Id) == 0).First();
                test.Description = model.Description;
                test.Name = model.Name;
                testerDB.SaveChanges();
                return RedirectToAction("EditQuestions", new { testId = test.Id });
            }
            return View();
        }

        public ActionResult EditQuestions(FormCollection values)
        {
            ViewBag.Id = Request["testId"];
            Guid Id = Guid.Empty;
            bool res = Guid.TryParse(Request["testId"], out Id);
            if (res)
            {
                var lst = testerDB.Tests.Where(t => t.Id.CompareTo(Id) == 0).First().Questions.Select(q => q.Text);
                ViewBag.Questions = new SelectList(lst);

                if (values["add"] != null)
                {
                    var question = new Question();
                    question.Text = values["Name"];
                    if (values["Question1"] != string.Empty)
                        question.Answers.Add(new Answer() { Text = values["Question1"], IsTrue = bool.Parse(values["Question1Check"]) });
                    if (values["Question2"] != string.Empty)
                        question.Answers.Add(new Answer() { Text = values["Question2"], IsTrue = bool.Parse(values["Question2Check"]) });
                    if (values["Question3"] != string.Empty)
                        question.Answers.Add(new Answer() { Text = values["Question3"], IsTrue = bool.Parse(values["Question3Check"]) });
                    if (values["Question4"] != string.Empty)
                        question.Answers.Add(new Answer() { Text = values["Question4"], IsTrue = bool.Parse(values["Question4Check"]) });
                    if (values["Question5"] != string.Empty)
                        question.Answers.Add(new Answer() { Text = values["Question5"], IsTrue = bool.Parse(values["Question5Check"]) });
                    if (values["Question6"] != string.Empty)
                        question.Answers.Add(new Answer() { Text = values["Question6"], IsTrue = bool.Parse(values["Question6Check"]) });

                    testerDB.Tests.Where(t => t.Id.ToString().CompareTo(values["testId"]) == 0).First().Questions.Add(question);
                    return View("AddQuestions", values["testId"]);
                }
                else if (values["save"] != null)
                    return RedirectToAction("Index", "Home");
                else return View();
            }
            else return RedirectToAction("404");
        }

        public ActionResult GetQuestion(string testid, string question)
        {
            Guid Id = Guid.Empty;
            bool res = Guid.TryParse(testid, out Id);
            if (res)
            {
                var test = testerDB.Tests.Where(t => t.Id.CompareTo(Id) == 0).First();
                var result = test.Questions.Where(q => q.Text.Trim().CompareTo(question) == 0).First();
                return Json(new JavaScriptSerializer().Serialize(result));
            }
            else return Json(null);
        }

        public ActionResult Test(FormCollection values)
        {
            if (values.AllKeys.Count() == 0)
            {
                Guid Id = Guid.Empty;
                bool res = Guid.TryParse(Request["testId"], out Id);
                if (res)
                    return View(testerDB.Tests.Where(t => t.Id.CompareTo(Id) == 0).First());
                else return RedirectToAction("404", "Home");
            }
            else
            {
                Guid Id = Guid.Empty;
                bool res = Guid.TryParse(Request["testId"], out Id);
                if (res)
                {
                    var test = testerDB.Tests.Where(t => t.Id.CompareTo(Id) == 0).First();
                    var questions = test.Questions;
                    int trueAns = 0, realTrueAns = 0, selectTrue = 0;
                    Guid userId = Guid.Empty;
                    if (Session["UserLogin"] != null)
                    {
                        string login = Session["UserLogin"].ToString();
                        userId = testerDB.Users.Where(u => u.Login.CompareTo(login) == 0).First().ID;
                    }
                    var stat = new Statistic() { TestName = test.Name, UserId = userId };
                    int number = 0;
                    bool b = false;
                    int index = 0;
                    for (int i = 0; i < questions.Count; i++)
                    {
                        realTrueAns = 0;
                        foreach (var ans in questions[i].Answers)
                            if (ans.IsTrue == true)
                                realTrueAns++;

                        selectTrue = 0;
                        for (int k = 0; k < questions[i].Answers.Count; k++)
                        {
                            if (values[index][0] == 't')
                                selectTrue++;
                            index++;
                        }

                        if (selectTrue == realTrueAns)
                        {
                            for (int j = 0; j < questions[i].Answers.Count; j++)
                            {
                                trueAns = 0;
                                if (questions[i].Answers[j].IsTrue == true)
                                {
                                    number = 0;
                                    foreach (var val in values)
                                    {
                                        if (val.ToString().CompareTo(questions[i].Text + '_' + questions[i].Answers[j].Text) == 0)
                                        {
                                            var temp = values[number];
                                            if (temp[0] == 't')
                                                b = true;
                                            else b = false;
                                            number = 0;
                                            break;
                                        }
                                        number++;
                                    }

                                    if (b == true)
                                        trueAns++;
                                }
                            }

                            if (realTrueAns == trueAns)
                            {
                                stat.CorrectQuestions.Add(new StatisticItem() { Correct = questions[i].Text });
                            }
                        }
                    }

                    testerDB.Statistics.Add(stat);
                    testerDB.SaveChanges();
                    return RedirectToAction("Result", new { statId = stat.ID });
                }
                else return RedirectToAction("404");
            }
        }

        public ActionResult Result()
        {
            Guid Id = Guid.Empty;
            bool res = Guid.TryParse(Request["statId"], out Id);
            if (res)
            {
                var stats = testerDB.Statistics.Where(s => s.ID.CompareTo(Id) == 0);
                if (stats.Count() != 0)
                {
                    var stat = stats.First();
                    var test = testerDB.Tests.Where(t => t.Name.CompareTo(stat.TestName) == 0).First();
                    return View(new Tuple<Statistic, Test>(stat, test));
                }
                else return View();
            }
            else return View();
        }
    }
}
