using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer
{
    public class sqlConnection
    {
        public SqlConnection con;
        public SqlConnection Connection()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-S10PVA3;Initial Catalog=Northwind;Integrated Security=True");
            con.Open();
            return con;
        }
    }
}
