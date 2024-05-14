using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public static class Operations
    {
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static List<ProductDetails> productList = new List<ProductDetails>();
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static CustomerDetails currentLoggedinCustomer;
        public static void AddDefaultData()
        {
            Console.WriteLine("---Adding Default Data---");

            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9445858566, 60000, "baskaran@mail.com");
            customerList.Add(customer1);
            customerList.Add(customer2);

            OrderDetails order1 = new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID3002", "PID2002", 40000, DateTime.Now, 2, OrderStatus.Ordered);
            orderList.Add(order1);
            orderList.Add(order2);

            ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("Camera (Sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 3);
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            productList.Add(product7);

            Console.WriteLine("--Order Default Data--");
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"{order.CustomerID,-10} | {order.ProductID,-10} | {order.TotalPrice} | {order.PurchaseDate.ToString("dd/MM/yyyy")} | {order.Quantity} | {order.OrderStatus}");
            }

            Console.WriteLine("--Customer Default Data--");
            foreach (CustomerDetails order in customerList)
            {
                Console.WriteLine($"{order.CustomerID,-10} | {order.CustomerName,-10} | {order.City} | {order.MobileNumber} | {order.WalletBalance} | {order.EmailID}");
            }

            Console.WriteLine("--Product Default Data--");
            foreach (ProductDetails order in productList)
            {
                Console.WriteLine($"{order.ProductID,-10} | {order.ProductName,-15} | {order.Stock} | {order.Price} | {order.ShippingDuration}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to SyncCart E-Commerce Application(Electronic Buying Products)");
                Console.WriteLine("Select  1.Customer Registration  2.Login  3.Exit");
                int toSelect = int.Parse(Console.ReadLine());
                switch (toSelect)
                {
                    case 1:
                        {
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            IsFlag = false;
                            Console.WriteLine("Exit Selected---");
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void CustomerRegistration()
        {
            Console.WriteLine("--Welcome To Customer Registration--");
            Console.WriteLine("Enter Your Name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter Your City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Wallet Balance: ");
            double walletBalance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your EmailID: ");
            string emailID = Console.ReadLine();

            CustomerDetails customers = new CustomerDetails(customerName, city, mobileNumber, walletBalance, emailID);
            customerList.Add(customers);
            Console.WriteLine("Welcome to SYNCCART & Your Customer ID: " + customers.CustomerID);
        }

        public static void Login()
        {
            Console.WriteLine("--Welcome to SyncCart Login--");
            Console.WriteLine("Enter Your Customer ID: ");
            string customID = Console.ReadLine().ToUpper();
            bool Isflag = true;
            foreach (CustomerDetails customer in customerList)
            {
                if (customID == customer.CustomerID)
                {
                    Console.WriteLine("| Successfully Logged IN");
                    Isflag = false;
                    currentLoggedinCustomer = customer;
                    SubMenu();
                    break;
                }
            }
            if (Isflag)
            {
                Console.WriteLine($"---Invalid Customer Id---");
            }
        }

        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("Select 1.Purchase  2.OrderHistory  3.CancelOrder  4.WalletBalance  5.WalletRecharge  6.Exit");
                int tochoose = int.Parse(Console.ReadLine());
                switch (tochoose)
                {
                    case 1:
                        {
                            Purchase();
                            break;
                        }
                    case 2:
                        {
                            OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 6:
                        {
                            IsFlag = false;
                            Console.WriteLine("--Login Portal EXITED");
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void Purchase()
        {
            //1.	Once the Customer logged in show the list of Products. Ask the customer to select a Product using Product ID.


            Console.WriteLine("--Product Default List--");
            foreach (ProductDetails order in productList)
            {
                Console.WriteLine($"{order.ProductID,-10} | {order.ProductName,-15} | {order.Stock} | {order.Price} | {order.ShippingDuration}");
            }

            Console.WriteLine("Select by Product by Entering ProductID: ");
            // 2.	Validate productID if it is invalid show “Invalid ProductID”. 
            string prodID = Console.ReadLine().ToUpper();
            bool Isflag = true;
            foreach (ProductDetails product in productList)
            {
                if (prodID == product.ProductID)
                {
                    Isflag = false;
                    Console.WriteLine("Enter How many Counts you want to Purchase? ");
                    // 3.	If it is valid, Then ask for the count he wish to purchase.
                    int count = int.Parse(Console.ReadLine());
                    if (count <= product.Stock)
                    {
                        // count is available calculate total amount with the below formula.
                        int deliveryCharge = 50;
                        double totalPrice = (count * product.Price) + deliveryCharge;
                        Console.WriteLine("Order Price is: " + totalPrice);
                        // current logged in customer’s wallet balance to ensure he is having enough balance to purchase by comparing with total price
                        if (totalPrice <= currentLoggedinCustomer.WalletBalance)
                        {
                            // 8.	If the wallet has sufficient balance, then 
                            // .	Deduct the total amount from the wallet balance of the current logged in customer.
                            currentLoggedinCustomer.DeductBalance(totalPrice);
                            // b.	Deduct the count from the stock availability of the product.
                            product.Stock = product.Stock - count;
                            // 9.	Create order with available details and make its status as Ordered, add it to order List and show “Order Placed Successfully. Order ID: OID1001”.
                            OrderDetails orderd = new OrderDetails(currentLoggedinCustomer.CustomerID, prodID, totalPrice, DateTime.Now, count, OrderStatus.Ordered);
                            orderList.Add(orderd);
                            Console.WriteLine("Order Placed Successfully. Order ID:" + orderd.OrderID);
                            // 10.	Show the delivery date of order by making a calculation based on purchase date and shipping duration of the product like 
                            //“Order placed successfully. Your order will be delivered on {Order date +shipping duration of the product}.
                            Console.WriteLine("Order placed successfully on " + DateTime.Today.ToString("dd/MM/yyyy") + ". Your order will be delivered within " + DateTime.Today.AddDays(product.ShippingDuration).ToString("dd/MM/yyyy") + " days.  !!! Thank You For Ordering SyncCart !!!");
                            Console.WriteLine();

                        }
                        else
                        {
                            // 7.	If the wallet balance is insufficient for this order, then display “Insufficient Wallet Balance. Please recharge your wallet and do purchase again”.
                            Console.WriteLine("Insufficient Balance Please recharge your wallet and do purchase again");
                        }
                    }
                    else
                    {
                        // 4.	If the required count is not available in the product’s stock, then show like “Required count not available. Current availability is {product’s stock count}”.
                        Console.WriteLine("Count is Insufficient--. Currently Available Stock:" + product.Stock);
                    }
                }
            }
            if (Isflag)
            {
                Console.WriteLine("No Product IF Found!!");
            }

        }


        public static void OrderHistory()
        {
            // Show all the information about the orders that current logged in customer made.
            Console.WriteLine("Your Order History Details are: ");
            bool Isflag = true;
            foreach (OrderDetails orderd in orderList)
            {
                if (currentLoggedinCustomer.CustomerID == orderd.CustomerID)
                {
                    Isflag = false;
                    Console.WriteLine($" {orderd.ProductID} | {orderd.CustomerID} | {orderd.OrderID} | {orderd.TotalPrice} | {orderd.PurchaseDate} | {orderd.Quantity} | {orderd.OrderStatus}");
                }
            }
            if (Isflag)
            {
                Console.WriteLine("Still You have not placed any order!!!");
            }
        }

        public static void CancelOrder()
        {
            //1.	Show all orders placed by current logged in customer whose order status is Ordered.
            Console.WriteLine("Your Order History Details are: ");
            bool Isflag = true;
            foreach (OrderDetails orderd in orderList)
            {
                if (currentLoggedinCustomer.CustomerID == orderd.CustomerID)
                {
                    Isflag = false;
                    Console.WriteLine($" {orderd.ProductID} | {orderd.CustomerID} | {orderd.OrderID} | {orderd.TotalPrice} | {orderd.PurchaseDate} | {orderd.Quantity} | {orderd.OrderStatus}");
                }
            }
            if (Isflag)
            {
                Console.WriteLine("Still You have not placed any order!!!");
            }
            //bool orderFlag=true;
            //2.	Ask customer to select an order to be cancelled by the OrderID.
            if (!Isflag)
            {
                Console.WriteLine("Enter OrderID, for which you want to Cancel Order");
                string cancelID = Console.ReadLine().ToUpper();
                //3.	Validate orderID and show “Invalid OrderID” if there is no such order.
                bool IsFlagg = true;
                foreach (OrderDetails orderd in orderList)
                {
                    if (cancelID == orderd.OrderID && currentLoggedinCustomer.CustomerID==orderd.CustomerID && orderd.OrderStatus==OrderStatus.Ordered )
                    {
                        IsFlagg = false;

                        //4.	If it is valid then Pick the order based on the provided OrderID.
                        foreach (ProductDetails product in productList)
                        {
                            if (product.ProductID == orderd.ProductID)
                            {
                                //5.Increase the available stock quantity by the count of product purchased in the current order to be cancelled.
                                product.Stock = product.Stock + orderd.Quantity;
                            }
                        }
                        //6.	Refund the amount to the customer’s wallet balance.
                        currentLoggedinCustomer.WalletBalance = orderd.TotalPrice + currentLoggedinCustomer.WalletBalance;
                        //7.	Change the order status to “Cancelled” and finally show “Order :{OrderID} cancelled successfully”.
                        orderd.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine("Yor Order has been Cancelled: " + orderd.OrderID);
                    }
                }
                if (IsFlagg)
                {
                    Console.WriteLine("Invalid Order ID !!!");
                }
            }
        }

        public static void WalletBalance()
        {
            // Show the current available WalletBalance of current logged in customer.
            Console.WriteLine("Your Current Wallet Balance: " + currentLoggedinCustomer.WalletBalance);
        }

        public static void WalletRecharge()
        {
            //1.	Ask the customer whether he wish to recharge the wallet. 
            Console.WriteLine("Wallet Recharge-- Enter Yes if You want to Reacharge yor Wallet:");
            // 2.	If “Yes” then ask for the amount to be recharged and update the amount in the wallet and display the updated wallet balance.
            string option = Console.ReadLine().ToLower();
            if (option == "yes")
            {
                Console.WriteLine("Enter the Amount to Reacharge(Only Positive Values)");
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    currentLoggedinCustomer.WalletRecharge(amount);
                }
                else
                {
                    Console.WriteLine("Amount Should Maximum 0");
                }

            }
           
        }

    }
}