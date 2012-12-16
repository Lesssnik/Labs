﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class LoginDisplayControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Session["UserLogin"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}