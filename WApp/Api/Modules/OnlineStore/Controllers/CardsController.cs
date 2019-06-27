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
using System;
using Stripe;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CardsController : Controller
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IErrorHandlerService _errorService;

        public CardsController(DbObjectContext context, IConfiguration config, ILogger<CardsController> logger, IErrorHandlerService errorService)
        {
            _context = context;
            _config = config;
            _logger = logger;
            _errorService = errorService;
        }

        private CreditCardOptions CreateCard(Payment paymentInfo)
        {
            Stripe.CreditCardOptions card = new Stripe.CreditCardOptions();
            card.Name = paymentInfo.CardOwnerFirstName + " " + paymentInfo.CardOwnerLastName;
            card.Number = paymentInfo.CardNumber;
            card.ExpYear = paymentInfo.ExpirationYear;
            card.ExpMonth = paymentInfo.ExpirationMonth;
            card.Cvc = paymentInfo.CVV2;
            return card;
        }

        private Token CreateToken(CreditCardOptions card)
        {
            //Assign Card to Token Object and create Token  
            Stripe.TokenCreateOptions token = new Stripe.TokenCreateOptions();
            token.Card = card;
            Stripe.TokenService serviceToken = new Stripe.TokenService();
            Stripe.Token newToken = serviceToken.Create(token);
            return newToken;
        }
        [HttpPost, Route("api/v1/[controller]/Add")]
        public IActionResult Add(Products product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                return Json(new { status = "Success", product });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        [HttpPost, Route("api/v1/[controller]/Update")]
        public IActionResult Update(Products product)
        {
            try
            {
                _context.Update(product);
                _context.SaveChanges();
                return Json(new { status = "Success", product });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        [HttpGet, Route("api/v1/[controller]/Delete")]
        public IActionResult Deactivate(int productId)
        {
            try
            {
                var product = _context.Products.First(p => p.Id == productId);
                product.StatusId = (int)Constants.StatusType.inactive;
                _context.SaveChanges();
                return Json(new { status = "Deactivated" });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
    }
}