using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class MyStatistic : System.Web.UI.Page
    {
        List<Tuple<string, int, int>> TestNames = new List<Tuple<string, int, int>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var bll = new BLL.UserComponents();
            var user = bll.GetUser(Session["UserLogin"].ToString());
            var blls = new BLL.StatisticComponents();
            var bllt = new BLL.TestComponents();
            var stats =  blls.GetTestStatistic(user);

            foreach (var stat in stats)
            {
                var test = bllt.FindTest(stat.TestName).First();
                TestNames.Add(new Tuple<string, int, int>(stat.TestName, stat.CorrectQuestions.Count, test.Questions.Count));
            }

            RepeaterStats.DataSource = TestNames;
            if (TestNames.Count == 0)
                NullText.Visible = true;
            else NullText.Visible = false;
            DataBind();
        }
    }
}