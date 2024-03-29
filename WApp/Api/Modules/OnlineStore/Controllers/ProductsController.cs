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
using WApp.Api.Modules.OnlineStore.Interfaces;

namespace WApp.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IErrorHandlerService _errorService;
        private readonly IProductService _productService;

        public ProductsController(IErrorHandlerService errorService, IProductService productService)
        {
            _errorService = errorService;
            _productService = productService;
        }
        
        [HttpGet, Route("List")]
        public List<GetProductsView> List()
        {
            return _productService.List();
        }
        [HttpPost, Route("Add")]
        public IActionResult Add(Products product)
        {
            try
            {
                _productService.Add(product);
                return Json(new {status = "Success", product });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        [HttpPost, Route("Update")]
        public IActionResult Update(Products product)
        {
            try
            {
                _productService.Update(product);
                return Json(new { status = "Success", product });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
        [HttpGet, Route("Delete")]
        public IActionResult Delete(int productId)
        {
            try {
                _productService.Delete(productId);
                return Json(new { status = "Deleted" });
            }
            catch (Exception e)
            {
                return Json(new { status = "Error", message = _errorService.LogError(e) });
            }
        }
    }
}