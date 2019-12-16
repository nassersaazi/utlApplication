using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace utlAPI.Models
{
    public class FloatRequests
    {
        public int RequestId { get; set; }
        public int AgentId { get; set; }
        public DateTime DateSent { get; set; }
        public int Status { get; set; }
        public DateTime DateCredited { get; set; }
        public decimal FloatAmount { get; set; }
    }
}