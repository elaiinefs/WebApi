using Microsoft.Extensions.Configuration;
using Stripe;
using System.Collections.Generic;
using System.Linq;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Interfaces;
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
        public string SetKey(string userEmail)
        {
            var environment = _config.GetSection("testingStatus").Value;
            if (environment == ""|| environment == null)
            {
                environment = "test";
            }
            var key = _context.Keys.Where(k => k.Name == userEmail && k.Status == environment).FirstOrDefault().Value;
            StripeConfiguration.ApiKey = key;
            return key;
        }
        #endregion

        #region Card
        public Token CreateCardToken(Payment paymentInfo)
        {
            Stripe.CreditCardOptions card = new Stripe.CreditCardOptions();
            card.Name = paymentInfo.CardOwnerFirstName + " " + paymentInfo.CardOwnerLastName;
            card.Number = paymentInfo.CardNumber;
            card.ExpYear = paymentInfo.ExpirationYear;
            card.ExpMonth = paymentInfo.ExpirationMonth;
            card.Cvc = paymentInfo.CVV2;
            CreateToken(card);
            return CreateToken(card);
        }

        private Token CreateToken(CreditCardOptions card)
        {
            //Assign Card to Token Object and create Token  
            Stripe.TokenCreateOptions token = new Stripe.TokenCreateOptions();
            token.Card = card;
            Stripe.TokenService serviceToken = new Stripe.TokenService();
            Stripe.Token newToken = serviceToken.Create(token);
            return newToken;
        }
        #endregion
        
    }
}
