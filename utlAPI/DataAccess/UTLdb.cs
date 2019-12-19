using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Messaging;
using utlAPI.Models;

namespace utlAPI.DataAccess
{
    public class AgentFloatRequest
    {
        public int AgentId;
        public DateTime Sent;
        public int Status;
        public decimal Amount;
    };

    public class UTLdb
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public void AddAgent(Agents ag)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("spSaveAgents", conn);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.AddWithValue("@Name", ag.Name);
            cmd.Parameters.AddWithValue("@PhoneNumber", ag.PhoneNumber);
            cmd.Parameters.AddWithValue("@FloatAmount", ag.FloatAmount);

            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void AddAdmin(Admins adm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("spSaveAdmins", conn);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.AddWithValue("@Name", adm.Name);

            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void RequestFloat(FloatRequests fr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("spFloatRequests", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AgentId", fr.AgentId);
            cmd.Parameters.AddWithValue("@DateSent", DateTime.Now);
            cmd.Parameters.AddWithValue("@Status", 0);
            cmd.Parameters.AddWithValue("@FloatAmount", fr.FloatAmount);

            cmd.ExecuteNonQuery();
            conn.Close();



        }

        public void RequestFloatsToQueue(FloatRequests fr)
        {
            AgentFloatRequest agentRequest = new AgentFloatRequest();
            agentRequest.AgentId = fr.AgentId;
            agentRequest.Sent = DateTime.Now;
            agentRequest.Status = 0;
            agentRequest.Amount = fr.FloatAmount;
            
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
            
            //SqlCommand cmd = new SqlCommand("spFloatRequests", conn);
            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@AgentId", fr.AgentId);
            //cmd.Parameters.AddWithValue("@DateSent", DateTime.Now);
            //cmd.Parameters.AddWithValue("@Status", 0);
            //cmd.Parameters.AddWithValue("@FloatAmount", fr.FloatAmount);

            //cmd.ExecuteNonQuery();
            //conn.Close();
        }


        public string RequestFloatsFromQueue()
        {
            try
            {
                conn.Open();
                MessageQueue rQueue = new MessageQueue(".\\private$\\utlagent");
                rQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(AgentFloatRequest) });

                Message msg = rQueue.Receive();
                AgentFloatRequest fr = (AgentFloatRequest)msg.Body;

                SqlCommand cmd = new SqlCommand("spFloatRequests", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AgentId", fr.AgentId);
                cmd.Parameters.AddWithValue("@DateSent", fr.Sent);
                cmd.Parameters.AddWithValue("@Status", fr.Status);
                cmd.Parameters.AddWithValue("@FloatAmount", fr.Amount);

                cmd.ExecuteNonQuery();
                conn.Close();

                return "Success";
            }
            catch (Exception)
            {

                return "Failed";
            }
            //string agentId = newAgentRequestFloatAmount.agentId;
            //int FloatRequestId = newAgentRequestFloatAmount.AgentFloatRequestId;
            //string agentTelephone = newAgentRequestFloatAmount.agentTelephoneNumber;
            //double agentCreditamount = newAgentRequestFloatAmount.requestedFloatAmount;
            //SqlCommand cmd = new SqlCommand("creditAgentFloat", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("agentId", agentId);
            //cmd.Parameters.AddWithValue("agentTelephoneNumber", agentTelephone);
            //cmd.Parameters.AddWithValue("floatAmountRequested", agentCreditamount);
            //conn.Open();
            ////AgentFloatRequest agentRequest = new AgentFloatRequest();

            //agentRequest.AgentId = fr.AgentId;
            //agentRequest.Sent = DateTime.Now;
            //agentRequest.Status = 0;
            //agentRequest.Amount = fr.FloatAmount;

            //MessageQueue msQueue;
            //if (!MessageQueue.Exists(".\\private$\\utlagentrequestqueue"))
            //{
            //    msQueue = MessageQueue.Create(".\\private$\\utlagentrequestqueue");
            //    msQueue.Send(agentRequest);
            //}
            //else
            //{
            //    msQueue = new MessageQueue(".\\private$\\utlagentrequestqueue");
            //    msQueue.Send(agentRequest);
            //}
        }

        public List<FloatRequests> GetFloatRequests()
        {
            List<FloatRequests> fr = new List<FloatRequests>();
            conn.Open(); //open connection
            
            SqlCommand cmd = new SqlCommand("spGetAgentsToCredit", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader fetch = cmd.ExecuteReader();

            while (fetch.Read())
            {
                fr.Add(new FloatRequests(
                    Convert.ToInt32(fetch["AgentId"]), 
                    Convert.ToDateTime(fetch["DateSent"]),
                    Convert.ToInt32(fetch["Status"]),
                    Convert.ToDecimal(fetch["FloatAmount"])
                    ));

            }

            return fr;
        }

        public Agents GetAgentDetails(int id)
        {
            
            conn.Open(); //open connection
            SqlCommand query = conn.CreateCommand();
           // query.CommandText = "SELECT * FROM Agents WHERE id =" + id;
            SqlCommand cmd = new SqlCommand("spGetAgentDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AgentId", id);

            SqlDataReader fetch = cmd.ExecuteReader();

            fetch.Read();
            Agents ag = new Agents(Convert.ToInt32(fetch["AgentId"]),
                fetch["Name"].ToString(),
                fetch["PhoneNumber"].ToString(),
                 Convert.ToDecimal(fetch["FloatAmount"]));
          

            return ag;
        }


    }
}