using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    public static class Operations
    {
        static List<Donation> donationList = new List<Donation>();
        static List<UserRegistration> userRegistrationList = new List<UserRegistration>();
        static UserRegistration currentLoginDonor;

        public static void AddDefaultData()
        {
            Console.WriteLine("--Adding Default Data--");

            UserRegistration user1 = new UserRegistration("Ravichandran", 8484848, BloodGroup.O_Positive, 30, new DateTime(2022, 08, 25));
            UserRegistration user2 = new UserRegistration("Baskaran", 4784848, BloodGroup.AB_Positive, 30, new DateTime(2022, 09, 30));
            userRegistrationList.Add(user1);
            userRegistrationList.Add(user2);

            Donation donation1 = new Donation("UID1001", new DateTime(2022, 06, 10), 73, 120, 14, BloodGroup.O_Positive);
            Donation donation2 = new Donation("UID1001", new DateTime(2022, 10, 10), 74, 120, 14, BloodGroup.O_Positive);
            Donation donation3 = new Donation("UID1002", new DateTime(2022, 06, 11), 74, 120, 13.6, BloodGroup.AB_Positive);
            donationList.Add(donation1);
            donationList.Add(donation2);
            donationList.Add(donation3);

            Console.WriteLine("--User Default Data--");
            foreach (UserRegistration user in userRegistrationList)
            {
                Console.WriteLine($"{user.DonorID} | {user.DonorName} | {user.MobileNumber} | {user.BloodGroup} | {user.LastDonationDate.ToString("dd/MM/yyyy")}");
            }

            Console.WriteLine("---Donation Details Default Data---");
            foreach (Donation donor in donationList)
            {
                Console.WriteLine($"{donor.DonationID} | {donor.DonorID} | {donor.DonationDate.ToString("dd/MM/yyyy")} | {donor.Weight} | {donor.BloodPressure} | {donor.HemoglobinCount} | {donor.BloodGroup}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("--- Welcome to Blood Bank Management Apllication---");
                Console.WriteLine("Select  1.User Registration  2.User Login  3.Fetch Donor  4.Exit");
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
                            FetchDonorDetails();
                            break;
                        }
                    case 4:
                        {
                            IsFlag = false;
                            Console.WriteLine("--Exit--");
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("---Welcome to User Registration---");
            Console.WriteLine("Enter Donor Name: ");
            string donorName = Console.ReadLine();
            Console.WriteLine("Enter Donor Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Donor Blood Group: ");
            BloodGroup bloodGroup = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            Console.WriteLine("Enter Donor Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Donor Last Donation Date(dd/MM/yyyy): ");
            DateTime lastDonation = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            UserRegistration users = new UserRegistration(donorName, mobileNumber, bloodGroup, age, lastDonation);
            userRegistrationList.Add(users);
            Console.WriteLine("--Welcome You and Your User Registration DONOR ID: " + users.DonorID);
        }

        public static void UserLogin()
        {
            Console.WriteLine("---Welcome to User Login---");
            Console.WriteLine("--Enter your Donor ID: ");
            bool IsFlag = true;
            string donorID = Console.ReadLine();
            foreach (UserRegistration donor in userRegistrationList)
            {
                if (donorID == donor.DonorID)
                {
                    IsFlag = false;
                    currentLoginDonor = donor;
                    SubMenu();
                    break;
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--Invalid Donor ID--");
            }
        }

        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("--Sub Menu");
                Console.WriteLine("Select  1.Donate Blood 	2.Donation History   3.Next Eligible Date	4.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            DonateBlood();
                            break;
                        }
                    case 2:
                        {
                            DonationHistory();
                            break;
                        }
                    case 3:
                        {
                            NextEligibleData();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("--Login Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void DonateBlood()
        {
            // •	Get the weight, blood pressure, hemoglobin count from the user
            Console.WriteLine("Enter your Weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Blood Pressure: ");
            int bloodPressure = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Hemoglobin Details: ");
            double hemoglobinCount = double.Parse(Console.ReadLine());


            // check Weight is above 50, bp is below 130 hemoglobin count is above 13.
            if (weight > 50 && bloodPressure < 130 && hemoglobinCount > 13)
            {
                if (currentLoginDonor.LastDonationDate.AddMonths(6) < DateTime.Today)
                {
                    Donation donation1 = new Donation(currentLoginDonor.DonorID, DateTime.Today, weight, bloodPressure, hemoglobinCount, currentLoginDonor.BloodGroup);
                    donationList.Add(donation1);
                    // donation1(weight,bloodPressure,hemoglobinCount);
                    Console.WriteLine("Blood Donated Successfully: " + currentLoginDonor.DonorID);
                    Console.WriteLine("Next Eligible Date of Donation: " + DateTime.Today.AddMonths(6).ToString("dd/MM/yyyy"));   
                }
                else
                {
                    Console.WriteLine("You already Donated-- Next Eligible Date: " + currentLoginDonor.LastDonationDate.AddMonths(6).ToString("dd/MM/yyyy"));
                }

            }
            else
            {
                Console.WriteLine("You are Not Fit for Blood Donation");
            }
        }

        public static void DonationHistory()
        {
            Console.WriteLine("-your Donation History--");
            bool IsFlag = true;
            foreach (Donation details in donationList)
            {
                if (currentLoginDonor.DonorID == details.DonorID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{details.DonationID} | {details.DonorID} | {details.DonationDate.ToString("dd/MM/yyyy")} | {details.Weight} | {details.BloodPressure} | {details.HemoglobinCount} | {details.BloodGroup}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("-- No Donation Done--");
            }
        }

        public static void NextEligibleData()
        {
            //DateTime lastDonationDate = currentLoginDonor.LastDonationDate;
            //Show the next eligible date for the user (6 months from the date of last donation). If the user donates 2 times, last donation must be user recently donated date. 
            DateTime maximum = DateTime.Today;
            foreach (Donation donation in donationList)
            {
                if (currentLoginDonor.DonorID == donation.DonorID)
                {
                    if (donation.DonationDate < maximum)
                    {
                        maximum = donation.DonationDate;
                    }
                }
            }
            Console.WriteLine("Next Eligible Date: " + maximum.AddMonths(6).ToString("dd/MM/yyyy"));

            //Console.WriteLine(spandate.TotalDays.ToString("dd/MM/yyyy") + "--still");
        }

        public static void FetchDonorDetails()
        {
            Console.WriteLine("--Searching Blood Group(A_Positive, B_Positive, O_Positive, AB_Positive) ---");
            Console.WriteLine("Enter Blood Group: ");
            // 1.	Ask for “Blood Group” and check blood group in the Donation details and 
            // it should display the donor’s name and phone number and native place.
            BloodGroup bloodGroup = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            bool IsFlag = true;
            foreach (UserRegistration user in userRegistrationList)
            {
                if (bloodGroup == user.BloodGroup)
                {
                    IsFlag = false;
                    Console.WriteLine($" {user.DonorName} | | {user.MobileNumber}");
                    break;
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("No Blood Group Found");
            }
        }


    }
}