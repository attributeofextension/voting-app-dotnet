using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Votes { get; set; }
        public int PollId { get; set; }
    }
}