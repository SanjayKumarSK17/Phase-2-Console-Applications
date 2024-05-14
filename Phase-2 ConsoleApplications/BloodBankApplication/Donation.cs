using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankApplication
{
    public enum BloodGroup {Select, A_Positive, B_Positive, O_Positive, AB_Positive}
    public class Donation
    {
        private static int s_donationID=1000;
        public string DonationID { get;  }
        public string DonorID { get; set; }
        public DateTime DonationDate{ get; set; }
        public double Weight { get; set; }
        public int BloodPressure { get; set; }
        public double HemoglobinCount { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public Donation(string donorID, DateTime donationDate, double weight,int bloodPressure, double hemoglobinCount, BloodGroup bloodGroup)
        {
            s_donationID++;
            DonationID="DID"+s_donationID;
            DonorID=donorID;
            DonationDate=donationDate;
            Weight=weight;
            BloodPressure=bloodPressure;
            HemoglobinCount=hemoglobinCount;
            BloodGroup=bloodGroup;
        }

    }
}