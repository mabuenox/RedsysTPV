using RedsysTPV.Models;
using System.Configuration;
using System.Web.Mvc;

namespace RedsysTPV.WebSample.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index(string merchantCode, string merchantOrder, string amount)
        {
            var paymentRequestService = new PaymentRequestService();

            var paymentRequest = new PaymentRequest(
                Ds_Merchant_MerchantCode: merchantCode,
                Ds_Merchant_Terminal: "1",
                Ds_Merchant_TransactionType: "0",
                Ds_Merchant_Amount: amount,
                Ds_Merchant_Currency: "978",
                Ds_Merchant_Order: merchantOrder,
                Ds_Merchant_MerchantURL: Url.Action("Index","Response", null, Request.Url.Scheme),
                Ds_Merchant_UrlOK: Url.Action("OK", "Result", null, Request.Url.Scheme),
                Ds_Merchant_UrlKO: Url.Action("KO", "Result", null, Request.Url.Scheme),
                Ds_Merchant_Paymethods: "C"); //Only Credit Card

            var formData = paymentRequestService.GetPaymentRequestFormData(
                paymentRequest: paymentRequest,
                merchantKey: ConfigurationManager.AppSettings["MerchantKey"]);

            ViewBag.ConnectionURL = ConfigurationManager.AppSettings["TPVConnectionURL"];
            return View(formData);
        }
    }
}