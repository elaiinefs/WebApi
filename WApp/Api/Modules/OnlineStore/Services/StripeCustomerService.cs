using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Interfaces;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public class StripeCustomerService: IStripeCustomerService
    {

        public List<Customer> List()
        {
            //StripeConfiguration.SetApiKey(_config.GetSection("api_key").Value);
            var service = new CustomerService();
            var options = new CustomerListOptions
            {
                Limit = 100,
            };
            var customers = service.List(options);
            foreach (var customer in customers)
            {
                if (customer.Email == "zaraiipay@gmail.com")
                {
                    customer.Email = "";
                }
            }
            return customers.Data;
        }

        public Customer Create(Token newToken, Payment paymentInfo, string customerId)
        {
            var service = new CustomerService();
            Customer stripeCustomer;
            if (customerId != null)
            {
                stripeCustomer = service.Get(customerId);
            }
            else
            {
                Stripe.CustomerCreateOptions myCustomer = new CustomerCreateOptions();
                myCustomer.Email = paymentInfo.Buyer_Email;
                myCustomer.Phone = paymentInfo.PhoneNumber;
                myCustomer.Source = newToken.Id;
                var customerService = new CustomerService();
                stripeCustomer = customerService.Create(myCustomer);
            }
            return stripeCustomer;
        }

        public CustomerService Update(Users user)
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


        public int Count()
        {
            var customer = new CustomerService();
            var custOptions = new CustomerListOptions
            {
                Limit = 100,
            };
            return customer.List(custOptions).Count();
        }
    }
}
