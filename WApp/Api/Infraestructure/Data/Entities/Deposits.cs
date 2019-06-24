using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Deposits
    {
        public int Id { get; set; }
        public string InvNumber { get; set; }
        public string Iamount { get; set; }
        public string Date { get; set; }
        public string TypeofPayment { get; set; }
        public string UserId { get; set; }
    }
}
