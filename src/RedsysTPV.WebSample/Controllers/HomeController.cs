using System.Web.Mvc;

namespace RedsysTPV.WebSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string MerchantCode, string MerchantOrder, string Amount)
        {
            return RedirectToAction("Index", "Request", new { merchantCode = MerchantCode, merchantOrder = MerchantOrder, amount = Amount });
        }

    }
}