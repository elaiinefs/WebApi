using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public class ProductService:IProductService
    {
        private readonly ILogger _logger;
        private readonly DbObjectContext _context;

        public ProductService(DbObjectContext context, ILogger<ProductService> logger)
        {
            _logger = logger;
            _context = context;
        }
        public List<GetProductsView> List()
        {
            return _context.GetProducts.ToList();
        }
        public Products Add(Products product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }
        public Products Update(Products product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return product;
        }
        public Products Delete(int productId)
        {
            var product = _context.Products.First(o => o.Id == productId);
            product.StatusId = (int)Constants.StatusType.inactive;
            _context.SaveChanges();
            return product;
        }
    }
}
