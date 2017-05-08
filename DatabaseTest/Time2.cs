using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseTest
{
    class TimetoString : Command<string>
    {
        public string execute(OracleConnection conn)
        {
            throw new NotImplementedException();
        }

        public string execute(SqlConnection conn)
        {
            string query = "select getdate()";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            string time = reader.GetDateTime(0).ToString();

            reader.Close();

            return time;
        }
    }
}
