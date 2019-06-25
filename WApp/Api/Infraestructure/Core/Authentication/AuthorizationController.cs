using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Infraestructure.Data.Models;

namespace WApp.Api.Infraestructure.Core.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthenticateService _authService;
        public AuthorizationController(IAuthenticateService authService)
        {
            _authService = authService;
        }
        #region Auth
        [AllowAnonymous]
        [HttpPost, Route("api/Authorize")]
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
        //[HttpGet, Route("api/v1/Authorization/Authorize")]
        //public IRestResponse Authorize()
        //{
        //    var client = new RestClient("https://zaraii.auth0.com/oauth/token");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("content-type", "application/json");
        //    request.AddParameter("application/json", "{\"client_id\":\"ru8txMkO0jwLRfe7z97qtWcZvIGPkqCS\",\"client_secret\":\"AC0QrmYH474VcJBMpAUTrhaDeqfMHtApRkwZl-9zJHCWg3jMJzP38b89uFbBhnNI\",\"audience\":\"https://wapp-api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //}
    }
}