using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;
using utlAPI.DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace utlServiceTester
{
    public class RetrieveFloatRequests
    {
      
        Thread receiveRequest;

        public RetrieveFloatRequests()
        {
            receiveRequest = new Thread(new ThreadStart(ReceiveRequests));
          

        }

        public void ReceiveRequests()
        {
            while (true)
            {
                UTLdb dblayer = new UTLdb();
               // string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial" +
                //" Catalog=sp;Integrated Security=True"; //string of database source we are connecting to

               // SqlConnection conn = new SqlConnection(connectionString);
                dblayer.RequestFloatsFromQueue();
                //conn.Open();
                //MessageQueue rQueue = new MessageQueue(".\\private$\\utlagent");
                //rQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(AgentFloatRequest) });

                //Message msg = rQueue.Receive();
                //AgentFloatRequest fr = (AgentFloatRequest)msg.Body;

                //SqlCommand cmd = new SqlCommand("spFloatRequests", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@AgentId", fr.AgentId);
                //cmd.Parameters.AddWithValue("@DateSent", fr.Sent);
                //cmd.Parameters.AddWithValue("@Status", fr.Status);
                //cmd.Parameters.AddWithValue("@FloatAmount", fr.Amount);

                //cmd.ExecuteNonQuery();
                //conn.Close();
            }

        }
        public void Start()
        {
            receiveRequest.Start();
        }

        public void Stop()
        {
            
        }
        
    }
}
