using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class cart
    {

       
        public int cartID { get; set; }

        public int ProductID { get; set; }

        public string ProductName  { get; set; }

        public string Username { get; set; }

        public int Quantity { get; set; }

        public int FinalPrice { get; set; }
    }
    public class Product1
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int  Price { get; set; }
         
        public int Quantity { get; set; }
    }

}