using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class UserFile
    {
        public int Id { get; set; }
        public int? PhotoId { get; set; }
        public int? UserId { get; set; }
    }
}
