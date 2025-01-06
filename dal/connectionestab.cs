using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace dal
{
    public  class connectionestab
    {

        public  SqlConnection  connection()
        {
            string getconnection = ConfigurationManager.ConnectionStrings["cart11"].ConnectionString;
            return new SqlConnection(getconnection);
        }
    }
}
