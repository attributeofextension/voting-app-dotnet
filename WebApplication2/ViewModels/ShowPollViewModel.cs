using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class ShowPollViewModel
    {
        public Poll Poll { get; set; }
        public Option NewOption { get; set; }
        public List<Option> VoteOptions { get; set; }
        public int VoteId { get; set; }
    }
}