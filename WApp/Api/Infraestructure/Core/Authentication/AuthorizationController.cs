using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WApp.Api.Infraestructure.Core.Authentication
{
    public class AuthorizationController : Controller
    {
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