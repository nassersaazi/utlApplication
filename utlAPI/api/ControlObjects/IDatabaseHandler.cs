using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utlAPI.Models;

namespace api.ControlObjects
{
    public interface IDatabaseHandler
    {
        bool AddAgentToDb(string Name, string PhoneNumber, decimal FloatAmount);

        bool GetAdmin(string name, string password);

        Agents GetAgentDetails(int id);

        DataTable GetPendingRequests();

        DataTable GetData(string storedProcedure);

        bool AddAdminToDb(string name, string password);

        Agents GetRecordDetailsFromDb(DataTable dt, Agents cust);
    }
}
