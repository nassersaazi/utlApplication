using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using utlAPI.Models;

namespace api.ControlObjects
{
    public class DatabaseHandler
    {
        private Database utlDB;
        private DataTable dt = new DataTable();
        private DbCommand cmd;
        private string connectionString = "conn";
        public class AgentFloatRequest
        {
            public int AgentId;
            public DateTime Sent;
            public int Status;
            public decimal Amount;
        };

        public DatabaseHandler()
        {
            utlDB = DatabaseFactory.CreateDatabase(connectionString);
        }

        public string AddAgentToDb(string Name, string PhoneNumber, decimal FloatAmount)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spSaveAgents", Name, PhoneNumber, FloatAmount );
                int i = utlDB.ExecuteNonQuery(cmd);
                if (i != 0)
                {
                    return "Agent saved.";
                }
                else
                {
                    return "Fehler!!!";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetAdmin(string name, string password)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spGetAdmin", name, password);
                dt = utlDB.ExecuteDataSet(cmd).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    return "Admin existiert";
                }
                else
                {
                    return "Fehler!!!!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Agents GetAgentDetails(int id)
        {
            Agents cust = new Agents();
            try
            {
                cmd = utlDB.GetStoredProcCommand("spGetAgentDetails",id);
                DataTable dt = utlDB.ExecuteDataSet(cmd).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    cust.AgentId = Convert.ToInt32(dt.Rows[0]["AgentId"]);
                    cust.Name = dt.Rows[0]["Name"].ToString();
                    cust.PhoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                    cust.FloatAmount = Convert.ToDecimal(dt.Rows[0]["FloatAmount"]);
                }
                else
                {
                   cust = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cust;

        }

        public string AddAdminToDb(string name, string password)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spSaveAdmins", name, password);
                int i = utlDB.ExecuteNonQuery(cmd);
                if (i != 0)
                {
                    return "Admin saved.";
                }
                else
                {
                    return "Fehler!!!";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}