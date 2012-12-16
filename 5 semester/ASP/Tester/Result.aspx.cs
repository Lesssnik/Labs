using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class Result : System.Web.UI.Page
    {
        List<Tuple<string, string>> stats = new List<Tuple<string, string>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var bll = new BLL.UserComponents();
            var user = new Entities.User();
            if (Session["UserLogin"] != null)
                user = bll.GetUser(Session["UserLogin"].ToString());
            var test = new BLL.TestComponents().FindTest(Guid.Parse(Request["test"]));
            var blls = new BLL.StatisticComponents();
            var guid = Guid.Parse(Request["stat"]);
            var stat = new BLL.StatisticComponents().GetTestStatistics().Where(s => s.ID.CompareTo(guid) == 0).First();

            foreach (var q in test.Questions)
            {
                var temp = stat.CorrectQuestions.Where(s => s.Correct == q.Text);
                if (temp.Count() > 0)
                    stats.Add(new Tuple<string, string>(q.Text, "Верно"));
                else stats.Add(new Tuple<string, string>(q.Text, "Неверно"));
            }

            RepeaterStats.DataSource = stats;
            DataBind();

            if (Session["IsTrue"] != null)
            {
                blls.DeleteStatistic(stat);
                Session["IsTrue"] = null;
            }
        }
    }
}