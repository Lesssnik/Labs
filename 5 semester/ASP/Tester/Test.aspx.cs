using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class Test : System.Web.UI.Page
    {
        public static Entities.Test test;
        public static string TestName = "";
        public static string CurrQuestion = "";
        public static Entities.Statistic stat;
        public static int TrueCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            TestName = Request["name"];
            if (TestName != "")
            {
                if (!IsPostBack)
                {
                    stat = new Entities.Statistic();
                    if (Session["UserLogin"] != null)
                        stat.UserId = new BLL.UserComponents().GetUser(Session["UserLogin"].ToString()).ID;
                    var bll = new BLL.TestComponents();
                    test = bll.FindTest(TestName).First();
                    if (test == null)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    stat.TestName = test.Name;
                    Session["qNumber"] = test.Questions.Count - 1;
                    if (test.Questions.Count == 0)
                        Response.Redirect("Default.aspx");
                    CurrQuestion = test.Questions[(int)Session["qNumber"]].Text;
                    List<string> answers = new List<string>();
                    TrueCount = 0;
                    foreach (var ans in test.Questions[(int)Session["qNumber"]].Answers)
                    {
                        answers.Add(ans.Text);
                        if (ans.IsTrue == true)
                        {
                            TrueCount++;
                        }
                    }
                    if (TrueCount > 1)
                        CheckAnswerList.DataSource = answers;
                    else RadioAnswerList.DataSource = answers;
                    DataBind();
                    Session["TestStartTime"] = DateTime.Now;
                }
            }
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            TimeSpan timeSpent = (DateTime.Now - (DateTime)Session["TestStartTime"]);
            TimeSpan testTime = test.Time;
            if (timeSpent > testTime)
            {
                new BLL.StatisticComponents().AddStatistic(stat);
                Session["IsTemp"] = "True";
                Response.Redirect("~/Result.aspx?test=" + test.Id.ToString());
            }
            timeLeft.Text = (testTime - timeSpent).Hours.ToString(CultureInfo.InvariantCulture) + " ч "
                + (testTime - timeSpent).Minutes.ToString() + " м "
                + (testTime - timeSpent).Seconds.ToString() + " c ";
        }

        protected void Check_Click(object sender, EventArgs e)
        {
            if (TrueCount > 1)
            {
                int tempCount = 0;
                var temp = test.Questions.Where(q => q.Text == CurrQuestion).First();
                for (int i = 0; i < CheckAnswerList.Items.Count; i++)
                {
                    if (temp.Answers[i].IsTrue == true)
                    {
                        for (int j = 0; j < CheckAnswerList.Items.Count; j++ )
                            if (CheckAnswerList.Items[j].Text.CompareTo(temp.Answers[i].Text) == 0)
                                if (CheckAnswerList.Items[j].Selected == true)
                                    tempCount++;
                    }
                }
                if (tempCount == TrueCount)
                    stat.CorrectQuestions.Add(new Entities.StatisticItem() { Correct = CurrQuestion });
            }
            else
            {
                for (int i = 0; i < RadioAnswerList.Items.Count; i++)
                {
                    var temp = test.Questions.Where(q => q.Text == CurrQuestion).First();
                    if (temp.Answers[i].IsTrue == true)
                        if (RadioAnswerList.Items[i].Selected == true)
                        {
                            stat.CorrectQuestions.Add(new Entities.StatisticItem() { Correct = CurrQuestion });
                            break;
                        }
                }
            }
            Session["qNumber"] = (int)Session["qNumber"] - 1;

            if ((int)Session["qNumber"] == -1)
            {
                new BLL.StatisticComponents().AddStatistic(stat);
                Session["IsTemp"] = "True";
                Response.Redirect("~/Result.aspx?test=" + test.Id.ToString() + "&stat=" + stat.ID.ToString());
            }

            CurrQuestion = test.Questions[(int)Session["qNumber"]].Text;
            var answers = new List<string>();
            TrueCount = 0;
            foreach (var ans in test.Questions[(int)Session["qNumber"]].Answers)
            {
                answers.Add(ans.Text);
                if (ans.IsTrue == true)
                {
                    TrueCount++;
                }
            }
            if (TrueCount > 1)
            {
                CheckAnswerList.DataSource = answers;
                RadioAnswerList.DataSource = new List<string>();
            }
            else
            {
                RadioAnswerList.DataSource = answers;
                CheckAnswerList.DataSource = new List<string>();
            }
            DataBind();
        }
    }
}