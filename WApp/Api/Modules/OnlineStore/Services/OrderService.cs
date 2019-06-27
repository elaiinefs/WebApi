using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;
using WApp.Api.Modules;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger _logger;
        private readonly DbObjectContext _context;

        public OrderService(DbObjectContext context, ILogger<OrderService> logger)
        {
            _logger = logger;
            _context = context;
        }
        public List<GetOrdersView> List()
        {
            return _context.GetOrders.ToList();
        }
        public Orders Add(Orders order)
        {
                _context.Add(order);
                _context.SaveChanges();
                return order;
        }
        public Orders Update(Orders order)
        {
            _context.Update(order);
            _context.SaveChanges();
            return order;
        }
        public Orders Delete(int orderId)
        {
            var order = _context.Orders.First(o => o.Id == orderId);
            order.StatusId = (int)Constants.StatusType.inactive;
            _context.SaveChanges();
            return order;
        }
    }
}
