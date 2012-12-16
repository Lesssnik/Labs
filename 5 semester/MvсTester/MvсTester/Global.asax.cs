using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvсTester
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            bool hasAdmin = false;
            var db = new MvсTester.Models.TesterEntities();
            foreach(var user in db.Users)
                if (user.Login.CompareTo("Admin") == 0)
                    hasAdmin = true;

            if (hasAdmin == false)
            {
                db.Users.Add(new Models.User("Admin", "admin"));
                db.SaveChanges();
            }
        }
    }
}