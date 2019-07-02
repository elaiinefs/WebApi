using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Modules.OnlineStore.Models
{
    public class Year
    {
        public int jan { get; set; }
        public int feb { get; set; }
        public int mar { get; set; }
        public int apr { get; set; }
        public int may { get; set; }
        public int jun { get; set; }
        public int jul { get; set; }
        public int aug { get; set; }
        public int sep { get; set; }
        public int oct { get; set; }
        public int nov { get; set; }
        public int dec { get; set; }
        public long yearTotal { get; set; }
        public long refundedTotal { get; set; }
        public int totalOrders { get; set; }
        public int totalCustomers { get; set; }
    }
}
