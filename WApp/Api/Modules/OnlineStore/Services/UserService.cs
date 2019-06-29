using Microsoft.Extensions.Configuration;
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
    public class UserService: IUserService
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;
        private readonly IStripeService _stripeService;

        public UserService(IStripeService stripeService, DbObjectContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _stripeService = stripeService;
        }
        #region Customer
        public Users GetCustomer(string phoneNumber)
        {
            return _context.Users.Where(u => u.Phone == phoneNumber && phoneNumber != null && phoneNumber != "").FirstOrDefault();

        }

        public Users CreateUpdateCustomer(Token newToken, Payment paymentInfo, string customerId, Users user, string stripeCustomerId)
        {
            if (user == null)
            {
                Users newUser = new Users();
                newUser.Email = paymentInfo.Buyer_Email;
                newUser.FName = paymentInfo.CardOwnerFirstName;
                newUser.LName = paymentInfo.CardOwnerLastName;
                newUser.CreatedDate = DateTime.Now.ToString();
                newUser.Phone = paymentInfo.PhoneNumber;
                newUser.Business = 1.ToString();
                newUser.Status = "Active";
                newUser.StripeId = stripeCustomerId;
                Add(newUser);
                return newUser;
            }
            else
            {

                user.Email = paymentInfo.Buyer_Email;
                user.FName = paymentInfo.CardOwnerFirstName;
                user.LName = paymentInfo.CardOwnerLastName;
                user.ModifiedDate = DateTime.Now.ToString();
                user.Phone = paymentInfo.PhoneNumber;
                user.StripeId = stripeCustomerId;
                user.Business = (Convert.ToInt32(user.Business) + 1).ToString();//number of orders
                user.Status = "Active";
                //newOrder.Customer = user.Id.ToString();
                Update(user);
                _stripeService.UpdateCustomer(user);
                return user;
            }
        }
        #endregion Customer

        public void Add(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(Users user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
