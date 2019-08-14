using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string StreetNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
