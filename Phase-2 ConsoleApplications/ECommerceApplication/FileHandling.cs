using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("ECommerceDetails"))
            {
                Console.WriteLine("Folder Created");
                Directory.CreateDirectory("ECommerceDetails");
            }
            // Customer Details
            if(!File.Exists("ECommerceDetails/CustomerDetails.csv"))
            {
                Console.WriteLine("CD File Creating!");
                File.Create("ECommerceDetails/CustomerDetails.csv").Close();
            }
            //OrderDetails
            if(!File.Exists("ECommerceDetails/OrderDetails.csv"))
            {
                Console.WriteLine("OD File Creating!");
                File.Create("ECommerceDetails/OrderDetails.csv").Close();
            }
            //ProductDetails
            if(!File.Exists("ECommerceDetails/ProductDetails.csv"))
            {
                Console.WriteLine("PD File Creating!");
                File.Create("ECommerceDetails/ProductDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            // oerders
            string[] orders=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                orders[i]=Operations.orderList[i].OrderID + "," +Operations.orderList[i].CustomerID +"," +Operations.orderList[i].ProductID + "," +Operations.orderList[i].TotalPrice + ","+Operations.orderList[i].PurchaseDate.ToString("dd/MM/yyyy")+","+Operations.orderList[i].Quantity +"," +Operations.orderList[i].OrderStatus;
            }
            File.WriteAllLines("ECommerceDetails/OrderDetails.csv",orders);
            //customers
            string[] customers=new string[Operations.customerList.Count];
            for(int i=0;i<Operations.customerList.Count;i++)
            {
                customers[i]=Operations.customerList[i].CustomerID +","+Operations.customerList[i].CustomerName  +","+Operations.customerList[i].City+","+Operations.customerList[i].MobileNumber+","+Operations.customerList[i].WalletBalance+","+Operations.customerList[i].EmailID;
            }
            File.WriteAllLines("ECommerceDetails/CustomerDetails.csv",customers);
            //products
            string[] products=new string[Operations.productList.Count];
            for(int i=0;i<Operations.productList.Count;i++)
            {
                products[i]=Operations.productList[i].ProductID+","+Operations.productList[i].ProductName+","+Operations.productList[i].Stock+","+Operations.productList[i].Price+","+Operations.productList[i].ShippingDuration;
            }
            File.WriteAllLines("ECommerceDetails/ProductDetails.csv",products);
        }

        public static void ReadFromCSV()
        {
            //customers
            string[] customers=File.ReadAllLines("ECommerceDetails/CustomerDetails.csv");
            foreach(string customer in customers)
            {
                CustomerDetails customer1=new CustomerDetails(customer);
                Operations.customerList.Add(customer1);
            }
            //orders
            string[] orders=File.ReadAllLines("ECommerceDetails/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails order1=new OrderDetails(order);
                Operations.orderList.Add(order1);
            }
            //products
            string[] products=File.ReadAllLines("ECommerceDetails/ProductDetails.csv");
            foreach(string product in products)
            {
                ProductDetails product1=new ProductDetails(product);
                Operations.productList.Add(product1);
            }
        }
    }
}