using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using WApp.Api.Modules.OnlineStore.Interfaces;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CustomersController : Controller
    {
        public readonly IStripeCustomerService _stripeCustomerService;
        public CustomersController(IStripeCustomerService stripeCustomerService)
        {
            _stripeCustomerService = stripeCustomerService;
        }
        [HttpGet, Route("List")]
        public List<Customer> List()
        {
            return _stripeCustomerService.List();
        }
    }
}