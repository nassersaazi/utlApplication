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

        public string StoreFloatCreditsToQueue(decimal floatAmount, int agentId)
        {
            try
            {
                Credits credit = new Credits();
                credit.AgentId = agentId;
                credit.DateCredited = DateTime.Now;

                credit.FloatAmount = floatAmount;

                MessageQueue msQueue;
                if (!MessageQueue.Exists(".\\private$\\utlcredits"))
                {
                    msQueue = MessageQueue.Create(".\\private$\\utlcredits");
                    msQueue.Send(credit);
                }
                else
                {
                    msQueue = new MessageQueue(".\\private$\\utlcredits");
                    msQueue.Send(credit);
                }
                return "Successfully placed in queue";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

       
        
    }
}