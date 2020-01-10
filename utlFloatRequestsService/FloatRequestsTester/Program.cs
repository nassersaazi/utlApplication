using FloatRequestsTester.ControlOjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatRequestsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueRetrieval retrieveRequestsFromQueue = new QueueRetrieval();
            while (true)
            {
                Console.WriteLine("Listening for incoming float requests !!!");
                try
                {

                    string pro = retrieveRequestsFromQueue.RequestFloatsFromQueue();
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
