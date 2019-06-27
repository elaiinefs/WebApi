using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Modules;

namespace WApp.Api.Infraestructure.Core.Services
{
    public class ErrorHandlerService : IErrorHandlerService
    {
        private readonly ILogger _logger;

        public ErrorHandlerService(ILogger<ErrorHandlerService> logger)
        {
            _logger = logger;
        }
        public string LogError(Exception error)
        {
            _logger.LogError("log error", error);
            return Constants.StatusMessage["Error"];

        }
    }
}
