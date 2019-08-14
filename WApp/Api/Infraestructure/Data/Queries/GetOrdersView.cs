using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Infraestructure.Data.Queries
{
    public class GetOrdersView
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string OrderTotal { get; set; }
        public string Items { get; set; }
        public string TaxName { get; set; }
        public string TaxAmount { get; set; }
        public string TaxName2 { get; set; }
        public string TaxAmount2 { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string Discount { get; set; }
        public string Deposit { get; set; }
        public string Vendor { get; set; }
    }
}
