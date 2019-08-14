using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ResolutionBy { get; set; }
        public string ResolutionDate { get; set; }
        public string ResolutionComment { get; set; }
        public string Status { get; set; }
        public string StatusReason { get; set; }
        public string IncType { get; set; }
        public string IncCategory { get; set; }
        public string CategoryDescription { get; set; }
        public string CatDetail { get; set; }
        public string AssignedComp { get; set; }
        public string AssignedGrp { get; set; }
        public string Assignee { get; set; }
        public string IncPriority { get; set; }
        public string IncYear { get; set; }
        public string IncMonth { get; set; }
        public string FileId { get; set; }
        public int? Reopened { get; set; }
        public string InvoiceNumber { get; set; }
        public string ReportedBy { get; set; }
    }
}
