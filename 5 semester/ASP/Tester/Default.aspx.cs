using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class _Default : System.Web.UI.Page
    {
        IList<Entities.Test> Tests;

        protected void Page_Load(object sender, EventArgs e)
        {
            var tc = new BLL.TestComponents();
            Tests = tc.GetTests();
            RepeaterTests.DataSource = Tests;
            if (Tests.Count == 0)
                NullText.Visible = true;
            else NullText.Visible = false;
            DataBind();
        }

        protected void Page_IndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepeaterTests.PageIndex = e.NewPageIndex;
            RepeaterTests.DataSource = Tests;
            DataBind();
        }
    }
}
