using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using utlAPI.Models;

namespace utlAPI.DataAccess
{
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
    }
}