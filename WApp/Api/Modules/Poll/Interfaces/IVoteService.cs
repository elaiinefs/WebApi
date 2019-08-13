using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WApp.Api.Modules.Poll.Interfaces
{
    public interface IVoteService
    {
        bool Vote();

        int Cout();
    }
}
