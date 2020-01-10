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
            Credits credit = new Credits();

            credit.AgentId = AgentId;
            credit.DateCredited = DateTime.Now;
            credit.FloatAmount = FloatAmount;

            try
            {
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