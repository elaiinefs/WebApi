using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Infraestructure.Core.Services
{
    public interface IErrorHandlerService
    {
        string LogError(Exception error);
    }
}
