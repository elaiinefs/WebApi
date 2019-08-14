using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class CustMonthlyAct
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int? CustId { get; set; }
        public string Purch { get; set; }
        public string PaidAmnt { get; set; }
        public string Returns { get; set; }
        public string Credits { get; set; }
        public string Balance { get; set; }
    }
}
