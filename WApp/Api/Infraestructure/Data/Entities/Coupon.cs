using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Coupon
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Amount { get; set; }
        public string Percent { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public bool? OneTimeUse { get; set; }
        public int? OwnerId { get; set; }
        public string Description { get; set; }
    }
}
