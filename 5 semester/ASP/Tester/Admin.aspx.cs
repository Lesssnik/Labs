using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class Admin : System.Web.UI.Page
    {
        static IList<Entities.Test> Tests;
        static IList<Entities.User> Users;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null || Session["UserLogin"].ToString().CompareTo("Admin") != 0)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                Tests = new BLL.TestComponents().GetTests();
                Users = new BLL.UserComponents().GetUsers();
                RepeaterTests.DataSource = Tests;
                RepeaterUsers.DataSource = Users;
                Info.DataSource = new List<string>() { "Тесты", "Пользователи" };
                DataBind();
            }
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Session["UserLogin"] = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void Info_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Page_IndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepeaterTests.PageIndex = e.NewPageIndex;
            RepeaterTests.DataSource = Tests;
            DataBind();
        }

        protected void RepeaterTests_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var test = Tests[e.NewEditIndex];
            Response.Redirect("EditTest.aspx?test=" + test.Id.ToString());
        }

        protected void RepeaterTests_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new BLL.TestComponents().DeleteTest(Tests[e.RowIndex]);
            Tests = new BLL.TestComponents().GetTests();
            RepeaterTests.DataSource = Tests;
            DataBind();
        }
    }
}