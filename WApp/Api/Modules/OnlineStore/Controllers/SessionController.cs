using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WApp.Api.Infraestructure.Core.Services;
using WApp.Api.Modules.OnlineStore.Interfaces;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    public class SessionController : Controller
    {
        private readonly IStripeService _stripeService;

        public SessionController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }
        public void SetStripeKey(string BusinessEmail)
        {
            var key = _stripeService.GetKey(BusinessEmail);
            _stripeService.SetKey(key);
        }

    }
}