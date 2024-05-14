using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalApplication
{
    public static class Operations
    {
        static List<UserDetails> userDetailsList = new List<UserDetails>();
        static List<OrderDetails> orderDetailsList = new List<OrderDetails>();
        static List<MedicineDetails> medicineDetailsList = new List<MedicineDetails>();
        static UserDetails currentLoginUser;

        public static void AddDefaultData()
        {
            Console.WriteLine("--Adding Default Data--");

            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", 9877774440, 400);
            UserDetails user2 = new UserDetails("Baskaran", 33, "Chennai", 8847774440, 500);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            OrderDetails order1 = new OrderDetails("UID1001", "MD2001", 3, 15, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD2002", 2, 10, new DateTime(2023, 11, 13), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1002", "MD2004", 2, 150, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD2003", 3, 100, new DateTime(2024, 11, 13), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD2002", 5, 200, new DateTime(2024, 11, 13), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD2005", 3, 250, new DateTime(2024, 11, 13), OrderStatus.Purchased);
            orderDetailsList.Add(order1);
            orderDetailsList.Add(order2);
            orderDetailsList.Add(order3);
            orderDetailsList.Add(order4);
            orderDetailsList.Add(order5);
            orderDetailsList.Add(order6);

            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(2023, 12, 30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, new DateTime(2023, 11, 30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, new DateTime(2024, 04, 30));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin", 10, 50, new DateTime(2026, 10, 30));
            medicineDetailsList.Add(medicine1);
            medicineDetailsList.Add(medicine2);
            medicineDetailsList.Add(medicine3);
            medicineDetailsList.Add(medicine4);
            medicineDetailsList.Add(medicine5);

            Console.WriteLine("--User Details Default Dats--");
            foreach (UserDetails user in userDetailsList)
            {
                Console.WriteLine($"{user.UserID} | {user.UserName} | {user.Age} | {user.City} | {user.PhoneNumber}");
            }

            Console.WriteLine("--Medicine Default Details--");
            foreach (MedicineDetails medicine in medicineDetailsList)
            {
                Console.WriteLine($"{medicine.MedicineID} | {medicine.MedicineName} | {medicine.AvailableCount} | {medicine.Price} | {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }

            Console.WriteLine("--Default Order Details--");
            foreach (OrderDetails order in orderDetailsList)
            {
                Console.WriteLine($"{order.OrderID} | {order.UserID} | {order.MedicineID} | {order.MedicineCount} | {order.TotalPrice} | {order.OrderDate.ToString("dd/MM/yyyy")} | {order.OrderStatus}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Online Medical Management--");
                Console.WriteLine("Select Menu-- 1.User Registration  2.User Login    3.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("-- Application Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("Welcome to User Registration");
            Console.WriteLine("To Create Account--Enter Yor Name:  ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());
            UserDetails users = new UserDetails(userName, age, city, phoneNumber, balance);
            userDetailsList.Add(users);
            Console.WriteLine($"Account Created Successfully-- & User ID: {users.UserID}");
        }

        public static void UserLogin()
        {
            Console.WriteLine("--User Login Portal--");
            Console.WriteLine("---Enter Your User ID: ");
            bool IsFalg = true;
            string userID = Console.ReadLine().ToUpper();
            foreach (UserDetails user in userDetailsList)
            {
                if (userID == user.UserID)
                {
                    IsFalg = false;
                    Console.WriteLine("Welcome  " + user.UserName);
                    currentLoginUser = user;
                    SubMenu();
                    break;
                }
            }
            if (IsFalg)
            {
                Console.WriteLine("Invalid User ID!!!");
            }
        }


        public static void SubMenu()
        {
            bool IsFalg = true;
            do
            {
                Console.WriteLine("Select Options---");
                Console.WriteLine("1.Show medicine list   2.Purchase medicine   3.Cancel purchase     4.Show purchase history     5.Recharge    6.Show WalletBalance   7.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            ShowMedicineList();
                            break;
                        }
                    case 2:
                        {
                            PurchaseMedicine();
                            break;
                        }
                    case 3:
                        {
                            CancelPurchase();
                            break;
                        }
                    case 4:
                        {
                            ShowPurchaseHistory();
                            break;
                        }
                    case 5:
                        {
                            Recharge();
                            break;
                        }
                    case 6:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("--Login Portal Exited--");
                            IsFalg = false;
                            break;
                        }
                }
            } while (IsFalg);
        }

        public static void ShowMedicineList()
        {
            //1.	Show the list of available medicine details in the store by traversing the medicine details list 
            Console.WriteLine("--Available Medicine Details--");
            foreach (MedicineDetails medicine in medicineDetailsList)
            {
                Console.WriteLine($"{medicine.MedicineID} | {medicine.MedicineName} | {medicine.AvailableCount} | {medicine.Price} | {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }
        }

        public static void PurchaseMedicine()
        {
            Console.WriteLine("--Available Medicine Details--");
            foreach (MedicineDetails medicine in medicineDetailsList)
            {
                Console.WriteLine($"{medicine.MedicineID} | {medicine.MedicineName} | {medicine.AvailableCount} | {medicine.Price} | {medicine.DateOfExpiry.ToString("dd/MM/yyyy")}");
            }
            //2.	Ask the user to select the medicine using MedicineID.
            bool IsFalag = true;
            Console.WriteLine("Select the Medicine by Entering Medicine ID: ");
            string medicineID = Console.ReadLine().ToUpper();
            foreach (MedicineDetails medicine in medicineDetailsList)
            {
                if (medicineID == medicine.MedicineID)
                {
                    IsFalag = false;
                    //3.	Ask the number of counts of that medicine he wants to buy.
                    Console.WriteLine("How many counts you want to buy the medicine? ");
                    int count = int.Parse(Console.ReadLine());
                    //a.	check the asked count is available. If it is available, then 
                    // b. 	Check the medicine was not expired. If it is expired or not available, 
                    //then show the user “Medicine is not available”.
                    if (count <= medicine.AvailableCount)
                    {
                        if (medicine.DateOfExpiry > DateTime.Today)
                        {
                            //c.	If the medicine is not expired, then check User has enough balance to purchase that medicine. 
                            if (currentLoginUser.Balance >= medicine.Price)
                            {
                                // 5.	Reduce the number of AvailableCount of that medicine in MedicineDetails. 
                                //6.	Deduct the total amount from user’s balance amount.
                                medicine.AvailableCount = medicine.AvailableCount - count;
                                double totalPrice = count * medicine.Price;
                                currentLoginUser.Balance = currentLoginUser.Balance - totalPrice;
                                //7.	If all the conditions specified in step 4 are true then 
                                //calculate the total amount of purchased medicines, OrderDate is Now, Put OrderStatus as “Purchased” and create object for OrderDetails class and add it to the list. 
                                OrderDetails order1 = new OrderDetails(currentLoginUser.UserID, medicine.MedicineID, count, totalPrice, DateTime.Now, OrderStatus.Purchased);
                                orderDetailsList.Add(order1);
                                //8.	Finally show the message “Medicine was purchased successfully”.
                                Console.WriteLine("|---  Medicine Purchased Successfully  ---| " + order1.OrderID);

                            }
                        }
                        else
                        {
                            Console.WriteLine("Insufficent Counts-- Available Count: " + medicine.AvailableCount);
                            Console.WriteLine("Item has been expied!!");
                        }
                    }
                }
            }
            if (IsFalag)
            {
                Console.WriteLine("---Invalid Medicine ID---");
            }
        }

        public static void CancelPurchase()
        {
            //1.	Show the order details of the currently logged in user whose order status is “Purchased”.
            //3.	If the OrderID matches increase the count of that Medicine in the medicine details, Return the amount to the user.  Change the Status of the order to “Cancelled”.
            //4.	Show the user that the “OrderID XXX was cancelled successfully”. 
            Console.WriteLine("-- Purchase History--");
            bool IsFlag = true;
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (currentLoginUser.UserID == orders.UserID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{orders.OrderID} | {orders.UserID} | {orders.MedicineID} | {orders.TotalPrice} | {orders.OrderDate.ToString("dd/MM/yyyy")} | {OrderStatus.Purchased}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--Still You have not placed any order!!!-- ");
            }
            //2.	Get the OrderID information from the user and check the OrderID present in the list and check its OrderStatus is Purchased.
            if (!IsFlag)
            {
                Console.WriteLine("Enter Order ID to cancel: ");
                bool IsFalag = true;
                String orderID = Console.ReadLine().ToUpper();
                foreach (OrderDetails orders in orderDetailsList)
                {
                    if (orderID == orders.OrderID && orders.OrderStatus == OrderStatus.Purchased && currentLoginUser.UserID==orders.UserID)
                    {
                        IsFalag = false;
                        foreach (MedicineDetails medicine in medicineDetailsList)
                        {
                            medicine.AvailableCount = medicine.AvailableCount + orders.MedicineCount;
                        }
                        currentLoginUser.Balance = currentLoginUser.Balance + orders.TotalPrice;
                        orders.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine("Your Ordered was Cancelled: " + orderID);
                    }
                }
                if (IsFalag)
                {
                    Console.WriteLine("Invalid Order ID---");
                }
            }
        }

        public static void ShowPurchaseHistory()
        {
            // Show the purchased history of the current logged in user by traversing the OrderDetails list.
            Console.WriteLine("-- Purchase History--");
            bool IsFlag = true;
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (currentLoginUser.UserID == orders.UserID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{orders.OrderID} | {orders.UserID} | {orders.MedicineID} | {orders.TotalPrice} | {orders.OrderDate.ToString("dd/MM/yyyy")} | {orders.OrderStatus}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--Still You have not placed any order!!!-- ");
            }
        }

        public static void Recharge()
        {
            //Get the amount to be recharged from the current logged in user and update the balance information on his property.
            Console.WriteLine(" Enter Yes-- If You want to Reacharge:");
            string recharge = Console.ReadLine().ToLower();
            if (recharge == "yes")
            {
                Console.WriteLine("Enter Amount to Recharge: ");
                int toRecharge = int.Parse(Console.ReadLine());
                if(toRecharge>0)
                {
                currentLoginUser.Balance = currentLoginUser.Balance + toRecharge;
                Console.WriteLine("--- Recharge Successful--- Balance: " + currentLoginUser.Balance);
                }
                else
                {
                    Console.WriteLine("Invali Amount");
                }
            }
        }

        public static void ShowWalletBalance()
        {
            //Display the user balance amount.
            Console.WriteLine("--- Your Balance is: " + currentLoginUser.Balance);
        }


    }
}