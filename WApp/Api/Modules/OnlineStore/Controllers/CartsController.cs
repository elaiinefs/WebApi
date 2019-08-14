using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Infraestructure.Core.Services;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    public class CartsController : Controller
    {
        private readonly IErrorHandlerService _errorService;
        private readonly ICartService _productService;

        public CartsController(IErrorHandlerService errorService, ICartService productService)
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
                return Json(new { status = "Success", product });
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
            try
            {
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