using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public class StripeService
    {
        private readonly DbObjectContext _context;

        public StripeService(DbObjectContext context)
        {
            _context = context;
        }
        public string GetKey(string userEmail, string environment)
        {
            return _context.Keys.Where(k => k.Name == userEmail && k.Status == environment).FirstOrDefault().Value;
        }
    }
}
