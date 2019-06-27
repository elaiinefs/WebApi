using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stripe;
using WApp.Api.Infraestructure.Core.Services;
using WApp.Api.Modules.OnlineStore.Services;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    public class SessionController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;
        private readonly IErrorHandlerService _errorService;
        private readonly IStripeService _stripeService;

        public SessionController(IStripeService stripeService, IConfiguration config, ILogger<OrdersController> logger, IOrderService orderService, IErrorHandlerService errorService)
        {
            _config = config;
            _logger = logger;
            _orderService = orderService;
            _errorService = errorService;
            _stripeService = stripeService;
        }
        public void SetStripeKey(string BusinessEmail, IConfiguration _config)
        {
            var applicationStatus = _config.GetSection("testingStatus").Value;
            if (applicationStatus == "")
            {
                applicationStatus = "test";
            }
            var key = _stripeService.GetKey(BusinessEmail, applicationStatus); 
            StripeConfiguration.SetApiKey(key);
        }

    }
}