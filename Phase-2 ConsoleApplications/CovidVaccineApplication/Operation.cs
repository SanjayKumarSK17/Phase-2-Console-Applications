using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccineApplication
{
    public static class Operation
    {
        static List<Beneficiary> beneficiaryList = new List<Beneficiary>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();
        static Beneficiary currentLoginUser;
        public static void AddDefaultData()
        {
            Beneficiary beneficiary1 = new Beneficiary("Ravichandran", 21, Gender.Male, 8484484, "Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskaran", 21, Gender.Male, 8484747, "Chennai");
            beneficiaryList.Add(beneficiary1);
            beneficiaryList.Add(beneficiary2);

            Vaccine vaccine1 = new Vaccine(VaccineName.Covishield, 50);
            Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine, 50);
            vaccineList.Add(vaccine1);
            vaccineList.Add(vaccine2);

            Vaccination vaccination1 = new Vaccination("BID1001", "	CID2001", 1, new DateTime(2021, 11, 11));
            Vaccination vaccination2 = new Vaccination("BID1001", "	CID2001", 2, new DateTime(2021, 03, 11));
            Vaccination vaccination3 = new Vaccination("BID1002", "	CID2001", 1, new DateTime(2021, 04, 04));
            vaccinationList.Add(vaccination1);
            vaccinationList.Add(vaccination2);
            vaccinationList.Add(vaccination3);

            Console.WriteLine("-Default Data For Beneficiary Class-");
            foreach (Beneficiary beneficies in beneficiaryList)
            {
                Console.WriteLine($"{beneficies.RegistrationNumber} | {beneficies.Name} | {beneficies.Age} | {beneficies.Gender} | {beneficies.MobileNumber} | {beneficies.City}");
            }

            Console.WriteLine("-Default Values for Vaccine-");
            foreach (Vaccine vaccinee in vaccineList)
            {
                Console.WriteLine($"{vaccinee.VaccineID} | {vaccinee.VaccineName} | {vaccinee.NoOfDoseAvailable}");
            }

            Console.WriteLine("-Default Values for Vaccination-");
            foreach (Vaccination vaccinationn in vaccinationList)
            {
                Console.WriteLine($"{vaccinationn.VaccinationID} | {vaccinationn.RegistrationNumber} | {vaccinationn.VaccineID} | {vaccinationn.DoseNumber} | {vaccinationn.VaccinatedDate.ToString("dd/MM/yyyy")}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true; ;
            do
            {
                Console.WriteLine("-- Covid Vaccination--");
                Console.WriteLine("Select 1.Beneficiary Registration  2.Login  3.Get Vaccine Info  4.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            BeneficiaryRegistration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            GetVaccineInfo();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("--Application Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void BeneficiaryRegistration()
        {
            Console.WriteLine("--Beneficiary Registration--");
            Console.WriteLine("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Gender(Male, Female,  Others): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter Your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your City: ");
            string city = Console.ReadLine();
            Beneficiary benficies = new Beneficiary(name, age, gender, mobileNumber, city);
            beneficiaryList.Add(benficies);
            Console.WriteLine($"Completed Your Registration--  & Your Registration Number is:  {benficies.RegistrationNumber}");
        }

        public static void Login()
        {
            bool IsFlag = true;
            Console.WriteLine("--Welcome to Usser Login--");
            Console.WriteLine("Enter Your Registration Number: ");
            string registerNumber = Console.ReadLine().ToUpper();
            foreach (Beneficiary benefices in beneficiaryList)
            {
                if (registerNumber == benefices.RegistrationNumber)
                {
                    Console.WriteLine("--Login Successful--");
                    currentLoginUser = benefices;
                    IsFlag = false;
                    SubMenu();
                    break;
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--Invalid Register Number--");
            }
        }

        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("Select   1.Show My Details   2.Take Vaccination    3.My Vaccination History  4.Next Due Date     5.Exit ");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            ShowMyDetails();
                            break;
                        }
                    case 2:
                        {
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            MyVaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("--Login Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void ShowMyDetails()
        {
            Console.WriteLine($"{currentLoginUser.RegistrationNumber} | {currentLoginUser.Name} | {currentLoginUser.Age} | {currentLoginUser.Gender} | {currentLoginUser.MobileNumber} | {currentLoginUser.City}");

        }

        public static void TakeVaccination()
        {
            Console.WriteLine("- Vaccine Available-");
            foreach (Vaccine vaccinee in vaccineList)
            {
                Console.WriteLine($"{vaccinee.VaccineID} | {vaccinee.VaccineName} | {vaccinee.NoOfDoseAvailable}");
            }

            DateTime maxDate = DateTime.Today;
            foreach (Vaccination history in vaccinationList)
            {
                if (currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                {
                    maxDate = history.VaccinatedDate;
                    if (history.VaccinatedDate > maxDate)
                    {
                        maxDate = history.VaccinatedDate;
                    }
                }
            }
            int check = 1;
            foreach (Vaccination history in vaccinationList)
            {
                if (currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                {
                    check = history.DoseNumber;
                }
            }
            foreach (Vaccination vaccinationn in vaccinationList)
            {
                if (currentLoginUser.RegistrationNumber == vaccinationn.RegistrationNumber)
                {
                    Console.WriteLine($"{vaccinationn.VaccinationID} | {vaccinationn.RegistrationNumber} | {vaccinationn.VaccineID} | {vaccinationn.DoseNumber} | {vaccinationn.VaccinatedDate.ToString("dd/MM/yyyy")}");
                }
            }

            bool IsFlag = true;
            bool IsFlag1 = true;
            // 
            Console.WriteLine("Select Vaccine by Entering  Vaccine ID: ");
            string vaccineID1 = Console.ReadLine().ToUpper();

            foreach (Vaccine details in vaccineList)
            {
                if (vaccineID1 == details.VaccineID)
                {
                    IsFlag = false;
                    int tempDoseNumber = 1;
                    foreach (Vaccination history in vaccinationList)
                    {
                        //Console.WriteLine($"{history.VaccinationID} | {currentLoginUser.RegistrationNumber} | {history.VaccineID} | {history.DoseNumber} | {history.VaccinatedDate.ToString("dd/MM/yyyy")}");
                        //	If he didn’t take any vaccine means check his age is above 14.
                        if (currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                        {
                            IsFlag1 = false;
                            if (tempDoseNumber == 3)
                            {
                                if (currentLoginUser.Age > 14)
                                {
                                    Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
                                }
                            }
                            if (tempDoseNumber == check)
                            {
                                if (history.VaccineID == vaccineID1)
                                {
                                    if (history.VaccinatedDate.AddDays(30) <= DateTime.Today)
                                    {
                                        IsFlag1 = true;
                                        tempDoseNumber = history.DoseNumber + 1;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("You are not completed 30 Days after Vaccination.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have selected different vaccine”. You can vaccine with “Covaccine / Covishield (His first / second dose vaccine type)");
                                }
                            }
                        }

                        if (IsFlag1 && currentLoginUser.Age > 14)
                        {
                            Vaccination vaccinations = new Vaccination(currentLoginUser.RegistrationNumber, vaccineID1, tempDoseNumber, DateTime.Today);
                            vaccinationList.Add(vaccinations);
                            details.NoOfDoseAvailable -= 1;
                            System.Console.WriteLine($"Vaccinated Succesffully & Vaccine ID: {history.VaccinationID}");
                        }
                    }
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("--Invalid Vaccine ID--");
            }
        }

        public static void MyVaccinationHistory()
        {
            foreach (Vaccination history in vaccinationList)
            {
                if (currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                {
                    Console.WriteLine($"{history.VaccinationID} | {currentLoginUser.RegistrationNumber} | {history.VaccineID} | {history.DoseNumber} | {history.VaccinatedDate.ToString("dd/MM/yyyy")}");
                }
            }
        }

        public static void NextDueDate()
        {
            //•	Show the next due date for the current beneficiary by finding his details from his vaccination history. 
            //•	If he didn’t take any dose already. Then show “you can take vaccine now”. 
            //•	If either first or second dose of vaccine completed means Add 30 days to find the next due date to vaccine.
            //•	If he completed the third dose, display “You have completed all vaccination. Thanks for your participation in the vaccination drive.”
            bool IsFlag = true;
            DateTime maxDate = DateTime.Today;
            int tempDoseNumber = 0;
            foreach (Vaccination history in vaccinationList)
            {
                if (currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                {
                    maxDate = history.VaccinatedDate;
                    if (history.VaccinatedDate > maxDate)
                    {
                        maxDate = history.VaccinatedDate;
                    }
                }
            }
            // DateTime maxDate = DateTime.Today;
            foreach (Vaccination history in vaccinationList)
            {
                if (currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                {
                    tempDoseNumber = history.DoseNumber;
                }
            }
            foreach (Vaccination history in vaccinationList)
            {
                if (tempDoseNumber != 3 && currentLoginUser.RegistrationNumber == history.RegistrationNumber)
                {
                    IsFlag = false;
                    Console.WriteLine("Next Due Date: " + maxDate.AddDays(30).ToString("dd/MM/yyyy"));
                    break;
                }
            }
            if (tempDoseNumber == 3)
            {
                System.Console.WriteLine("Completed Vaccination");
            }
            if (IsFlag)
            {
                System.Console.WriteLine("You can take Vaccine");
            }



        }

        public static void GetVaccineInfo()
        {
            //Show the available vaccine name and count details in the current date to plan your vaccination today.
            Console.WriteLine("Available Vaccine Details----");
            foreach (Vaccine vaccinee in vaccineList)
            {
                Console.WriteLine($" | {vaccinee.VaccineName} | {vaccinee.NoOfDoseAvailable}");
            }
        }

    }
}