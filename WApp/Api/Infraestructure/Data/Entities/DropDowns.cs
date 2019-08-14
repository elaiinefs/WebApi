using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class DropDowns
    {
        public int Id { get; set; }
        public string DdName { get; set; }
        public string DdDesc { get; set; }
        public string DdCategory { get; set; }
        public string DdInfo { get; set; }
    }
}
