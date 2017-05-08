using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    interface Connection
    {
        bool open();
        bool close();
    }

}
