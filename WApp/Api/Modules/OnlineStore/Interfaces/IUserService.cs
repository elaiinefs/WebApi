using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface IUserService
    {
        Users GetCustomer(string phoneNumber);

        Users CreateUpdateCustomer(Token newToken, Payment paymentInfo, string customerId, Users user, string stripeCustomerId);

        void Add(Users user);

        void Update(Users user);
    }
}
