using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouchLess_Answer.Models
{
    public class Sesstion
    {
        public int SessionID { get; set; }
        public string Platenumber { get; set; }
        public int Intime { get; set; }
        public string Outtime { get; set; }
        public string INAgentMACID { get; set; }
        public string OUTAgentMACID { get; set; }
        public string Status { get; set; }
    }
}