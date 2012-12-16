using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var user = new BLL.UserComponents().GetUser(UserName.Text);
            if (user != null)
            {
                if (user.Role == Entities.Roles.User)
                {
                    if (user.Password == Password.Text)
                    {
                        Session["UserLogin"] = UserName.Text;
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else if (user.Role == Entities.Roles.Admin)
                {
                    if (user.Password == Password.Text)
                    {
                        Session["UserLogin"] = UserName.Text;
                        Response.Redirect("~/Admin.aspx");
                    }
                }
                FailureText.Text = "Неверный пароль";
            }
            FailureText.Text = "Пользователь с таким именем не найден";
        }
    }
}
