using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentCreditsTester.EntityObjects;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AgentCreditsTester.ControlObjects
{
    public class DatabaseHandler
    {
        private Database utlDB;

        private DbCommand cmd,com;
        private string connectionString = "conn";


        public DatabaseHandler()
        {
            utlDB = DatabaseFactory.CreateDatabase(connectionString);
        }
        public string InsertRequestToDb(Credits cr )
        {   
            try
            {
                cmd = utlDB.GetStoredProcCommand("spUpdateRequestStatus", cr.AgentId, cr.DateCredited);
                int i = utlDB.ExecuteNonQuery(cmd);
                if (i != 0)
                {
                    com = utlDB.GetStoredProcCommand("spUpdateAgentFloatAmount", cr.AgentId, cr.FloatAmount);
                    int j = utlDB.ExecuteNonQuery(com);
                    if (j != 0)
                    {
                        return "Success";
                    }

                    return "Updated status but not FloatAmount of agent";
                }
                else
                {
                    return "Fehler!!! Nichts wurde gespeichert.Bist du doof?????";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
