using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Modules.OnlineStore.Interfaces;

namespace WApp.Api.Infraestructure.Core.Authentication
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserService _userService;

        public UserManagementService(IUserService userService)
        {
            _userService = userService;
        }
        public bool IsValidUser(string userName, string password)
        {
            var user= _userService.GetUserByEmail(userName);
            if(user != null)
            {
                return true;
            }
            return false;
        }
    }
}
