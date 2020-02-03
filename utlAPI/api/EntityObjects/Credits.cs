using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace utlAPI.Models
{
    public class Credits
    {
        public int AgentId { get; set; }
        public DateTime DateCredited { get; set; }
        public decimal FloatAmount { get; set; }

        
    }
}