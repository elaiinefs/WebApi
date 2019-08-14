using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Supplier
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string AccountNumber { get; set; }
        public string DiscountPercent { get; set; }
        public string DiscountDays { get; set; }
        public string LastPurchasetoVendor { get; set; }
        public string LastPaymenttoVendor { get; set; }
        public string StoreName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public byte[] UpdatedDate { get; set; }
    }
}
