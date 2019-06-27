using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public interface IStripeService
    {
        string GetKey(string userEmail);

        void SetKey(string key);

        CreditCardOptions CreateCard(Payment paymentInfo);

        Token CreateToken(CreditCardOptions card);

        Charge CreateCharge(ChargeCreateOptions options);
    }
}
