using Microsoft.Extensions.Configuration;
using Stripe;
using System.Linq;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public class StripeService: IStripeService
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;

        public StripeService(DbObjectContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        #region Key
        public string GetKey(string userEmail)
        {
            var environment = _config.GetSection("testingStatus").Value;
            if (environment == "")
            {
                environment = "test";
            }
            return _context.Keys.Where(k => k.Name == userEmail && k.Status == environment).FirstOrDefault().Value;
        }
        public void SetKey(string key)
        {
            StripeConfiguration.ApiKey=key;
        }
        #endregion

        #region Card
        public CreditCardOptions CreateCard(Payment paymentInfo)
        {
            Stripe.CreditCardOptions card = new Stripe.CreditCardOptions();
            card.Name = paymentInfo.CardOwnerFirstName + " " + paymentInfo.CardOwnerLastName;
            card.Number = paymentInfo.CardNumber;
            card.ExpYear = paymentInfo.ExpirationYear;
            card.ExpMonth = paymentInfo.ExpirationMonth;
            card.Cvc = paymentInfo.CVV2;
            return card;
        }

        public Token CreateToken(CreditCardOptions card)
        {
            //Assign Card to Token Object and create Token  
            Stripe.TokenCreateOptions token = new Stripe.TokenCreateOptions();
            token.Card = card;
            Stripe.TokenService serviceToken = new Stripe.TokenService();
            Stripe.Token newToken = serviceToken.Create(token);
            return newToken;
        }
        #endregion

        #region Charge
        public Charge CreateCharge(ChargeCreateOptions options)
        {
            var service = new ChargeService();
            Charge charge = service.Create(options);// This will do the Payment
            return charge;
        }
        #endregion
    }
}
