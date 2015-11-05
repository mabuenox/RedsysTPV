using System.Web.Mvc;

namespace RedsysTPV.WebSample.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult OK()
        {
            ViewBag.Resultado = "Pago realizado";
            return View("Index");
        }

        public ActionResult KO()
        {
            ViewBag.Resultado = "Pago NO realizado";
            return View("Index");
        }
    }
}