using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace utlServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<RetrieveFloatRequests>(s =>
                {
                    s.ConstructUsing(logging => new RetrieveFloatRequests());
                    s.WhenStarted(logging => logging.Start());
                    s.WhenStopped(logging => logging.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("utlRetrieveFloatRequestsService");
                x.SetDisplayName("UTL Retrieve FloatRequests Service");
                x.SetDescription("This is the service that retrieves agent float requests from queue and inserts them into database");


            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
