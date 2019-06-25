using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OrdersController : Controller
    {
        [HttpGet, Route("api/v1/[controller]/List")]
        public IActionResult List()
        {
            var ordersList = new List<Orders>.Enumerator();
            return Json(ordersList);
        }
    }
}