using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class MyTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var bll = new BLL.UserComponents();
            var user = bll.GetUser(Session["UserLogin"].ToString());
            if (user != null)
            {
                var bllt = new BLL.TestComponents();
                RepeaterTests.DataSource = bllt.GetTests(user.Login);
                DataBind();
            }
        }

        protected void Delete_Test(object sender, EventArgs e)
        {
        }
    }
}