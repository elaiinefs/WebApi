using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Modules.OnlineStore
{
    public class Constants
    {
        public static Dictionary<string, string> StatusMessage = new Dictionary<string, string>
        {
            { "Success", "Successfully completed. " },
            { "Error", "An error occurred, please try again later." },
            { "Null", "No item found with the specified characteristics, please try again later." }
        };
        public enum StatusType
        {
            active = 1,
            inactive = 2,
            soldOut = 3
        }
    }
}
