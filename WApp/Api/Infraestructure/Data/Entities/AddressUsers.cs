using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class AddressUsers
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AddressId { get; set; }
    }
}
