using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class UserSession
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public string Timestamp { get; set; }
        public string Account { get; set; }
        public string Browser { get; set; }
        public string PcInfo { get; set; }
        public string SessionId { get; set; }
    }
}
