using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class UserCredentials
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserCode { get; set; }
        public string LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
