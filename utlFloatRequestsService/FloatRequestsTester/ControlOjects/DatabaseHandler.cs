using FloatRequestsTester.EntityObjects;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatRequestsTester.ControlOjects
{
    public class DatabaseHandler
    {
        private Database utlDB;
        
        private DbCommand cmd;
        private string connectionString = "conn";
       

        public DatabaseHandler()
        {
            utlDB = DatabaseFactory.CreateDatabase(connectionString);
        }

        public  string InsertRequestToDb(EntityObjects.AgentFloatRequest fr)
        {
            try
            {
                cmd = utlDB.GetStoredProcCommand("spFloatRequests", fr.AgentId, fr.Sent,fr.Status, fr.Amount);
                int i = utlDB.ExecuteNonQuery(cmd);
                if (i != 0)
                {
                    return "Request saved.";
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
