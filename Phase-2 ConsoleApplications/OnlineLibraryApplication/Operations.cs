using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryApplication
{
    public static class Operations
    {
        static List<UserDetails> userDetailsList = new List<UserDetails>();
        static List<BookDetails> bookDetailsList = new List<BookDetails>();
        static List<BorrowDetails> borrowDetailsList = new List<BorrowDetails>();
        static UserDetails currentLoginUser;

        public static void AddDefaultData()
        {
            Console.WriteLine("--Adding Default Data--");
            UserDetails user1 = new UserDetails("Ravichandran", "Male", Department.ECE, 9938388333, "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", "Female", Department.CSE, 9944444455, "priya@gmail.com", 150);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 5);
            BookDetails book4 = new BookDetails("JS", "Author1", 5);
            BookDetails book5 = new BookDetails("TS", "Author1", 5);
            bookDetailsList.Add(book1);
            bookDetailsList.Add(book2);
            bookDetailsList.Add(book3);
            bookDetailsList.Add(book4);
            bookDetailsList.Add(book5);

            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 1, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 19), 1, Status.Returned, 20);
            borrowDetailsList.Add(borrow1);
            borrowDetailsList.Add(borrow2);
            borrowDetailsList.Add(borrow3);
            borrowDetailsList.Add(borrow4);
            borrowDetailsList.Add(borrow5);

            Console.WriteLine("-- User Default Details---");
            foreach (UserDetails users in userDetailsList)
            {
                Console.WriteLine($"{users.UserID} | {users.UserName} | {users.Gender} | {users.Gender} | {users.Department} | {users.MobileNumber} | {users.MailID} | {users.WalletBalance}");
            }

            Console.WriteLine("--Order Default Details--");
            foreach (BookDetails books in bookDetailsList)
            {
                Console.WriteLine($"{books.BookID} | {books.BookName} | {books.AuthorName} | {books.BookCount}");
            }

            Console.WriteLine("--Borrow Details Default--");
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                Console.WriteLine($"{borrow.BorrowID} | {borrow.BookID} | {borrow.BorrowBookCount} | {borrow.BorrowBookCount} | {borrow.Status} | {borrow.PaidFineAmount}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("-- Welcome to Online Library Management and Book tracking ");
                Console.WriteLine("Select   1.User Registration   2.User Login   3.Exit");
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
                            Console.WriteLine("---Application Exited---");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine();
            Console.WriteLine("--Welcome to User Registration--");
            Console.WriteLine("Enter Your Name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Your Gender: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Select Your Department(ECE, EEE, CSE): ");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);
            Console.WriteLine("Enter Your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Mail ID: ");
            string mailID = Console.ReadLine();
            Console.WriteLine("Enter Your Wallet Balance: ");
            double walletBalance = double.Parse(Console.ReadLine());
            UserDetails users = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalance);
            userDetailsList.Add(users);
            Console.WriteLine("-- Registration Completed-- & Your User ID: " + users.UserID);
        }

        public static void UserLogin()
        {
            Console.WriteLine("--Welcome to User Login--");
            Console.WriteLine("Enter Your User ID: ");
            // bool IsFlag=true;
            string userID = Console.ReadLine().ToUpper();
            foreach (UserDetails users in userDetailsList)
            {
                if (userID == users.UserID)
                {
                    //IsFlag=false;
                    Console.WriteLine("Select SubMenu---");
                    currentLoginUser = users;
                    SubMenu();
                    break;
                }
            }
        }

        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("Select  1.Borrowbook  2.Show Borrowed History   3.Return Books   4.Wallet Recharge   5.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            BorrowBook();
                            break;
                        }
                    case 2:
                        {
                            ShowBorrowedHistory();
                            break;
                        }
                    case 3:
                        {
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("-- Login Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void BorrowBook()
        {
            Console.WriteLine("--Available Book Details--");
            foreach (BookDetails books in bookDetailsList)
            {
                Console.WriteLine($"{books.BookID} | {books.BookName} | {books.AuthorName} | {books.BookCount}");
            }
            bool IsFlag = true;
            Console.WriteLine("Enter Book ID to Pick Book");
            string bookID = Console.ReadLine().ToUpper();
            foreach (BookDetails book in bookDetailsList)
            {
                if (bookID == book.BookID)
                {
                    IsFlag = false;
                    Console.WriteLine("Enter the count of the Book: ");
                    //bool IsFlag1=true;
                    int bookCount = int.Parse(Console.ReadLine());
                    if (bookCount <= book.BookCount)
                    {
                        int tempBooks = 0;
                        //need to check whether the user already have any borrowed book.
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (currentLoginUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                            {
                                tempBooks += borrow.BorrowBookCount;
                            }
                        }
                        if (bookCount <= 3)
                        {
                            if (bookCount + tempBooks <= 3)
                            {
                                //IsFlag1=false;
                                BorrowDetails borrows = new BorrowDetails(book.BookID, currentLoginUser.UserID, DateTime.Now, bookCount, Status.Borrowed, 0);
                                borrowDetailsList.Add(borrows);
                                book.BookCount = book.BookCount - bookCount;
                                Console.WriteLine("-- Borrowed Book Successfully--" + borrows.BorrowID);
                            }
                            else
                            {
                                Console.WriteLine("Books are not available for the selected count" + bookCount);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Borrowed 3 Books Already--");
                        }
                    }
                    else
                    {
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (bookID == borrow.BookID && borrow.Status == Status.Borrowed)
                            {
                                Console.WriteLine("Next Available Date: " + borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy"));
                            }
                        }
                    }
                }

            }
            if (IsFlag)
            {
                Console.WriteLine("--Invalid Book ID-- EnterValid ID");
            }
        }

        public static void ShowBorrowedHistory()
        {
            Console.WriteLine("--Your Borrowed History");
            bool IsFlag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoginUser.UserID == borrow.UserID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{borrow.BorrowID} | {borrow.BookID} | {borrow.BorrowBookCount} | {borrow.BorrowBookCount} | {borrow.Status} | {borrow.PaidFineAmount}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--No History Found--");
            }
        }

        public static void ReturnBooks()
        {
            //  1.	Show the borrowed book details of current user whose status is “borrowed” also Print the return date of each book (Return date will be 15 days after borrowing a book). 
            Console.WriteLine("--Your Borrowed History--Status - Borrowed");
            bool IsFlag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentLoginUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                {
                    IsFlag = false;
                    if (borrow.BorrowedDate.AddDays(15) < DateTime.Today)
                    {
                        //2.	If the return date is elapsed more than 15 days then calculate and show the fine amount (Rs. 1 / Day) for each book.
                        Console.WriteLine($"{borrow.BorrowID} | {borrow.BookID} | {borrow.BorrowBookCount} | {borrow.BorrowBookCount} | {borrow.Status} | {borrow.PaidFineAmount}");
                    }
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--No History Found--");
            }

            
            // bool borrowStatus = true;

            if (!IsFlag)
            {
                bool IsFlag1=true;
                Console.WriteLine("Enter the Borrow ID to Return: ");
                string borrowID = Console.ReadLine().ToUpper();
                foreach (BorrowDetails borrow in borrowDetailsList)
                {
                    if (borrow.Status == Status.Borrowed && borrowID == borrow.BorrowID)
                    {
                        IsFlag1=false;
                        //Console.WriteLine(borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy"));
                        DateTime calculateDays = borrow.BorrowedDate.AddDays(15);
                        if (calculateDays < DateTime.Today)
                        {
                            int daysToCalculate = (DateTime.Today - borrow.BorrowedDate).Days;
                            int paidfine = (1 * daysToCalculate) - 15;
                            Console.WriteLine("Fine Amount to be Paid: " + paidfine);
                            if (paidfine <= currentLoginUser.WalletBalance)
                            {
                                currentLoginUser.WalletBalance = currentLoginUser.WalletBalance - paidfine;
                                borrow.Status = Status.Returned;
                                borrow.PaidFineAmount = paidfine;
                                foreach (BookDetails book in bookDetailsList)
                                {
                                    if (book.BookID == borrow.BookID)
                                    {
                                        book.BookCount += borrow.BorrowBookCount;
                                    }
                                }
                                Console.WriteLine("--Book Returned Successfully--");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance. Please rechange and proceed");
                            }
                        }
                        else
                        {
                            borrow.Status = Status.Borrowed;
                            foreach (BookDetails book in bookDetailsList)
                            {
                                if (book.BookID == borrow.BookID)
                                {
                                    book.BookCount += borrow.BorrowBookCount;
                                }
                            }
                            Console.WriteLine("Book Borrowed Successfully---");
                        }
                    }
                }
                if(IsFlag1)
                {
                    Console.WriteLine("Invalid ID");
                }
            }
        }



        public static void WalletRecharge()
        {
            Console.WriteLine(" Enter Yes-- If You want to Reacharge:");
            string recharge = Console.ReadLine().ToLower();
            if (recharge == "yes")
            {
                Console.WriteLine("Enter Amount to Recharge(More than zero): ");

                double toRecharge = int.Parse(Console.ReadLine());
                if (toRecharge > 0)
                {
                    currentLoginUser.WalletRecharge(toRecharge);
                }
                else
                {
                    Console.WriteLine("--Invalid Amount--");
                }
            }
        }



    }
}