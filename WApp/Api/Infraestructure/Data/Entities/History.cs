using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class History
    {
        public int Id { get; set; }
        public string HistoryTitle { get; set; }
        public string HistoryDesc { get; set; }
        public string HistoryDate { get; set; }
        public int? UserId { get; set; }
        public string Browser { get; set; }
        public string PcInfo { get; set; }
        public string UserAccount { get; set; }
        public string UserEmail { get; set; }
    }
}
