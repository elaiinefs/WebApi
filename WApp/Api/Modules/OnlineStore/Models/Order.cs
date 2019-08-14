using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Modules.OnlineStore.Models
{
    public class Order
    {
        public string orderNumber { get; set; }
        public string createdDate { get; set; }
        public string createdBy { get; set; }
        public string orderTotal { get; set; }
        public string taxAmount { get; set; }
        public string taxAmount2 { get; set; }
        public string customer { get; set; }
        public string status { get; set; }
    }
}
