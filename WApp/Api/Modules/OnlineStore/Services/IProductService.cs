using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Infraestructure.Data.Queries;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public interface IProductService
    {
        List<GetProductsView> List();
        Products Add(Products product);
        Products Update(Products product);
        Products Delete(int productId);
    }
}
