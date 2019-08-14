using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class PopUpsMessage
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public string UserId { get; set; }
    }
}
