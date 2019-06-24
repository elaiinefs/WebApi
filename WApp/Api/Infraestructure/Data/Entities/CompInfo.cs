using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class CompInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addr { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zcode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebPage { get; set; }
        public string Desc { get; set; }
        public string Email { get; set; }
    }
}
