using FloatRequestsTester.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FloatRequestsTester.ControlOjects
{
    public class QueueRetrieval
    {
        DatabaseHandler dh = new DatabaseHandler();
        public string RequestFloatsFromQueue()
        {
            
            try
            {

                MessageQueue rQueue = new MessageQueue(".\\private$\\utlagent");
                rQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(AgentFloatRequest) });

                Message msg = rQueue.Receive();
                AgentFloatRequest fr = (AgentFloatRequest)msg.Body;

                return dh.InsertRequestToDb(fr);

               
               


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
