//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using bal;


//namespace UI
//{
//    class UI
//    {
//        static void Main(string[] args)
//        {
//            {
//                businesslayer bal12 = new businesslayer();


//                Console.WriteLine("Welcome to the Shopping Cart!");
//                Console.WriteLine("1. Register New User");
//                Console.WriteLine("2. View All Users");
//                Console.WriteLine("3. View Product Information");
//                Console.WriteLine("Enter your choice:");


//                string input = Console.ReadLine();  // Get user input as a string
//                int choice = 0;

//                try
//                {
//                    // Try converting the input string to an integer
//                    choice = Convert.ToInt32(input);

//                    // Proceed with your switch case logic
//                    switch (choice)
//                    {
//                        case 1:
//                            Console.WriteLine("Registering a new user...");
//                            DataSet registrationDataSet = bal12.RegisteringNew();
//                            Console.WriteLine("New user registered successfully!");
//                            Console.WriteLine("Updated Registration Table:");
//                            DisplayDataSet(registrationDataSet, "registration");
//                            break;

//                        case 2:
//                            Console.WriteLine("Fetching all users...");
//                            DataSet usersDataSet = bal12.GetUsers();
//                            Console.WriteLine("User Information:");
//                            DisplayDataSet(usersDataSet, "users");
//                            break;

//                        case 3:
//                            Console.WriteLine("Fetching product information...");
//                            DataSet productDataSet = bal12.ProductInfo();
//                            Console.WriteLine("Product Information:");
//                            DisplayDataSet(productDataSet, "product");
//                            break;

//                        default:
//                            Console.WriteLine("Invalid choice. Please select a valid option.");
//                            break;
//                    }
//                }
//                catch (FormatException)
//                {
//                    // Handle the case where the input cannot be converted to an integer
//                    Console.WriteLine("Invalid input. Please enter a valid number.");
//                }

//                Console.WriteLine("Press any key to exit...");
//                Console.ReadKey();
//            }
//        }




//        private static void DisplayDataSet(DataSet dataSet, string tableName)
//        {
           
//            if (dataSet.Tables.Contains(tableName))
//            {
                
//                DataTable table = dataSet.Tables[tableName];

//                // Iterate through the rows and columns to display the data
//                foreach (DataRow row in table.Rows)
//                {
//                    foreach (DataColumn column in table.Columns)
//                    {
//                        Console.Write($"{column.ColumnName}: {row[column]}  ");
//                    }
//                    Console.WriteLine(); // Move to the next line after displaying a row
//                }
//            }
//            else
//            {
                
//                Console.WriteLine($"Table '{tableName}' does not exist in the DataSet.");
//            }
//        }
//    }
//}