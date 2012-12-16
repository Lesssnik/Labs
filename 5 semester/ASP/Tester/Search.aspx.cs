using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class _Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tc = new BLL.TestComponents();
            var Tests = tc.GetTests();
            RepeaterTests.DataSource = Tests;
            DataBind();
        }

        protected void Find_Click(object sender, EventArgs e)
        {
            var lst = new List<Entities.Test>();
            var test = new BLL.TestComponents().FindTest(SearchText.Text);
            if (test != null)
                lst.AddRange(test);
            RepeaterTests.DataSource = lst;
            if (lst.Count == 0)
                NullText.Visible = true;
            else NullText.Visible = false;
            DataBind();
        }
    }
}