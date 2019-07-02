using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Modules.OnlineStore.Interfaces;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    public class SummariesController : Controller
    {
        public readonly IStripeChargesService _stripeChargesService;
        public SummariesController(IStripeChargesService stripeChargesService)
        {
            _stripeChargesService = stripeChargesService;
        }
        [HttpGet, Route("Charges")]
        public Year Orders()
        {
            return _stripeChargesService.Summary();
        }
        [HttpGet, Route("Sales")]
        public Sales  GetSales()
        {
            return _stripeChargesService.Sales();
        }
    }
}