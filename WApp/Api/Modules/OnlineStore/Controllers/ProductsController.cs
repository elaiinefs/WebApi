using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;
using WApp.Api.Modules.OnlineStore;
using Microsoft.Extensions.Logging;

namespace WApp.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public ProductsController(DbObjectContext context, IConfiguration config, ILogger<ProductsController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }
        
        [HttpGet, Route("api/v1/[controller]/List")]
        public List<GetProductsView> List()
        {
            var products = _context.GetProducts.ToList();
            return products;
        }
        [HttpPost, Route("api/v1/[controller]/Add")]
        public IActionResult Add(Products product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                return Json(new {status = "Success", product });
            }
            catch
            {
                _logger.LogError("log error");
                return ErrorResponse();
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
            catch
            {
                _logger.LogError("log error");
                return ErrorResponse();
            }
        }
        [HttpGet, Route("api/v1/[controller]/Delete")]
        public IActionResult Deactivate(int productId)
        {
            try {
            var product = _context.Products.First(p => p.Id == productId);
            product.StatusId = (int)Constants.StatusType.inactive;
            _context.SaveChanges();
                return Json(new { status = "Deactivated" });
            }
            catch
            {
                _logger.LogError("log error");
                return ErrorResponse();
            }
        }
        private IActionResult ErrorResponse()
        {
            return Json(new { status = "Error", message = Constants.StatusMessage["Error"] });
        }
    }
}