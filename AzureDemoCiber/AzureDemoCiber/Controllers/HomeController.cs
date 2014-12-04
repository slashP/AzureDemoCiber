using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using AzureDemoCiber.Services;

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
            return new FileContentResult(Encoding.UTF8.GetBytes("loaderio-4a7315c6ee6211a9fa91a016323601e5"), "text/plain");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("images/{container?}")]
        public ActionResult Images(string container = null)
        {
            var urls = container == null ? Enumerable.Empty<string>() : new AzureBlobService().GetUrls(container);
            return View(urls);
        }

        [Route("imageUpload/{container}")]
        public async Task<string> ImageUpload(string container)
        {
            await new AzureBlobService().UploadAsync(container, Request.Files[0].InputStream);
            return "ok";
        }
    }
}