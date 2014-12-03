using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureDemoCiber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            new SendgridService().Send("per-kristian.helland@ciber.com", "Jula kommer tidlig i år", "Have fun with all the presents");
            return View();
        }

        [Route("loaderio-4a7315c6ee6211a9fa91a016323601e5")]
        public ActionResult As()
        {
            var path = HttpContext.Server.MapPath("~/App_Data/loaderio-4a7315c6ee6211a9fa91a016323601e5.txt");
            return new FileContentResult(System.IO.File.ReadAllBytes(path), "text/plain");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}