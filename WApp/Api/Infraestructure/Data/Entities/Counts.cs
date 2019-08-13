using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Counts
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
