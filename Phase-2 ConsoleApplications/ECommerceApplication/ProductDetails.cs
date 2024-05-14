using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class ProductDetails
    {
        private static int s_productID=2000;
        public string ProductID { get;  }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price{ get; set; }
        public int ShippingDuration { get; set; }

        public ProductDetails(string productName, int stock, double price, int shippingDuration)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            Stock=stock;
            Price=price;
            ShippingDuration=shippingDuration;
        }

        public ProductDetails(string product)
        {
            string[] array=product.Split(',');

            ProductID=array[0];
            s_productID=int.Parse(array[0].Remove(0,3));
            ProductName=array[1];
            Stock=int.Parse(array[2]);
            Price=double.Parse(array[3]);
            ShippingDuration=int.Parse(array[4]);
        }
    }
}