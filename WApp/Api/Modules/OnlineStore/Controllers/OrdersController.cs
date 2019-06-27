using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;
using WApp.Api.Modules.OnlineStore;
using Microsoft.Extensions.Logging;
using WApp.Api.Infraestructure.Core.Services;
using WApp.Api.Modules.OnlineStore.Services;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;
        private readonly IErrorHandlerService _errorService;

        public OrdersController(IConfiguration config, ILogger<OrdersController> logger, IOrderService orderService, IErrorHandlerService errorService)
        {
            _config = config;
            _logger = logger;
            
            _orderService = orderService;_errorService = errorService;
        }
        [HttpGet, Route("api/v1/[controller]/List")]
        public List<GetOrdersView> List()
        {
            return _orderService.List();
        }
        [HttpPost, Route("api/v1/[controller]/Add")]
        public IActionResult Add(Orders order)
        {
            try
            {
                _orderService.Add(order);
                return Json(new { status = "Success", order });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        [HttpPost, Route("api/v1/[controller]/Update")]
        public IActionResult Update(Orders order)
        {
            try
            {
                _orderService.Update(order);
                return Json(new { status = "Success", order });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        [HttpGet, Route("api/v1/[controller]/Delete")]
        public IActionResult Delete(int orderId)
        {
            try
            {
                _orderService.Delete(orderId);
                return Json(new { status = "Deleted" });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        
    }
}