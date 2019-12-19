using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace utlAPI.Models
{
    public class FloatRequests
    {

        [JsonProperty("agentId")]
        public int AgentId { get; set; }

        [JsonProperty("dateSent")]
        public DateTime DateSent { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("dateCredited")]
        public DateTime DateCredited { get; set; }

        [JsonProperty("floatAmount")]
        public decimal FloatAmount { get; set; }

        public FloatRequests(int AgentId, DateTime DateSent,int Status, decimal FloatAmount)
        {
           
            this.AgentId = AgentId;
            this.DateSent = DateSent;
            this.Status = Status;
           // this.DateCredited = DateCredited;
            this.FloatAmount = FloatAmount;
        }

      
    }
}