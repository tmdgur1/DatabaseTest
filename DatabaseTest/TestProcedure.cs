using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace DatabaseTest
{
    class TestProcedure : Command<List<AreaComboBox>>
    {
        public List<AreaComboBox> execute(OracleConnection conn)
        {
            throw new NotImplementedException();
        }

        public List<AreaComboBox> execute(SqlConnection conn)
        {
            List<AreaComboBox> list = new List<AreaComboBox>();

            string query = "KSH_AREA_COMBO_LIST";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AreaComboBox area = new AreaComboBox();
                area.Project_nm = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                area.Module_nm = reader.IsDBNull(1) ? "NULL" : reader.GetString(1);
                area.Deck_cd = reader.IsDBNull(2) ? "NULL" : reader.GetString(2);

                list.Add(area);
            }

            reader.Close();

            return list;
        }
    }
}
