using Stripe;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface IStripeService
    {
        string SetKey(string userEmail);

        Token CreateCardToken(Payment paymentInfo);

        ChargeCreateOptions Options(int amount, int? currency, string customerEmail, string customerId, string businessName, string businessAddress);

        Charge CreateCharge(ChargeCreateOptions options);

        Customer CreateCustomer(Token newToken, Payment paymentInfo, string customerId);

        CustomerService UpdateCustomer(Users user);
    }
}
