using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeadManagement.Models
{
    public class TradeShows
    {
        public int Id { get; set; }
        public string TradeShowName { get; set; }
        public string LeadName { get; set; }
        public string EmailAddress { get; set; }
        public string Telepohone { get; set; }
    }
}