using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DBMS_Connect.MS_SQL.open();

            DateTime time = DBMS_Connect.MS_SQL.execute(new TimetoDateTime());
            string time2 = DBMS_Connect.MS_SQL.execute(new TimetoString());
            List<AreaComboBox> list = DBMS_Connect.MS_SQL.execute(new TestProcedure());

            Console.WriteLine(time2);

            foreach(AreaComboBox area in list)
            {
                Console.WriteLine("{0}\t{1}\t{2}", area.Project_nm, area.Module_nm, area.Deck_cd);
            }
            

            DBMS_Connect.MS_SQL.close();
            */

            Oracle_Connect.Instance.open();
            Oracle_Connect.Instance.execute(new BookList());
            //DateTime time = Oracle_Connect.Instance.execute(new TimetoDateTime());

            //Console.WriteLine(time);

            Oracle_Connect.Instance.close();
        }
    }
}