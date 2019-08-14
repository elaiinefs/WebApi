using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Modules.Poll.Interfaces;

namespace WApp.Api.Modules.Poll.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class VotesController : Controller
    {
        public readonly IVoteService _voteService;
        public VotesController(IVoteService voteService)
        {
            _voteService = voteService;
        }
        [HttpPost, Route("Vote")]
        public IActionResult Vote()
        {
            var vote = _voteService.Vote();
            return Json(new { status = "success", message = vote });
        }
        [HttpPost, Route("Cout")]
        public IActionResult Cout()
        {
            return Json(new { status = "success", message = _voteService.Vote() });
        }
    }
}