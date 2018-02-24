using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class VotedViewModel
    {
        public Poll Poll { get; set; }
        public string VotedFor { get; set; }
    }
}