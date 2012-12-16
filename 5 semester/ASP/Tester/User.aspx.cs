using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class User : System.Web.UI.Page
    {
        public Entities.User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["user"] == null)
                user = new BLL.UserComponents().GetUser(Session["UserLogin"].ToString());
            else
                user = new BLL.UserComponents().GetUser(Request["user"].ToString());
            if (user != null)
                DataBind();
        }
    }
}