using api.ControlObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Web;
using System.Web.Services;
using utlAPI.Models;

namespace api
{
    /// <summary>
    /// Summary description for utlAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AgentFloatRequest
    {
        public int AgentId;
        public DateTime Sent;
        public int Status;
        public decimal Amount;
    };
    public class utlAPI : System.Web.Services.WebService
    {
        DatabaseHandler dh = new DatabaseHandler();

        QueueInsertion queueInsertion = new QueueInsertion();
        

        [WebMethod(Description = "Insert float requests to queue")]
        public string RequestFloatsToQueue( decimal FloatAmount,int AgentId)
        {
            return queueInsertion.StoreFloatRequestsToQueue(FloatAmount, AgentId);
        }

        [WebMethod(Description = "Insert agent credits to queue")]
        public string FloatCreditsToQueue(decimal FloatAmount, int AgentId)
        {
            return queueInsertion.StoreFloatCreditsToQueue(FloatAmount, AgentId);
        }

        [WebMethod(Description = "Add new agent")]
        public bool AddAgent(string Name,string PhoneNumber,decimal FloatAmount)
        {
           
            return dh.AddAgentToDb(Name, PhoneNumber, FloatAmount);
            

        }

        [WebMethod(Description = "Add new admin")]
        public bool AddAdmin(string Name,string Password)
        {
            return dh.AddAdminToDb(Name, Password);
        }

        [WebMethod]
        public bool GetAdmin(string name, string password)
        {
             
            return dh.GetAdmin(name, password);
        }

        [WebMethod]
        public Agents GetAgentDetails(int id)
        {
            return dh.GetAgentDetails(id);
        }

        [WebMethod]
        public DataTable GetFloatRequests()
        {
            return dh.GetPendingRequests();
        }

        [WebMethod]
        public DataTable GetCredits()
        {
            return dh.GetCreditHistoryTable();
        }

    }
}
