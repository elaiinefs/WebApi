using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;
using WApp.Api.Modules.OnlineStore;

namespace WApp.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;

        public ProductsController(DbObjectContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        
        [HttpGet, Route("api/v1/Products/List")]
        public List<GetProductsView> List()
        {
            var products = _context.GetProducts.ToList();
            return products;
        }
        [HttpPost, Route("api/v1/Products/Add")]
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
                return ErrorResponse();
            }
        }
        [HttpPost, Route("api/v1/Products/Update")]
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
                return ErrorResponse();
            }
        }
        [HttpGet, Route("api/v1/Products/Delete")]
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
                return ErrorResponse();
            }
        }
        private IActionResult ErrorResponse()
        {
            return Json(new { status = "Error", message = Constants.StatusMessage["Error"] });
        }
    }
}