using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccineApplication
{
    public enum VaccineName{Select, Covishield, Covaccine}
    public class Vaccine
    {
        private static int s_vaccineID=2000;
        public string VaccineID { get;  }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        public Vaccine(VaccineName vaccineName, int noOfDoseAvailable)
        {
            s_vaccineID++;
            VaccineID="CID" + s_vaccineID;
            VaccineName=vaccineName;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
    }
}