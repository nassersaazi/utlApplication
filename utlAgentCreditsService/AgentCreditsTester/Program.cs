using AgentCreditsTester.ControlObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentCreditsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueRetrieval retrieveRequestsFromQueue = new QueueRetrieval();
            while (true)
            {
                Console.WriteLine("Listening for incoming agent credits !!!");
                try
                {

                    string pro = retrieveRequestsFromQueue.AgentCreditsFromQueue();
                    Console.WriteLine(pro);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
