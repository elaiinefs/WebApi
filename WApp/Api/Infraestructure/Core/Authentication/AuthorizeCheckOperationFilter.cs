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
                operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
                        new Dictionary<string, IEnumerable<string>> {{ "Bearer", Enumerable.Empty<string>() } }
                };
        }
    }
}
