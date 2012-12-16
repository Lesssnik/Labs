using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class EditUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Update_User(object sender, EventArgs e)
        {
            var user = new BLL.UserComponents().GetUser(Session["UserLogin"].ToString());
            if (Name != "")
                user.Name = Name;
            if (Surname != "")
                user.Surname = Surname;
            if (City != "")
                user.City = City;
            if (OldPass == user.Password)
                user.Password = NewPass;
            new BLL.UserComponents().UpdateUser(user);
            Response.Redirect("Default.aspx");
        }

        public string Name
        {
            get { return NameId.Value; }
            set { NameId.Value = value; }
        }

        public string Surname
        {
            get { return SurnameId.Value; }
            set { SurnameId.Value = value; }
        }

        public string City
        {
            get { return CityId.Value; }
            set { CityId.Value = value; }
        }

        public string NewPass
        {
            get { return NewPassword.Value; }
            set { NewPassword.Value = value; }
        }

        public string OldPass
        {
            get { return OldPassword.Value; }
            set { OldPassword.Value = value; }
        }
    }
}