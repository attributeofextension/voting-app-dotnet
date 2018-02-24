using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers.API
{
    public class PollsController : ApiController
    {
        private ApplicationDbContext _context;

        public PollsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/polls/GetPollData/{id}")]
        public IHttpActionResult GetPollData(int id)
        {
            var poll = _context.Polls.SingleOrDefault(p => p.Id == id);

            if (poll == null)
                return NotFound();

            var options = _context.Options.Where(o => o.PollId == poll.Id).ToList();
            poll.Options = options;

            return Ok(poll);
        }
    }
}
