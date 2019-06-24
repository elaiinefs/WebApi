using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Keys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Parent { get; set; }
        public string Status { get; set; }
    }
}
