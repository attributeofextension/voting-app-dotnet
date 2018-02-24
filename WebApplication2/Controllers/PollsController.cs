using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class PollsController : Controller
    {
        private ApplicationDbContext _context;

        public PollsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Polls
        public ActionResult Index()
        {
            var polls = _context.Polls.ToList();

            return View(polls);
        }

        public ActionResult New()
        {
            var poll = new Poll()
            {
                Options = new List<Option>() {new Option(), new Option()}
            };

            return View(poll);
        }

        [HttpPost]
        public ActionResult AddOption(Poll poll)
        {
            var name = poll.Name;
            poll.Options.Add(new Option());

            return View("New", poll);
        }

        [HttpPost]
        public ActionResult Save(Poll poll)
        {
            if (!ModelState.IsValid)
            {
                return View("New", poll);
            }

            foreach (var option in poll.Options)
            {
                option.PollId = poll.Id;
                _context.Options.Add(option);
            }

            poll.UserId = User.Identity.GetUserId();
            _context.Polls.Add(poll);
            _context.SaveChanges();

            return RedirectToAction("Index", "Polls");
        }

        public ActionResult MyPolls()
        {

            var polls = _context.Polls.ToList().Where(p => p.UserId == User.Identity.GetUserId());

            return View(polls);
        }

        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var poll = _context.Polls.SingleOrDefault(p => p.Id == id);
            if (poll == null)
            {
                return HttpNotFound();
            }

            var options = _context.Options.Where(o => o.PollId == poll.Id).ToList();

            var viewModel = new ShowPollViewModel()
            {
                Poll = poll,
                NewOption = new Option(),
                VoteOptions = options
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult PutOption(ShowPollViewModel viewModel)
        {
            if (viewModel.NewOption.Name == null)
            {
                return RedirectToAction("Show","Polls", new { id=viewModel.Poll.Id});
            }

            var newOption = viewModel.NewOption;
            newOption.PollId = viewModel.Poll.Id;
            _context.Options.Add(newOption);
            _context.SaveChanges();

            return RedirectToAction("Show", "Polls", new { id=viewModel.Poll.Id});

        }

        [HttpPost]
        public ActionResult Voted(ShowPollViewModel viewModel)
        {
            var optionInDb = _context.Options.SingleOrDefault(o => o.Id == viewModel.VoteId);

            optionInDb.Votes++;

            _context.SaveChanges();


            var newViewModel = new VotedViewModel()
            {
                Poll = viewModel.Poll,
                VotedFor = optionInDb.Name,
                
            };

            return View(newViewModel);
        }
    }
}