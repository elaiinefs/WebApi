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

        #region Charge
        public ChargeCreateOptions Options (int amount, int? currency, string customerEmail, string customerId, string businessName, string businessAddress)
        {
            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = currency == 1 ? "ILS" : "USD",
                ReceiptEmail = customerEmail,
                Description = businessName + "\n" + businessAddress,
                CustomerId = customerId,
                //ApplicationFeeAmount = Convert.ToInt32(amountTotal * .01),
                //Description = Convert.ToString(paymentInfo.TransactionId), //Optional  
            };
            return options;
        }
        public Charge CreateCharge(ChargeCreateOptions options)
        {
            var service = new ChargeService();
            Charge charge = service.Create(options);// This will do the Payment
            return charge;
        }

        public List<Charge> List()
        {
            //StripeConfiguration.SetApiKey(_config.GetSection("api_key").Value);

            var service = new ChargeService();
            service.ExpandCustomer = true;
            service.ExpandOrder = true;
            var options = new ChargeListOptions
            {
                Limit = 100,
            };
            var orders = service.List(options);
            foreach (var order in orders)
            {
                order.Created = order.Created.Date;
                order.Amount = order.Amount;
                order.AmountRefunded = order.AmountRefunded;
                if (order.Customer != null)
                {
                    if (order.Customer.Email == "zaraiipay@gmail.com")
                    {
                        order.Customer.Email = "";
                    }
                }
            }
            return orders.Data;
        }
        #endregion

        #region Customer
        public Customer CreateCustomer(Token newToken, Payment paymentInfo, string customerId)
        {
            var service = new CustomerService();
            Customer stripeCustomer;
            if (customerId != null)
            {
                stripeCustomer = service.Get(customerId);
            }
            else
            {
                CustomerCreateOptions myCustomer = new CustomerCreateOptions();
                myCustomer.Email = paymentInfo.Buyer_Email;
                var customerService = new CustomerService();
                stripeCustomer = customerService.Create(myCustomer);
            }
            return stripeCustomer;
        }

        public CustomerService UpdateCustomer(Users user)
        {
            var options = new CustomerUpdateOptions
            {
                Email = user.Email,
                Description = "Zaraii Pay Customer",
                //Metadata = new Dictionary<string, string>
                //{
                //    { "order_id", "6735" },
                //},
            };
            var customerService = new CustomerService();
            customerService.Update(user.StripeId, options);
            return customerService;
        }
        #endregion

    }
}
