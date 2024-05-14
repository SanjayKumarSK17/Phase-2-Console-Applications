using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public enum AdmissionStatus{Select, Admitted, Cancelled}
    public class AdmissionDetails
    {
        private static int s_admissionID=1000;
        public string AdmissionID { get; }
        public string StudentID { get; set; }
        public string DepartmentID { get;  }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate,AdmissionStatus admissionStatus)
        {
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentID;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;
        }
        public AdmissionDetails(string admission)
        {
            string[] array=admission.Split(',');
            AdmissionID=array[0];
            s_admissionID=int.Parse(array[0].Remove(0,3));
            StudentID=array[1];
            DepartmentID=array[2];
            AdmissionDate=DateTime.ParseExact(array[3],"dd/MM/yyyy",null);
            AdmissionStatus=Enum.Parse<AdmissionStatus>(array[4],true);
        }
    }
}