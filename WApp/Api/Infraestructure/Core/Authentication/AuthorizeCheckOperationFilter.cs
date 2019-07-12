using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Infraestructure.Core.Authentication
{
    public class AuthorizeCheckOperationFilter: IOperationFilter
    {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });
                operation.Responses.Add("403", new Response { Description = "Forbidden" });
                operation.Responses.Add("500", new Response { Description = "Internal Server Error" });

                operation.Description = ".Net Core Main API";
                operation.Summary = "Authenticate to make authorize request to the Main API.";
                operation.ExternalDocs = new ExternalDocs
                {
                    Description="Contact",
                    Url= "https://codepower.io"
                };
                operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
                        new Dictionary<string, IEnumerable<string>> {{ "Bearer", Enumerable.Empty<string>() } }
                };
        }
    }
}
