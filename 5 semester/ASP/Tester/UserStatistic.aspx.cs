using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class UserStatistic : System.Web.UI.Page
    {
        List<Tuple<string, List<Tuple<string, string>>>> stats = new List<Tuple<string, List<Tuple<string, string>>>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null || Session["UserLogin"].ToString().CompareTo("Admin") != 0)
            {
                Response.Redirect("Default.aspx");
            }

            var user = new BLL.UserComponents().GetUser(Request["user"]);
            var tempstat = new BLL.StatisticComponents().GetTestStatistic(user);

            foreach (var st in tempstat)
            {
                var test = new BLL.TestComponents().FindTest(st.TestName).First();
                stats.Add(new Tuple<string, List<Tuple<string, string>>>(test.Name, new List<Tuple<string, string>>()));
                foreach (var q in test.Questions)
                {
                    var temp = st.CorrectQuestions.Where(s => s.Correct == q.Text);
                    if (temp.Count() > 0)
                        stats[stats.Count-1].Item2.Add(new Tuple<string, string>(q.Text, "Верно"));
                    else stats[stats.Count-1].Item2.Add(new Tuple<string, string>(q.Text, "Неверно"));
                }
            }
            RepeaterStats.DataSource = stats;
            if (stats.Count == 0)
                NullText.Visible = true;
            else NullText.Visible = false;
            DataBind();
        }
    }
}