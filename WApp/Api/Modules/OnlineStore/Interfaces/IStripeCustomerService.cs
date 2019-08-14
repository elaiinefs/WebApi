using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface IStripeCustomerService
    {
        List<Customer> List();

        Customer Create(Token newToken, Payment paymentInfo, string customerId);

        CustomerService Update(Users user);

        int Count();
    }
}
