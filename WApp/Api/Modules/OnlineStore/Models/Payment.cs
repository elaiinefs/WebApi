using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Modules.OnlineStore.Models
{
    public class Payment
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string CardOwnerFirstName { get; set; }
        public string CardOwnerLastName { get; set; }
        public string CardNumber { get; set; }
        public long ExpirationYear { get; set; }
        public long ExpirationMonth { get; set; }
        public string CVV2 { get; set; }
        public string Buyer_Email { get; set; }
        public long Amount { get; set; }
        public int? CurrencyId { get; set; }
        public int? TransactionId { get; set; }
        public string ChargeId { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessEmail { get; set; }
    }
}
