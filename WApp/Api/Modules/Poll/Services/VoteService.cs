using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Infraestructure.Data.Entities;
using WApp.Api.Modules.Poll.Interfaces;

namespace WApp.Api.Modules.Poll.Services
{
    public class VoteService : IVoteService
    {
        private readonly DbObjectContext _context;
        private readonly IConfiguration _config;

        public VoteService(DbObjectContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public bool Vote()
        {
            try { 
            var votes = _context.Counts.Where(x=>x.Name == "Votes").FirstOrDefault();
            votes.Total = votes.Total + 1;
            _context.Update(votes);
            _context.SaveChanges();
            return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int Cout()
        {
            return _context.Counts.Where(x => x.Name == "Votes").FirstOrDefault().Total; ;
        }
    }
}
