using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccineApplication
{
    public class Vaccination
    {
        private static  int s_vaccinationID=3000;
        public string VaccinationID { get;  }
        public string RegistrationNumber { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }

        public Vaccination(string registrationNumber, string vaccineID,  int doseNumber,  DateTime vaccinatedDate)
        {
            s_vaccinationID++;
            VaccinationID="VID" + s_vaccinationID;
            RegistrationNumber=registrationNumber;
            VaccineID=vaccineID;
            DoseNumber=doseNumber;
            VaccinatedDate=vaccinatedDate;
        }
    }
}