using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Option> Options { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}