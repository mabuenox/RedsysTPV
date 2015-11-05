# RedsysTPV 

## SHA256 signature implementation

This is a .NET Framework 4.5 library for help you on cart and orders integrations with the Redsys payment gateway (a platform that manage online payments for several spanish banks like La Caixa, Banco Santander, BBVA, Banco Sabadell, Bankia, etc).

This library is released because of the mandatory update from old SHA1 signatures to SHA256, in order to keep using the platform securely. The old SHA1 signatures will stop working on November 23th, when Redsys virtual POS will accept only signatures generated using SHA-256.

Note that only simple payments by post-redirect method is implemented, not SOAP option is covered on this project.

**This code includes a sample web that implements the library. I recommend see this sample to a better understand of how to use the library.**

You can find an example here: http://redsystpv.azurewebsites.net.

## How to install

You can install RedsysTPV as a [nuget package](https://www.nuget.org/packages/RedsysTPV): 

	PM> Install-Package RedsysTPV

## How to use

The payment platform works as follow:

1. The commerce post an html form with obfuscated data and an operation signature.
2. If request is correct, platform redirect user to the bank payment page.
3. User types his card number on a secure bank page
4. and the platform sends a background request to a specific commerce url to notify operation results.
5. User is redirected to a ok/ko page of the commerce.

### Create payment request

```csharp
var paymentRequestService = new PaymentRequestService();

var paymentRequest = 
	new PaymentRequest(
		Ds_Merchant_MerchantCode: "012345678",	
		Ds_Merchant_Terminal: "1",	
		Ds_Merchant_TransactionType: "0",
		Ds_Merchant_Amount: "123",
		Ds_Merchant_Currency: "978",
		Ds_Merchant_Order: "9999TEST0001",
		Ds_Merchant_MerchantURL: "http://www.example.com/payment-notifications"),
		Ds_Merchant_UrlOK: "http://www.example.com/payment-ok",
		Ds_Merchant_UrlKO: "http://www.example.com/payment-ko");

var formData = 
	paymentRequestService.GetPaymentRequestFormData(
		paymentRequest: paymentRequest,
		merchantKey: "put_here_your_commerce_hash_key");

ViewBag.ConnectionURL = "https://sis-t.redsys.es:25443/sis/realizarPago"; // for production environment, replace with https://sis.redsys.es/sis/realizarPago
```

This generates a model (formData) that contains the fields required to fill this html form (example for MVC View):

```HTML
@model RedsysTPV.Models.PaymentFormData
<form name="frm" action="@ViewBag.ConnectionURL" method="POST">
	<input type="hidden" name="Ds_SignatureVersion" value="@Model.Ds_SignatureVersion" />
	<input type="hidden" name="Ds_MerchantParameters" value="@Model.Ds_MerchantParameters" />
	<input type="hidden" name="Ds_Signature" value="@Model.Ds_Signature" />
	<input type="submit" value="Enviar" style="display: none;">
</form>
<script>
	document.forms[0].submit();
</script>
```

The form will be send automatically by the tiny javascript, and the user will see the payment page of the gateway.

### Get payment response:

```csharp
var paymentResponseService = new PaymentResponseService();

var merchantParameters = Convert.ToString(Request["Ds_MerchantParameters"]);
var merchantKey = ConfigurationManager.AppSettings["MerchantKey"];
var platformSignature = Convert.ToString(Request["Ds_Signature"]);

var processedPayment = paymentResponseService.GetProcessedPayment(merchantParameters, merchantKey, platformSignature);

if (processedPayment.IsValidSignature)
{
	// Signature is correct, the request come from trusted source
	if (processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single())
	{
		// Payment accepted: success
		// Update the order on database, etc
	}
	else
	{
		// Payment rejected: fail
		// Update the order on database, etc
	}
}
else
{
	// Signature is not valid, the request come from untrusted source
}
```

## Disclaimer

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY.

## License

The MIT License (MIT)

Copyright (c) 2015 Miguel Ángel Bueno

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
