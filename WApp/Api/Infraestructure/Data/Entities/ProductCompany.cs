using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class ProductCompany
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string CompanyId { get; set; }
    }
}
