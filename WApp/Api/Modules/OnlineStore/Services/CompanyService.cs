﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.OnlineStore.Interfaces;

namespace WApp.Api.Modules.OnlineStore.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly DbObjectContext _context;

        public CompanyService(DbObjectContext context)
        {
            _context = context;
        }
        public CompInfo GetCompany(string companyEmail)
        {
            return _context.CompInfo.FirstOrDefault(x => x.Email == companyEmail);
        }
        public CompInfo Add(CompInfo product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }
        public CompInfo Update(CompInfo product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
