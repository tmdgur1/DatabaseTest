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
    class Oracle_Connect
    {
        private string service = "SOM";
        private string host = "192.168.111.100";
        private string port = "1521";
        private string user = "TEST_USER";
        private string password = "qwer1234";

        private StringBuilder dataSource = null;
        private StringBuilder strConn = null;

        private OracleConnection conn = null;

        // Oracle에 접속하기 위해선 Oracle.ManagedDataAccess.dll 파일이 필요합니다
        private static readonly Oracle_Connect oracle = new Oracle_Connect();

        public static Oracle_Connect Instance
        {
            get
            {
                return oracle;
            }
        }

        private Oracle_Connect()
        {
            dataSource = new StringBuilder();
            dataSource.Append(
                "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)" +
                "(HOST = 'h')" +
                "(PORT = 'p'))" +
                "(CONNECT_DATA =(SERVER = DEDICATED)" +
                "(SERVICE_NAME = 's')))");
            dataSource.Replace("'h'", host);
            dataSource.Replace("'p'", port);
            dataSource.Replace("'s'", service);

            strConn = new StringBuilder();
            strConn.Append(
                "Data Source='d';" +
                "User Id='u';" +
                "Password='p'");
            strConn.Replace("'d'", dataSource.ToString());
            strConn.Replace("'u'", user);
            strConn.Replace("'p'", password);

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
                    conn = new OracleConnection(strConn.ToString());
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
