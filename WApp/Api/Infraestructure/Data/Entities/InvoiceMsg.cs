using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class InvoiceMsg
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string InvoiceId { get; set; }
    }
}
