using Stripe;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface IStripeService
    {
        string GetKey(string userEmail);

        void SetKey(string key);

        CreditCardOptions CreateCard(Payment paymentInfo);

        Token CreateToken(CreditCardOptions card);

        Charge CreateCharge(ChargeCreateOptions options);

        Customer CreateCustomer(Token newToken, Payment paymentInfo, string customerId);

        CustomerService UpdateCustomer(Users user);
    }
}
