using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public class ShoppingDal
{
    private string connectionString;
    /////////////////////////////// 
    ///////////////////////////////
    //create datatavbles
    DataTable registrationtable = new DataTable();
    DataTable Producttable = new DataTable();
    DataTable orderstable = new DataTable();
    /// ///////////////////////////////////
    public ShoppingDal()
    {
        connectionString = ConfigurationManager.ConnectionStrings["cart11"].ConnectionString;
    }
    //passing all methods to one one method
    // and assiging tables to methods
    public (DataTable registrationtable, DataTable Producttable, DataTable orderstable) GetAllData()
    {
        registrationtable = GetUsers();
        Producttable = GetProducts();
        orderstable = GetOrders();
        return (registrationtable, Producttable, orderstable);
    }
    //just retrivibg data from tables
    public DataTable GetUsers()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Registration";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(registrationtable);
        }
        return registrationtable;
    }

    public DataTable GetProducts()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Product";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(Producttable);
        }
        return Producttable;
    }
    public DataTable GetOrders()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM [Order]";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(orderstable);
        }
        return orderstable;
    }
    public void UpdateUsers(DataTable userTable)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Registration";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Update(userTable);
        }
    }
    public void updateorders(DataTable orderstable)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {

            string query = "select *  from [order]";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Update(orderstable);
        }

    }
}