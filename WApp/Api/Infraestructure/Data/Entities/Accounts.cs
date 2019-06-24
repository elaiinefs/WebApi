using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Accounts
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountDesc { get; set; }
    }
}
