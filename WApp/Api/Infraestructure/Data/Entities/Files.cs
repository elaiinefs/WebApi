using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Files
    {
        public int Id { get; set; }
        public string Target { get; set; }
        public string Filename { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Data { get; set; }
        public string Parent { get; set; }
    }
}
