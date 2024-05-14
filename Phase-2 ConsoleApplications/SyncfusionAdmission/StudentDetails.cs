using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public enum Gender { Select, Male, Female, Transgender }
    public class StudentDetails
    {
        private static int s_studentID = 3000;
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public double PhysicsMark { get; set; }
        public double ChemistryMark { get; set; }
        public double MathsMark { get; set; }


        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, double physicsMark, double chemistryMark, double mathsMark)
        {
            s_studentID++;
            StudentID = "SF" + s_studentID;

            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            PhysicsMark = physicsMark;
            ChemistryMark = chemistryMark;
            MathsMark = mathsMark;
        }

        public StudentDetails(string student)
        {
            string[] array = student.Split(',');

            StudentID = array[0];
            s_studentID = int.Parse(array[0].Remove(0, 2));
            StudentName = array[1];
            FatherName = array[2];
            DOB = DateTime.ParseExact(array[3], "dd/MM/yyyy", null);
            Gender = Enum.Parse<Gender>(array[4], true);
            PhysicsMark = double.Parse(array[5]);
            ChemistryMark = double.Parse(array[6]);
            MathsMark = double.Parse(array[7]);
        }
        public double Average()
        {
            return (double)((PhysicsMark + ChemistryMark + MathsMark) / 3.00);
        }
        public bool IsCheckEligible(double cutOff)
        {
            if (Average() >= cutOff)
            {
                return true;
            }
            return false;
        }
    }
}