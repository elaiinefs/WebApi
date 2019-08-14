using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class CustInfo
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string LastPurchDate { get; set; }
        public string LastPaidDate { get; set; }
        public string CustTaxRate { get; set; }
        public string TotalPurchase { get; set; }
        public string TotalCostPurchase { get; set; }
        public string PermanentDiscount { get; set; }
        public string FirstPurchaseDate { get; set; }
        public string LastPurchaseDate { get; set; }
    }
}
