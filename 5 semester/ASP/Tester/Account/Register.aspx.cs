using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Register_User(object sender, EventArgs e)
        {
            if (new BLL.UserComponents().GetUser(UserName.Text) == null)
            {
                new BLL.UserComponents().CreateUser(UserName.Text, Password.Text, Email.Text);
                Session["UserLogin"] = UserName.Text;
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
