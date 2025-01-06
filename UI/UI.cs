using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bal;
using dal;

namespace UI
{
    internal class UI
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to shopping cart");
            Console.WriteLine(" 1.Registration");
            Console.WriteLine("2.Product table");
            Console.WriteLine("3.View cart");
            Console.ReadLine();
            bal.bal obj = new bal.bal();
            int selection = Convert.ToInt32(Console.ReadLine());

            GetUsers obj1 = new GetUsers();
            register obj2 = new register();

            obj1.getusers();
               if(obj2.userid > 0)
            {
                obj1.registeringnew();
            }

               //switch case 
            else
            {
                Console.WriteLine("Invalid userid. Please try again.");
            }


        }
    }
}
