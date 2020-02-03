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
    public class DatabaseHandler : IDatabaseHandler
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

        public bool AddAgentToDb(string Name, string PhoneNumber, decimal FloatAmount)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spSaveAgents", Name, PhoneNumber, FloatAmount );
                int i = utlDB.ExecuteNonQuery(cmd);
                return i != 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GetAdmin(string name, string password)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spGetAdmin", name, password);
                dt = utlDB.ExecuteDataSet(cmd).Tables[0];

                return dt.Rows.Count > 0;

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
                return GetRecordDetailsFromDb(dt,cust);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        

        public DataTable GetPendingRequests()
        {
            string storedProcedure = "spGetAgentsToCredit";
            return GetData(storedProcedure);
        }

        public DataTable GetCreditHistoryTable()
        {
            string storedProcedure = "spGetCredits";
            return GetData(storedProcedure);

        }

        public DataTable GetData(string storedProcedure)
        {
            DataTable table = new DataTable();

            try
            {
                cmd = utlDB.GetStoredProcCommand(storedProcedure);

                table = utlDB.ExecuteDataSet(cmd).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }

        

        public bool AddAdminToDb(string name, string password)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spSaveAdmins", name, password);
                int i = utlDB.ExecuteNonQuery(cmd);
                return i != 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Agents GetRecordDetailsFromDb(DataTable dt, Agents cust)
        {
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
            return cust;
        }
    }
}