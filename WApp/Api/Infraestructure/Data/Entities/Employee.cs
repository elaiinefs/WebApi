using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public string HireDate { get; set; }
        public string TerminationDate { get; set; }
        public string RateType { get; set; }
        public string Rate { get; set; }
        public string MaritalStatus { get; set; }
        public string Manager { get; set; }
        public string Position { get; set; }
        public string StartDate { get; set; }
        public string UName { get; set; }
    }
}
