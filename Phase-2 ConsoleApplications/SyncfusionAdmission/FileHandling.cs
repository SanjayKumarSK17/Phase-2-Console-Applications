using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public static  class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("SyncfusionAdmission"))
            {
                Console.WriteLine("Folder Created");
                Directory.CreateDirectory("SyncfusionAdmission");
            }
            // for student details file
            if(!File.Exists("SyncfusionAdmission/StudentDetails.csv"))
            {
                Console.WriteLine("File- student Details Created");
                File.Create("SyncfusionAdmission/StudentDetails.csv").Close();
            }
            if(!File.Exists("SyncfusionAdmission/DepartmentDetails.csv"))
            {
                Console.WriteLine("File- student Details Created");
                File.Create("SyncfusionAdmission/DepartmentDetails.csv").Close();
            }
            if(!File.Exists("SyncfusionAdmission/AdmissionDetails.csv"))
            {
                Console.WriteLine("File- student Details Created");
                File.Create("SyncfusionAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void writeToCSV()
        {
            // student list
            string[] students=new string[Operations.studentList.Count];// Firsat create string for each classes.
            for(int i=0;i<Operations.studentList.Count;i++)
            {
                students[i]=Operations.studentList[i].StudentID + "," +Operations.studentList[i].StudentName +"," +Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].PhysicsMark +","+Operations.studentList[i].ChemistryMark+","+Operations.studentList[i].MathsMark;
            }
            File.WriteAllLines("SyncfusionAdmission/StudentDetails.csv",students);

            // department list
            string[] departments=new string[Operations.departmentList.Count];
            for(int i=0;i<Operations.departmentList.Count;i++)
            {
                departments[i]=Operations.departmentList[i].DepartmentID + ","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("SyncfusionAdmission/DepartmentDetails.csv",departments);
            //Admission details
            string[] admissions=new string[Operations.admissionList.Count];
            for(int i=0;i<Operations.admissionList.Count;i++)
            {
                admissions[i]=Operations.admissionList[i].AdmissionID +"," +Operations.admissionList[i].StudentID + "," +Operations.admissionList[i].DepartmentID +","+Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("SyncfusionAdmission/AdmissionDetails.csv",admissions);
        }


        public static void ReadFromCSV()
        {
            string[] students=File.ReadAllLines("SyncfusionAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails student1=new StudentDetails(student);
                Operations.studentList.Add(student1);
            }

            string[] departments=File.ReadAllLines("SyncfusionAdmission/DepartmentDetails.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1=new DepartmentDetails(department);
                Operations.departmentList.Add(department1);
            }

            string[] admissions=File.ReadAllLines("SyncfusionAdmission/AdmissionDetails.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1=new AdmissionDetails(admission);
                Operations.admissionList.Add(admission1);
            }
        }
    }
}