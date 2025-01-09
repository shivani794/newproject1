using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{

    public class ShoppingDal
    {

        public string getconnection12 = ConfigurationManager.ConnectionStrings["cart11"].ConnectionString;

        //public string Register(string name, string username, string password, int mobilenumber)
        //{
        //    //using (SqlConnection con = new SqlConnection(getconnection12))
        //    //{
        //    //    SqlDataAdapter da = new SqlDataAdapter("usp_RegisterUser", con)
        //    //    {
        //    //        CommandType = CommandType.StoredProcedure
        //    //    };


        //    //    using (SqlConnection con = new SqlConnection(getconnection12))
        //    //    {
        //    //        SqlDataAdapter da = new SqlDataAdapter("INSERT INTO Registration (name, username, password, mobilenumber) VALUES (@name, @username, @password, @mobilenumber)", con);
        //    //        da.SelectCommand.Parameters.AddWithValue("@name", name);
        //    //        da.SelectCommand.Parameters.AddWithValue("@username", username);
        //    //        da.SelectCommand.Parameters.AddWithValue("@password", password);
        //    //        da.SelectCommand.Parameters.AddWithValue("@mobilenumber", mobilenumber);
        //    //    SqlCommandBuilder
        //    //    da.Fill(ds, "Registration");
        //    //    da.Update(ds, "Registration");
        //    //}

        //    //    return "registrationsuccessful";
        //    //}

        //}


        DataTable usertable = new DataTable();
        DataTable producttable = new DataTable();
        DataTable cart = new DataTable();
        DataTable placeorder = new DataTable();
        DataTable addtocart = new DataTable();
        DataTable login = new DataTable();
        public DataTable getusers()
        {
            using (SqlConnection con = new SqlConnection(getconnection12))
            {
                string query = "select * from registration";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(usertable);
            }
            return usertable;
        }
        public DataTable getproducts()
        {
            using (SqlConnection con = new SqlConnection(getconnection12))
            {
                string query = "select * from product";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(producttable);
            }
            return producttable;
        }
        //dt has changes
        public void updateusers(DataTable ut)
        {
            using (SqlConnection con = new SqlConnection(getconnection12))
            {
                string query = "select * from registration";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Update(usertable);
            }
        }
        //public DataTable loginuser()
        //{
        //    using(SqlConnection con = new SqlConnection(getconnection12))
        //    {
        //        string query = "select *  from login";
        //        SqlDataAdapter da = new SqlDataAdapter(query, con);
        //        SqlCommandBuilder cmd = new SqlCommandBuilder(da);
        //        da.Fill(login);
        //    }
        //    return login;
        //}
        public DataTable addtocart1()
        {
            using (SqlConnection con = new SqlConnection(getconnection12))
            {
                string query = "select *  from cart";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(addtocart);
            }
            return addtocart;
        }

        public void afteraddingtocart1(DataTable addtocart)
        {
            using (SqlConnection con = new SqlConnection(getconnection12))
            {
                string query = "select * from cart";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Update(cart);
            }
        }

        public DataTable placeorder1()
        {
            using (SqlConnection con = new SqlConnection(getconnection12))
            {
                string query = "select *  from order";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(placeorder);
            }
            return placeorder;
        }

        public void placedorder(DataTable placeorder) {
            using (SqlConnection con = new SqlConnection(getconnection12)
            {
                
                string query = "select *  from order";
                placing
            }
    }
}

