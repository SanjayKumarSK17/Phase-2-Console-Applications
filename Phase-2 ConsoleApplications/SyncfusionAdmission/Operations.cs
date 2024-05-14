using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public static class Operations
    {
        public static CustomList<StudentDetails> studentList = new CustomList<StudentDetails>();
        public static CustomList<AdmissionDetails> admissionList = new CustomList<AdmissionDetails>();
        public static CustomList<DepartmentDetails> departmentList = new CustomList<DepartmentDetails>();
        static StudentDetails currentLoggedinStudent;
        public static void AddDefaultData()
        {
            Console.WriteLine("Adding Default Data");


            //create list, create objects, add to list, traverse & show added data.

            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettaparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.Add(student1);
            studentList.Add(student2);

            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
            departmentList.Add(department1);
            departmentList.Add(department2);
            departmentList.Add(department3);
            departmentList.Add(department4);

            AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
            admissionList.Add(admission1);
            admissionList.Add(admission2);

            Console.WriteLine("--- Student Default Data--");
            Console.WriteLine("Student ID\t |Name\t\t |FatherName\t |DOB\t | Gender |Physics |Chemistry |Maths");
            foreach (StudentDetails detail in studentList)
            {
                Console.WriteLine($" {detail.StudentID,-10} | {detail.StudentName,-15}| {detail.FatherName,-15}| {detail.DOB.ToString("dd/MM/yyyy")}|  {detail.Gender,-5} |  {detail.PhysicsMark} | {detail.ChemistryMark} | {detail.MathsMark}");
            }

            Console.WriteLine("--- Department Default Data--");
            Console.WriteLine("Department id:\t | DepartmentName:\t\t |NumberOf Seats: ");
            foreach (DepartmentDetails detail in departmentList)
            {
                Console.WriteLine($" {detail.DepartmentID} | {detail.DepartmentName}| {detail.NumberOfSeats} ");
            }

            Console.WriteLine("--- Admission Default Data--");
            Console.WriteLine("Admission ID\t | Student ID\t | Department id\t | Admission Date\t |Admission Status ");
            foreach (AdmissionDetails detail in admissionList)
            {
                Console.WriteLine($" {detail.AdmissionID} |  {detail.StudentID} |   {detail.DepartmentID} | {detail.AdmissionDate} | {detail.AdmissionStatus}  ");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {


                Console.WriteLine();
                Console.WriteLine($"Welcome to Syncfusion College of Enginnering & Technology");
                Console.WriteLine($"1.Student Registration  2.Student Login  3.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            StudentRegistration();
                            //Console.WriteLine("---Registration Selected--");
                            break;
                        }
                    case 2:
                        {
                            StudentLogin();
                            //Console.WriteLine("---Login Selected--");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("---Exit Selected--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void StudentRegistration()
        {
            Console.WriteLine("---Student Registration---");
            Console.WriteLine("Enter Your Name: ");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter Father's Name: ");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter Your DOB: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Enter Gender(Male, Female, Transgender): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter Your Physics Mark: ");
            double physicsMark = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Chemistry Mark: ");
            double chemistryMark = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Maths Mark: ");
            double mathsMark = double.Parse(Console.ReadLine());
            StudentDetails students = new StudentDetails(studentName, fatherName, dob, gender, physicsMark, chemistryMark, mathsMark);
            studentList.Add(students);
            Console.WriteLine($"--Student Rgistered Successfully-- {students.StudentID}");
        }
        public static void StudentLogin()
        {
            Console.WriteLine("---Student Login---");
            // get user id, traverse student list, find user id is present
            //if user-id not present shown invalid user-id, if id present store current loggedin cookie object globally
            // then show sub-menu
            Console.WriteLine("Enter your Student ID: ");
            string loginID = Console.ReadLine().ToUpper();
            bool IsFlagg = true;
            foreach (StudentDetails checkStudent in studentList)
            {
                if (loginID == checkStudent.StudentID)
                {

                    Console.WriteLine("--Successfully Logged In--");
                    IsFlagg = false;
                    currentLoggedinStudent = checkStudent;
                    subMenu();
                    break;
                }
            }
            if (IsFlagg)
            {
                Console.WriteLine("Invalid Student ID!!!");
            }
        }

        public static void subMenu()
        {
            bool IsFlaggg = true;
            do
            {

                Console.WriteLine("-- Select SubMenu--");
                Console.WriteLine("1.Check Eligible  2.Show Details  3.Take Admission  4.Cancel Admission  5.Show Admission Details  6.Exit");

                int toSelct = int.Parse(Console.ReadLine());
                switch (toSelct)
                {
                    case 1:
                        {
                            CheckEligible();
                            break;
                        }
                    case 2:
                        {
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            IsFlaggg = false;
                            Console.WriteLine("-Exit Selected-");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter Correct Option --");
                            break;
                        }
                }
            } while (IsFlaggg);
        }

        public static void CheckEligible()
        {
            Console.WriteLine("--Check Eligible--");
            bool result = currentLoggedinStudent.IsCheckEligible(75.0);
            Console.WriteLine((result) ? "---Student is eligible ---" : "---Student is NOT eligible-- ");
        }
        public static void ShowDetails()
        {
            Console.WriteLine("---Student Details---");
            Console.WriteLine($"Student Name:{currentLoggedinStudent.StudentName} /n Father Name:{currentLoggedinStudent.FatherName} \n DOB:{currentLoggedinStudent.DOB} \n Gender:{currentLoggedinStudent.Gender} \n Physics Mark: {currentLoggedinStudent.PhysicsMark} /n Chemistry Mark:{currentLoggedinStudent.ChemistryMark} \n Maths Mark:{currentLoggedinStudent.MathsMark} ");

        }

        public static void TakeAdmission()
        {
            /*1. Show the list of available departments and number of seats available by traversing the department details list
            2. Ask the student to pick one DepartmentID.
            3 Validate the DepartmentID is present in the list. 
            3.1 If it is present, then check whether he is eligible to take admission.
            If he is eligible, check whether seat available or not, if seats available then Check whether the student has already taken any admission by traversing admission details list. If he didn’t took any admission previously. 
            Then, Reduce the seat count in department list and create admission details object by using StudentID, DepartmentID, AdmissionDate as Now, AdmissionStatus and Booked and add it to list.
            Finally show “Admission took successfully. Your admission ID – SF3001”. */

            Console.WriteLine("Department id:\t | DepartmentName:\t\t |NumberOf Seats: ");
            foreach (DepartmentDetails detail in departmentList)
            {
                Console.WriteLine($" {detail.DepartmentID} | {detail.DepartmentName}| {detail.NumberOfSeats} ");
            }
            //2nd one
            Console.WriteLine($"Select One Department ID: ");
            string departmentID = Console.ReadLine().ToUpper();
            // 3RD ONE(Part one)
            bool Isflag = true;
            foreach (DepartmentDetails detail in departmentList)
            {
                if (departmentID == detail.DepartmentID)
                {
                    // If it is present, then check whether he is eligible to take admission.
                    Isflag = false;
                    bool temp = currentLoggedinStudent.IsCheckEligible(75.0);
                    if (temp)
                    {
                        //If he is eligible, check whether seat available or not, 
                        //if seats available then Check whether the student has already taken any admission by traversing admission details list. If he didn’t took any admission previously.
                        if (detail.NumberOfSeats > 0)
                        {
                            //if seats available then Check whether the student has already taken any admission by traversing admission details list. If he didn’t took any admission previously.
                            bool admissionStatusFlag = true;
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (currentLoggedinStudent.StudentID == admission.StudentID && admission.AdmissionStatus == AdmissionStatus.Admitted)
                                {
                                    admissionStatusFlag = false;
                                }
                            }
                            //Then, Reduce the seat count in department list and create admission details object by using StudentID, DepartmentID, AdmissionDate as Now, AdmissionStatus and Booked and add it to list.
                            if (admissionStatusFlag)
                            {
                                detail.NumberOfSeats--;
                                AdmissionDetails admission = new AdmissionDetails(currentLoggedinStudent.StudentID, detail.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                admissionList.Add(admission);
                                // Finally show “Admission took successfully. Your admission ID – SF3001”.
                                Console.WriteLine($"Admission took successfully. Your admission ID- " + admission.AdmissionID);
                            }
                            else
                            {
                                Console.WriteLine("You Have Already Taken Admission!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Seats Found!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Eligible!!");
                    }
                }
            }
            if (Isflag)
            {
                Console.WriteLine($"No Department ID Found");
            }
        }

        public static void CancelAdmission()
        {
            //•	Show the current logged in student’s admission detail by traversing the list which AdmissionStatus Property is Booked. If fount then show it.
            bool IsFlag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedinStudent.StudentID==admission.StudentID && admission.AdmissionStatus==AdmissionStatus.Admitted)
                {
                    IsFlag=false;
                    //Change the Admission status property to Cancelled.
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //Return the seat to Department Details list
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(department.DepartmentID==admission.DepartmentID)
                        {
                            department.NumberOfSeats++;
                        }
                    }
                    //Finally show admission cancelled successfully.
                    Console.WriteLine("admission cancelled successfully!!");
                }

            }
            if(IsFlag)
            {
                Console.WriteLine("Still you have No Admission Taken");
            }
        }
        public static void ShowAdmissionDetails()
        {
            Console.WriteLine("Admission ID\t | Student ID\t | Department id\t | Admission Date\t |Admission Status ");
            bool IsFlag1 = true;
            foreach (AdmissionDetails detail in admissionList)
            {
                if (currentLoggedinStudent.StudentID == detail.AdmissionID)
                {
                    IsFlag1 = false;
                    Console.WriteLine($" {detail.AdmissionID} |  {detail.StudentID} |   {detail.DepartmentID} | {detail.AdmissionDate} | {detail.AdmissionStatus}  ");
                }
            }
            if (IsFlag1)
            {
                Console.WriteLine("-No Admission Details Found--");
            }
        }

    }
}