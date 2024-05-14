using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHApplication
{
    public static class Operations
    {
        static List<UserRegistration> userRegistrationList = new List<UserRegistration>();
        static List<PackDetails> packDetailsList = new List<PackDetails>();
        static List<RechargeHistory> rechargeHistoryList = new List<RechargeHistory>();
        static UserRegistration currentLoginUser;
        public static void AddDefaultData()
        {
            Console.WriteLine("--Adding Default Data---");

            UserRegistration user1 = new UserRegistration("John", 9746646466, "john@gmail.com", 500);
            UserRegistration user2 = new UserRegistration("Merlin", 9746646555, "merlin@gmail.com", 150);
            userRegistrationList.Add(user1);
            userRegistrationList.Add(user2);

            RechargeHistory recharge1 = new RechargeHistory("UID1001", "RC150", new DateTime(2021, 11, 30), 150, new DateTime(2021, 12, 27), 50);
            RechargeHistory recharge2 = new RechargeHistory("UID1002", "RC150", new DateTime(2022, 01, 01), 150, new DateTime(2022, 01, 28), 50);
            rechargeHistoryList.Add(recharge1);
            rechargeHistoryList.Add(recharge2);

            PackDetails pack1 = new PackDetails("RC150", "	Pack1", 150, 28, 50);
            PackDetails pack2 = new PackDetails("RC300", "	Pack2", 300, 56, 50);
            PackDetails pack3 = new PackDetails("RC500", "	Pack3", 500, 28, 50);
            PackDetails pack4 = new PackDetails("RC1500", "Pack4", 1500, 365, 50);
            packDetailsList.Add(pack1);
            packDetailsList.Add(pack2);
            packDetailsList.Add(pack3);
            packDetailsList.Add(pack4);

            Console.WriteLine($"--Pack Details Default--");
            foreach (PackDetails pack in packDetailsList)
            {
                Console.WriteLine($"{pack.PackID} | {pack.PackName} | {pack.Price} | {pack.Validity} | {pack.NoOfChannels}");
            }

            Console.WriteLine($"--User Registration Default--");
            foreach (UserRegistration user in userRegistrationList)
            {
                Console.WriteLine($"{user.UserName} | {user.MobileNumber} | {user.EmailID} | {user.WalletBalance}");
            }

            Console.WriteLine($"--Recharge Pack Default--");
            foreach (RechargeHistory recharge in rechargeHistoryList)
            {
                Console.WriteLine($"{recharge.RechargeID} | {recharge.UserID} | {recharge.PackID} | {recharge.RechargeDate} | {recharge.RechargeAmount} | {recharge.ValidTill}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Online DTH Recharge Application");
                Console.WriteLine("Select  1.User Registration  2.User Login  3.Exit");
                int tochoose = int.Parse(Console.ReadLine());
                switch (tochoose)
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
                            Console.WriteLine("--Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("---Welcome to User Registration---");
            Console.WriteLine("Enter Your Name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Mail ID: ");
            string emailID = Console.ReadLine();
            Console.WriteLine("Enter Your WalletBalance: ");
            double walletBalance = double.Parse(Console.ReadLine());

            UserRegistration users = new UserRegistration(userName, mobileNumber, emailID, walletBalance);
            userRegistrationList.Add(users);
            Console.WriteLine("Welcome-- You Successfully Registerd and Your User Registration ID: " + users.UserID);
        }

        public static void UserLogin()
        {
            bool Isflag = true;
            Console.WriteLine("---Welcome to User Completed---");
            Console.WriteLine("Enter Your User ID: ");
            string userID = Console.ReadLine();
            foreach (UserRegistration user in userRegistrationList)
            {
                if (userID == user.UserID)
                {
                    Isflag = false;
                    currentLoginUser = user;
                    SubMenu();
                    break;
                }
            }
            if (Isflag)
            {
                Console.WriteLine("!! Invalid User ID !!");
            }
        }

        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("Select  1.Current Pack	2.Pack Recharge	 3.Wallet Recharge	4.View Pack Recharge History	5.Show Wallet balance	6.Exit");
                int tochoose = int.Parse(Console.ReadLine());
                switch (tochoose)
                {
                    case 1:
                        {
                            CurrentPack();
                            break;
                        }
                    case 2:
                        {
                            PackRecharge();
                            break;
                        }
                    case 3:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            ViewPackRechargeHistory();
                            break;
                        }
                    case 5:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("----Login Exited---");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void CurrentPack()
        {
            //1. Displays recent pack detail of current user (User ID, Pack ID, Recharge Amount, Valid Till, Number of channels)
            bool Isflag = true;
            foreach (RechargeHistory recharge in rechargeHistoryList)
            {
                if (currentLoginUser.UserID == recharge.UserID)
                {
                    if (recharge.ValidTill >= DateTime.Today)
                    {
                        Isflag = false;
                        Console.WriteLine($" | {recharge.UserID} | {recharge.PackID} | {recharge.RechargeDate} | {recharge.RechargeAmount} | {recharge.ValidTill} | {recharge.NumberOfChannels}");
                    }
                }
            }
            if (Isflag)
            {
                Console.WriteLine("--No Recent Packs--");
            }
        }

        public static void PackRecharge()
        {
            //1.	List the available pack details and ask the user to choose a pack and recharge.
            //2.	Based on the pack choose, check the wallet balance.
            //3.	If insufficient balance in wallet, ask them to recharge his wallet.
            //4.	If the user has sufficient balance, then permit and do recharge.
            Console.WriteLine($"--Pack Details Avialable--");
            foreach (PackDetails pack in packDetailsList)
            {
                Console.WriteLine($"{pack.PackID} | {pack.PackName} | {pack.Price} | {pack.Validity} | {pack.NoOfChannels}");
            }

            Console.WriteLine();
            bool IsFlag = true;
            DateTime tempDate = DateTime.Today;
            foreach (RechargeHistory recharge in rechargeHistoryList)
            {
                if (recharge.UserID == currentLoginUser.UserID)
                {
                    tempDate = recharge.ValidTill;
                }
            }
            Console.WriteLine("Select the Plan( Pack ID )to Recharge: ");
            string toselect = Console.ReadLine().ToUpper();
            DateTime startDate = DateTime.Today;
            DateTime endDate=DateTime.Today;
            foreach (PackDetails packplan in packDetailsList)
            {
                if (toselect == packplan.PackID)
                {
                    IsFlag = false;
                    // Check Wallet Balance
                    if (packplan.Price <= currentLoginUser.WalletBalance)
                    {
                        if (tempDate == DateTime.Today)
                        {
                            startDate = DateTime.Today.AddDays(1);
                            endDate=startDate.AddDays(packplan.Validity);
                        }
                        else if (tempDate < DateTime.Today)
                        {
                            startDate = DateTime.Today;
                            endDate = startDate.AddDays(packplan.Validity);
                        }
                        else if (tempDate > DateTime.Today)
                        {
                            startDate = tempDate.AddDays(1);
                           // double extendDate=(tempDate-DateTime.Today).TotalDays;
                            endDate = startDate.AddDays(packplan.Validity );
                        }
                    RechargeHistory recharges = new RechargeHistory(currentLoginUser.UserID, toselect, startDate, packplan.Price, endDate, packplan.NoOfChannels);
                    rechargeHistoryList.Add(recharges);
                    Console.WriteLine("--Recharged Successfully-- & Recharge ID: " + recharges.RechargeID);
                    }
                    else
                    {
                        Console.WriteLine("--Insufficient Balance-- Need To Recharge--");
                    }
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--Invalid Pack ID---");
            }
        }

        public static void WalletRecharge()
        {
            //1.	Ask for the amount to be recharged from the user and update the wallet balance.
            Console.WriteLine("Enter Yes, If you need to Recharge Wallet: ");
            string torecharge = Console.ReadLine().ToLower();
            if (torecharge == "yes")
            {
                Console.WriteLine("Enter The amount to Recharge: ");
                double rechargee = double.Parse(Console.ReadLine());
                if (rechargee > 0)
                {
                    currentLoginUser.WalletBalance = currentLoginUser.WalletBalance + rechargee;
                    Console.WriteLine("Recharged Successful & Your Wallet Balance is: " + currentLoginUser.WalletBalance);
                }
                else
                {
                    Console.WriteLine("-- Invalid Amount--");
                }
            }

        }

        public static void ViewPackRechargeHistory()
        {
            bool IsFlag = true;
            foreach (RechargeHistory recharge in rechargeHistoryList)
            {
                if (currentLoginUser.UserID == recharge.UserID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{recharge.RechargeID} | {recharge.UserID} | {recharge.PackID} | {recharge.RechargeDate} | {recharge.RechargeAmount} | {recharge.ValidTill} | {recharge.NumberOfChannels}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("-- No Pack Recharge History Found--");
            }
        }

        public static void ShowWalletBalance()
        {
            Console.WriteLine("Your Wallet Balance is:" + currentLoginUser.WalletBalance);
        }


    }
}