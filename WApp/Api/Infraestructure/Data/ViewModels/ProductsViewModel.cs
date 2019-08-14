using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WApp.Api.Infraestructure.Data.Entities;

namespace WApp.Api.Infraestructure.Data.ViewModels
{
    public class ProductsViewModel
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
        public Supplier Vendor { get; set; }
        public string Collection { get; set; }
        public double? Cost { get; set; }
        public Status Status { get; set; }
        public string Notes { get; set; }
        public Files Photo { get; set; }
        [ForeignKey("Id")]
        public Coupon Coupon { get; set; }
        public double? Tax { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public Model Model { get; set; }
        public string Dimensions { get; set; }
        public string Brand { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Features { get; set; }
        public double? Rating { get; set; }
    }

}
