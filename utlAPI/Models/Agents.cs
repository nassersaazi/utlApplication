using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace utlAPI.Models
{
    public class Agents
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public decimal FloatAmount { get; set; }

        public Agents(int AgentId,string Name,string PhoneNumber,decimal FloatAmount)
        {
            this.AgentId = AgentId;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.FloatAmount = FloatAmount;
        }
    }
}