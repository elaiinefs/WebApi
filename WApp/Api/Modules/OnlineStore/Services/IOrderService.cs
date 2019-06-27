using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public interface IOrderService
    {
        List<GetOrdersView> List();
        Orders Add(Orders order);
        Orders Update(Orders order);
        Orders Delete(int orderId);
    }
}
