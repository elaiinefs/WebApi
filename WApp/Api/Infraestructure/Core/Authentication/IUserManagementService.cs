using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Infraestructure.Core.Authentication
{
    public interface IUserManagementService
    {
        bool IsValidUser(string username, string password);
    }
}
