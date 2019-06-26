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

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OrdersController : Controller
    {

        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public OrdersController(DbObjectContext context, IConfiguration config, ILogger<OrdersController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }
        [HttpGet, Route("api/v1/[controller]/List")]
        public List<GetOrdersView> List()
        {
            return _context.GetOrders.ToList();
        }
        [HttpPost, Route("api/v1/[controller]/Add")]
        public IActionResult Add(Orders order)
        {
            try
            {
                _context.Add(order);
                _context.SaveChanges();
                return Json(new { status = "Success", order });
            }
            catch (Exception e)
            {
                return ErrorResponse(e);
            }
        }
        [HttpPost, Route("api/v1/[controller]/Update")]
        public IActionResult Update(Orders order)
        {
            try
            {
                _context.Update(order);
                _context.SaveChanges();
                return Json(new { status = "Success", order });
            }
            catch (Exception e)
            {
                return ErrorResponse(e);
            }
        }
        [HttpGet, Route("api/v1/[controller]/Delete")]
        public IActionResult Delete(int orderId)
        {
            try
            {
                var order = _context.Orders.First(o => o.Id == orderId);
                order.StatusId = (int)Constants.StatusType.inactive;
                _context.SaveChanges();
                return Json(new { status = "Deleted" });
            }
            catch (Exception e)
            {
                return ErrorResponse(e);
            }
        }

        private IActionResult ErrorResponse(Exception e)
        {
            _logger.LogError("log error", e);
            return Json(new { status = "Error", message = Constants.StatusMessage["Error"] });
        }
    }
}