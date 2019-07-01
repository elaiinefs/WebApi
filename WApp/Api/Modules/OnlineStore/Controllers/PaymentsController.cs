using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore;
using Microsoft.Extensions.Logging;
using WApp.Api.Infraestructure.Core.Services;
using Stripe;
using WApp.Api.Modules.OnlineStore.Models;
using WApp.Api.Modules.OnlineStore.Interfaces;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IErrorHandlerService _errorService;
        private readonly IOrderService _orderService;
        private readonly IStripeService _stripeService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public PaymentsController(IUserService userService, ICompanyService companyService, IStripeService stripeService, IConfiguration config, ILogger<PaymentsController> logger, IErrorHandlerService errorService, IOrderService orderService)
        {
            _config = config;
            _logger = logger;
            _errorService = errorService;
            _orderService = orderService;
            _stripeService = stripeService;
            _companyService = companyService;
            _userService = userService;
        }
        [HttpPost, Route("Pay")]
        public IActionResult Pay([FromBody]Payment paymentInfo)
        {
            try
            {
                if (paymentInfo == null) throw new Exception("Please fill in all required fields.");
                
                //set business key to receive payment.
                var key= _stripeService.SetKey(paymentInfo.BusinessEmail);

                //handle empty email address
                var customerEmail = paymentInfo.Buyer_Email == "" ? "zaraiipay@gmail.com" : paymentInfo.Buyer_Email;

                //Create Card Object to create Token  
                var newToken = _stripeService.CreateCardToken(paymentInfo);

                //Create Customer Object and Register it on Stripe  
                Customer stripeCustomer = _stripeService.CreateCustomer(newToken, paymentInfo, null);

                //Create local user Object and register on Application
                var zaraiiUser = _userService.CreateUpdateCustomer(newToken, paymentInfo, null, null, stripeCustomer.Id);

                var amountTotal = Convert.ToInt32(paymentInfo.Amount);

                //get company information
                var businessInfo = _companyService.GetCompany(paymentInfo.BusinessEmail);
                var businessName = _companyService.SetName(businessInfo);
                var businessAddress = _companyService.SetAddress(businessInfo);

                //Create Charge Object with details of Charge  
                var options = _stripeService.Options(amountTotal, paymentInfo.CurrencyId, customerEmail, stripeCustomer.Id, businessName, businessAddress);
      
                //and Create Method of this object is doing the payment execution.  
                var payment = _stripeService.CreateCharge(options);

                //Create local order
                _orderService.Create(zaraiiUser.Id, amountTotal.ToString(), DateTime.Now.ToString());
                
                return Json(new { status = "success", message = "Payment successfully completed.", objectValue = payment });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        
    }
}