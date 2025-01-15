using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class ShoppingDal
{
    private string connectionString;

    public ShoppingDal()
    {
        // Fetch the connection string from App.config
        connectionString = ConfigurationManager.ConnectionStrings["cart11"].ConnectionString;
    }
    public void RegisterUserToDb(string name, string username, string password, int mobilenumber)
    {
        DataTable userTable = new DataTable();

        DataRow newRow = userTable.NewRow();
        newRow["Name"] = name;
        newRow["Username"] = username;
        newRow["password"] = password;
        newRow["MobileNumber"] = mobilenumber;

        userTable.Rows.Add(newRow);

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Registration WHERE 1 = 0"; // This query just fetches the schema without data
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);

            da.Update(userTable);
        }
    }

    public bool ValidateLogin(string username, string password)
    {
        bool isValid = false;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Registration WHERE Username = @Username AND Password = @Password";

            // Create a DataTable to hold the result
            DataTable dt = new DataTable();

            // Using SqlDataAdapter to fill the DataTable
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.SelectCommand.Parameters.AddWithValue("@Username", username);
            da.SelectCommand.Parameters.AddWithValue("@Password", password);

            // Fill the DataTable with data
            da.Fill(dt);

            // If the DataTable contains rows, the login is valid
            if (dt.Rows.Count > 0)
            {
                isValid = true;
            }
        }

        return isValid;
    }


    public void AddToCart( int productId, int quantity)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Cart WHERE 1 = 0"; 
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable cartTable = new DataTable();

            da.Fill(cartTable);

            DataRow newRow = cartTable.NewRow();
         //   newRow["username"] = username;
            newRow["productid"] = productId;
            newRow["quantity"] = quantity;

            cartTable.Rows.Add(newRow);

            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);

            da.InsertCommand = cmdBuilder.GetInsertCommand();

           
            da.Update(cartTable);
        }
    }

    
    


}





// Get all users
//public DataTable GetUsers()
//    {
//        DataTable userTable = new DataTable();
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            string query = "SELECT * FROM Registration";
//            SqlDataAdapter da = new SqlDataAdapter(query, con);
//            da.Fill(userTable);
//        }
//        return userTable;
//    }

//    // Get all products
//    public DataTable GetProducts()
//    {
//        DataTable productTable = new DataTable();
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            string query = "SELECT * FROM Product";
//            SqlDataAdapter da = new SqlDataAdapter(query, con);
//            da.Fill(productTable);
//        }
//        return productTable;
//    }

//    // Update user data
//    public void UpdateUsers(DataTable userTable)
//    {
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            string query = "SELECT * FROM Registration";
//            SqlDataAdapter da = new SqlDataAdapter(query, con);
//            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
//            da.Update(userTable);
//        }
//    }

//    // Get cart items
//    public DataTable GetCart()
//    {
//        DataTable cartTable = new DataTable();
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            string query = "SELECT * FROM Cart";
//            SqlDataAdapter da = new SqlDataAdapter(query, con);
//            da.Fill(cartTable);
//        }
//        return cartTable;
//    }

//    // Update cart
//    public void UpdateCart(DataTable cartTable)
//    {
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            string query = "SELECT * FROM Cart";
//            SqlDataAdapter da = new SqlDataAdapter(query, con);
//            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
//            da.Update(cartTable);
//        }
//    }

//    // Get all orders
//    public DataTable GetOrders()
//    {
//        DataTable orderTable = new DataTable();
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            string query = "SELECT * FROM [Order]";
//            SqlDataAdapter da = new SqlDataAdapter(query, con);
//            da.Fill(orderTable);
//        }
//        return orderTable;
//    }
//}
