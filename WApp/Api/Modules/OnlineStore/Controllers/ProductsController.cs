﻿using System.Collections.Generic;
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

namespace WApp.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IErrorHandlerService _errorService;

        public ProductsController(DbObjectContext context, IConfiguration config, ILogger<ProductsController> logger, IErrorHandlerService errorService)
        {
            _context = context;
            _config = config;
            _logger = logger;
            _errorService = errorService;
        }
        
        [HttpGet, Route("api/v1/[controller]/List")]
        public List<GetProductsView> List()
        {
            return _context.GetProducts.ToList();
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
            try {
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