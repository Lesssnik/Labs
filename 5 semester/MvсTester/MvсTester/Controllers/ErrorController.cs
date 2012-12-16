using System.Web.Mvc;

namespace MvсTester.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404() { return View(); }
    }
}
