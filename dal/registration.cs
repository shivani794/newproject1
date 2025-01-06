using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace dal
{
    public class register
    {
        public int userid { get; set; }
        public string name { get; set; }
        public dynamic username { get; set; }
        public dynamic password { get; set; }
        public int mobilenumber { get; set; }
    }
    public class GetUsers : connectionestab
    {
        //for every table at the backend end cretae a new table at the frontend
       
        
        DataTable usertable = new DataTable();
        public DataTable getusers()
        {
            connectionestab ob = new connectionestab();
            using (SqlConnection con = ob.connection())
            {
                // register ob1 = new register();
                string query = "Select * from Registration";
                //backend connected and qury run
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                //resukt set table is filled in usertable
                da.Fill(usertable);
                //usertable done!!
                return usertable;
            }
        }
        //here in the ui layer add if user not exists u have to add 

        public DataTable registeringnew() {

            connectionestab ob = new connectionestab();
            using (SqlConnection con = ob.connection()) {
                SqlDataAdapter d1 = new SqlDataAdapter("select *  from registration", con);
                    register ob1 = new register();
                DataRow r1 = usertable.NewRow();
                Console.WriteLine("Enter the userid");
                ob1.userid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the name");
                ob1.name = Console.ReadLine();
                Console.WriteLine("Enter the username");
                ob1.username = Console.ReadLine();
                Console.WriteLine("Enter the password");
                ob1.password = Console.ReadLine();
                Console.WriteLine("Enter the mobilenumber");
                ob1.mobilenumber = Convert.ToInt32(Console.ReadLine());
                usertable.Rows.Add();
                Console.WriteLine("The new row");
                return usertable;
                d1.Update(usertable);
               
            }
        }


       
    }
}

    
        
 
