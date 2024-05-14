using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public enum OrderStatus{Default, Ordered, Cancelled}
    public class OrderDetails
    {
        private static int s_orderID=1000;
        public string OrderID{get;}
        public string CustomerID{ get; set;}
        public string  ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity  { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string customerID, string productID, double totalPrice,DateTime purchaseDate,int quantity, OrderStatus orderstatus)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            PurchaseDate=purchaseDate;
            TotalPrice=totalPrice;
            Quantity=quantity;
            OrderStatus=orderstatus;
        }

        public OrderDetails(string order)
        {
            string[] array=order.Split(',');

            OrderID=array[0];
            s_orderID=int.Parse(array[0].Remove(0,3));
            CustomerID=array[1];
            ProductID=array[2];
            TotalPrice=double.Parse(array[3]);
            PurchaseDate=DateTime.ParseExact(array[4],"dd/MM/yyyy",null);
            Quantity=int.Parse(array[5]);
            OrderStatus=Enum.Parse<OrderStatus>(array[6],true);
        }

    }
}