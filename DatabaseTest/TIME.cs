using DatabaseTest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseTest
{
    class TimetoDateTime : Command<DateTime>
    {
        public DateTime execute(OracleConnection conn)
        {
            string query = "select sysdate from dual";
            OracleCommand cmd = new OracleCommand(query, conn);

            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();
            DateTime time = reader.GetDateTime(0);

            reader.Close();

            return time;
        }

        public DateTime execute(SqlConnection conn)
        {
            string query = "select getdate()";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            DateTime time = reader.GetDateTime(0);

            reader.Close();

            return time;
        }
    }
}
