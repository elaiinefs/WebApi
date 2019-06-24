using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Plans
    {
        public int Id { get; set; }
        public string PlanNumber { get; set; }
        public string PlanType { get; set; }
        public string PlanDesc { get; set; }
        public string PlanPrice { get; set; }
    }
}
