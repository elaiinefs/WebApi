using Stripe;
using System.Collections.Generic;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface IStripeService
    {
        string SetKey(string userEmail);

        Token CreateCardToken(Payment paymentInfo);
    }
}
