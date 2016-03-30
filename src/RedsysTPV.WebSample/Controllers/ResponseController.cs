using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace RedsysTPV.WebSample.Controllers
{
    public class ResponseController : Controller
    {
        
        // GET: Response
        public ActionResult Index()
        {

            LogToFile(String.Format("Date: {0}", DateTime.Now));

            try
            {
                var paymentResponseService = new PaymentResponseService();

                var merchantParameters = Convert.ToString(Request["Ds_MerchantParameters"]);
                var merchantKey = ConfigurationManager.AppSettings["MerchantKey"];
                var platformSignature = Convert.ToString(Request["Ds_Signature"]);

                var processedPayment = paymentResponseService.GetProcessedPayment(merchantParameters, merchantKey, platformSignature);

                LogToFile(String.Format("IsValidSignature: {0}", processedPayment.IsValidSignature));
                LogToFile(String.Format("IsPaymentPerformed: {0}", processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single()));
                LogToFile(String.Format("PaymentResponse.Ds_Response: {0}", processedPayment.PaymentResponse.Ds_Response));
                LogToFile(String.Format("PaymentResponse.Ds_Order: {0}", processedPayment.PaymentResponse.Ds_Order));

                if (processedPayment.IsValidSignature)
                {
                    // Signature is correct, the request come from trusted source

                    if (processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single())
                    {
                        // Payment accepted: success
                        // Update the order on database, etc
                        LogToFile("PAGO REALIZADO CORRECTAMENTE");
                    }
                    else
                    {
                        // Payment rejected: fail
                        // Update the order on database, etc
                        LogToFile("PAGO NO REALIZADO");
                    }
                }
                else
                {
                    // Signature is not valid, the request come from untrusted source
                }
            }
            catch (Exception ex)
            {
                LogToFile(String.Format("Error: {0}", ex.Message));
            }

            LogToFile("---");



            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private void LogToFile(string message)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(Server.MapPath("~/log.txt"), true, encoding: Encoding.UTF8);
                sw.WriteLine(message);
            }
            catch (Exception) { }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}