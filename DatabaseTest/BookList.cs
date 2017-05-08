using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DatabaseTest
{
    class BookList : Command<object>
    {
        public object execute(OracleConnection conn)
        {
            string query = "test_user.SHK_BOOK_LIST_PACKAGE.book_list";
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter("o_cur", OracleDbType.RefCursor)).Direction = ParameterDirection.Output;
            cmd.CommandText = query;

            // 실행
            OracleDataReader reader = cmd.ExecuteReader();

            // 리스트 받기
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string str = reader.IsDBNull(i) ? "" : reader[i].ToString();
                    Console.Write("{0}\t", str);
                }
                Console.WriteLine();
            }

            reader.Close();

            return null;
        }

        public object execute(SqlConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
