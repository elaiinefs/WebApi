using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface IStripeChargesService
    {
        ChargeCreateOptions Options(int amount, int? currency, string customerEmail, string customerId, string businessName, string businessAddress);

        Charge CreateCharge(ChargeCreateOptions options);
        
        List<Charge> List();

        Year Summary();

        Sales Sales();
    }
}
