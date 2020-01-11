using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;
using utlAPI.Models;

namespace api.ControlObjects
{   
    public class QueueInsertion
    {
        
        public string StoreFloatRequestsToQueue(decimal FloatAmount, int AgentId)
        {
            AgentFloatRequest agentRequest = new AgentFloatRequest();
            agentRequest.AgentId = AgentId;
            agentRequest.Sent = DateTime.Now;
            agentRequest.Status = 0;
            agentRequest.Amount = FloatAmount;
            string queueName = "utlagent";

            return insertInQueue(agentRequest, queueName);
        }

        public string StoreFloatCreditsToQueue(decimal floatAmount, int agentId)
        {

            Credits credit = new Credits();
            credit.AgentId = agentId;
            credit.DateCredited = DateTime.Now;

            credit.FloatAmount = floatAmount;
            string queueName = "utlcredits";

            return insertInQueue(credit, queueName);
        }

        private string insertInQueue(Object ag,string queueName)
        {
            try
            {
                MessageQueue msQueue;
                if (!MessageQueue.Exists(".\\private$\\" + queueName))
                {
                    msQueue = MessageQueue.Create(".\\private$\\" + queueName);
                    msQueue.Send(ag);
                }
                else
                {
                    msQueue = new MessageQueue(".\\private$\\" + queueName);
                    msQueue.Send(ag);
                }
                return "Success!!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        

       
        
    }
}