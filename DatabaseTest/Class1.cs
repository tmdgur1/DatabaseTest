using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class DBMS_Connect
    {
        private string server = "192.168.111.100";
        private string database = "NEWMEMBER";
        private string userID = "newmember";
        private string password = "newmember1234";
        private StringBuilder sb = null;

        private SqlConnection conn = null;

        // Oracle에 접속하기 위해선 Oracle.ManagedDataAccess.dll 파일이 필요합니다
        private static readonly DBMS_Connect ms_sql = new DBMS_Connect();

        public static DBMS_Connect MS_SQL
        {
            get
            {
                return ms_sql;
            }
        }

        public static DBMS_Connect Oracle
        {
            get
            {
                return ms_sql;
            }
        }

        private DBMS_Connect()
        {
            sb = new StringBuilder();
            sb.Append("server='s';database='d';user id='u';password='p'");
            sb.Replace("'s'", server);
            sb.Replace("'d'", database);
            sb.Replace("'u'", userID);
            sb.Replace("'p'", password);
        }

        public T execute<T>(Command<T> cmd)
        {
            return cmd.execute(conn);
        }
        
        public bool open()
        {
            try
            {
                if(conn == null || conn.State == ConnectionState.Closed)
                {
                    conn = new SqlConnection(sb.ToString());
                    conn.Open();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;

        }

        public bool close()
        {
            try
            {
                conn.Close();
                conn = null;
            }
            catch(NullReferenceException nre)
            {
                Console.WriteLine("데이터베이스에 연결되지 않았습니다");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
