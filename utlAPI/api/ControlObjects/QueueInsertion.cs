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

            try
            {
                MessageQueue msQueue;
                if (!MessageQueue.Exists(".\\private$\\utlagent"))
                {
                    msQueue = MessageQueue.Create(".\\private$\\utlagent");
                    msQueue.Send(agentRequest);
                }
                else
                {
                    msQueue = new MessageQueue(".\\private$\\utlagent");
                    msQueue.Send(agentRequest);
                }
                return "Success!!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        internal string StoreFloatCreditsToQueue(decimal floatAmount, int agentId)
        {
            throw new NotImplementedException();
        }
    }
}