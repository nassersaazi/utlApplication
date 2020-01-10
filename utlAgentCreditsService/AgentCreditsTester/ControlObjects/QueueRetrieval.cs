using AgentCreditsTester.EntityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AgentCreditsTester.ControlObjects
{
    public class QueueRetrieval
    {
        DatabaseHandler dh = new DatabaseHandler();
        public string AgentCreditsFromQueue()
        {
            
            try
            {
                MessageQueue crQueue = new MessageQueue(".\\private$\\utlcredits");
                crQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Credits) });

                Message msg = crQueue.Receive();
                Credits cr = (Credits)msg.Body;
                
                return dh.InsertRequestToDb(cr);





            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
