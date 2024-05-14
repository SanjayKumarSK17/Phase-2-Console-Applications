using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public class DepartmentDetails
    {
        private static int s_departmentID=100;
        public string DepartmentID { get;  }
        public string DepartmentName { get; set; }
        public  int NumberOfSeats { get; set; }
        public DepartmentDetails(string departmentName, int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }
        public DepartmentDetails(string department)
        {
            string[] array=department.Split(',');
            DepartmentID=array[0];
            s_departmentID=int.Parse(array[0].Remove(0,3));
            DepartmentName=array[1];
            NumberOfSeats=int.Parse(array[2]);
        }
    }
}