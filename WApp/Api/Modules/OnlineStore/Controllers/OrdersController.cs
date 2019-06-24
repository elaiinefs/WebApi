using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult List()
        {
            var ordersList = new List<Orders>.Enumerator();
            return Json(ordersList);
        }
    }
}