using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Infraestructure.Data.Models;
using WApp.Api.Modules.OnlineStore.Interfaces;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Infraestructure.Core.Authentication
{
    [Route("api/v1")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthenticateService _authService;
        private readonly IStripeService _stripeService;

        public AuthorizationController(IAuthenticateService authService, IStripeService stripeService)
        {
            _authService = authService;
            _stripeService = stripeService;
        }
        #region Auth
        [AllowAnonymous]
        [HttpPost, Route("RequestToken")]
        public ActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (_authService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");

        }
        #endregion
        #region Stripe
        [AllowAnonymous]
        [HttpPost, Route("Authorize")]
        public ActionResult Stripe([FromBody]Payment paymentInfo)
        {
            SetStripeKey(paymentInfo.Buyer_Email);
            TokenRequest request = new TokenRequest();
            request.Username = paymentInfo.Buyer_Email;
            string token;
            if (_authService.IsAuthenticated(request, out token))
            {
                return Json(new {token = token });
            }
            return BadRequest("Invalid Request");
        }
        [HttpPost, Route("SetStripeKey")]
        public void SetStripeKey(string BusinessEmail)
        {
            var key = _stripeService.SetKey(BusinessEmail);
            //_stripeService.SetKey(key);
        }
        #endregion
    }
}