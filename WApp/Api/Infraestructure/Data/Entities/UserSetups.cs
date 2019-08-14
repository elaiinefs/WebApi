using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class UserSetups
    {
        public int Id { get; set; }
        public int? ReceiveEmails { get; set; }
    }
}
