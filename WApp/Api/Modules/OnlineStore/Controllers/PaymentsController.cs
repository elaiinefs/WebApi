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
using System;
using Stripe;
using WApp.Api.Modules.OnlineStore.Models;
using Orders = WApp.Api.Infraestructure.Data.Entities.Orders;
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
        [HttpPost, Route("api/v1/[controller]/Pay")]
        public IActionResult Pay([FromBody]Payment paymentInfo)
        {
            try
            {
                if (paymentInfo == null) throw new Exception("Please fill in all required fields.");
                //set business key to receive payment.
                var key= _stripeService.GetKey(paymentInfo.BusinessEmail);
                _stripeService.SetKey(key);

                if (paymentInfo.Buyer_Email == "")
                {
                    paymentInfo.Buyer_Email = "zaraiipay@gmail.com";
                }
                //StripeConfiguration.SetApiKey(_config.GetSection("api_key").Value);

                //Create Card Object to create Token  
                var card = _stripeService.CreateCard(paymentInfo);

                //create card token
                var newToken = _stripeService.CreateToken(card);
                //create local user

                Orders newOrder = new Orders();
                var user = _userService.GetCustomer(paymentInfo.PhoneNumber);
                Customer stripeCustomer;
                //Create Customer Object and Register it on Stripe  
                if (user != null)
                {
                    stripeCustomer = _stripeService.CreateCustomer(newToken, paymentInfo, user.StripeId);
                }
                else
                {
                    stripeCustomer = _stripeService.CreateCustomer(newToken, paymentInfo, null);

                }

                //Create local user Object and register on Application
                var zaraiiUser = _userService.CreateUpdateCustomer(newToken, paymentInfo, null, user, stripeCustomer.Id);

                if (zaraiiUser.Id == 0)
                {
                    newOrder.CustomerId = zaraiiUser.Id;
                    _userService.Add(zaraiiUser);
                }
                else
                {
                    _stripeService.UpdateCustomer(user);
                    _userService.Update(user);
                }

                newOrder.CustomerId = zaraiiUser.Id;
                //var amountTotal = Convert.ToInt32(Amount(paymentInfo.Amount) + "00");
                var amountTotal = Convert.ToInt32(paymentInfo.Amount);
                //ApplicationCharge(amountTotal);
                //Response.Headers.Add("Stripe-Account", "acct_1EHCbXAdyX2SDB4E");

                var requestOptions = new RequestOptions
                {
                    //StripeConnectAccountId = "acct_1EHCbXAdyX2SDB4E",
                    StripeConnectAccountId = "acct_1ELV4AHiHLa6BvdM",
                };
                var businessInfo = _companyService.GetCompany(paymentInfo.BusinessEmail);               
                string businessName, businessAddress, businessPhone;
                if (businessInfo != null)
                {
                    businessName = businessInfo.Name + "- ";
                    businessAddress = businessInfo.Addr + " " +
                                      businessInfo.City + ", " +
                                      businessInfo.State + " " +
                                      businessInfo.Zcode +
                                      ", Phone: " + businessInfo.Phone;
                }
                else
                {
                    businessName = "";
                    businessAddress = "";
                }

                //Create Charge Object with details of Charge  
                var options = new ChargeCreateOptions
                {
                    Amount = amountTotal,
                    Currency = paymentInfo.CurrencyId == 1 ? "ILS" : "USD",
                    ReceiptEmail = paymentInfo.Buyer_Email,
                    Description = businessName + "\n" + businessAddress,
                    CustomerId = stripeCustomer.Id,
                    //ApplicationFeeAmount = Convert.ToInt32(amountTotal * .01),
                    //Description = Convert.ToString(paymentInfo.TransactionId), //Optional  
                };
                //and Create Method of this object is doing the payment execution.  
                var payment = _stripeService.CreateCharge(options);


                newOrder.OrderTotal = amountTotal.ToString();
                newOrder.CreatedDate = DateTime.Now.ToString();
                newOrder.StatusId = 7;
                _orderService.Add(newOrder);
                return Json(new { status = "success", message = "Payment successfully completed.", objectValue = payment });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        
    }
}