using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public interface IStripeService
    {
        string GetKey(string userEmail, string environment);
    }
}
