using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public  class product : connectionestab 
    {
        DataTable product1 = new DataTable();
        public DataTable productinfo()
        {
            connectionestab ob1 = new connectionestab();
            using(SqlConnection con = ob1.connection())
            {
                SqlDataAdapter d11 = new SqlDataAdapter("Select * from product", con);
                d11.Fill(product1);
                return product1;

            }
        }
    }
}
