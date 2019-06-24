using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Qty { get; set; }
        public bool? TrackInventory { get; set; }
        public bool? Taxable { get; set; }
        public string Weight { get; set; }
        public string Type { get; set; }
        public string VendorId { get; set; }
        public string Collection { get; set; }
        public double? Cost { get; set; }
        public int? StatusId { get; set; }
        public string Notes { get; set; }
        public int? PhotoId { get; set; }
        public int? CouponId { get; set; }
        public double? Tax { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? ModelId { get; set; }
        public string Dimensions { get; set; }
        public string BrandId { get; set; }
        public int? ManufacturerId { get; set; }
        public string Features { get; set; }
        public double? Rating { get; set; }
    }
}
