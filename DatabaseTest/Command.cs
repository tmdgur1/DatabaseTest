using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    interface Command<T>
    {
        T execute(SqlConnection conn);
        T execute(OracleConnection conn);
    }
}
