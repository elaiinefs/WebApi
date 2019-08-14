using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string Timestamp { get; set; }
        public string User { get; set; }
    }
}
