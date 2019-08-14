using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string OrderTotal { get; set; }
        public string Items { get; set; }
        public string TaxName { get; set; }
        public string TaxAmount { get; set; }
        public string TaxName2 { get; set; }
        public string TaxAmount2 { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int StatusId { get; set; }
        public string Notes { get; set; }
        public string Discount { get; set; }
        public string Deposit { get; set; }
        public int VendorId { get; set; }
    }
}
