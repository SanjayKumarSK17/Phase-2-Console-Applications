using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalApplication
{
    public class MedicineDetails
    {
        private static int s_MedicineID=2000;
        public string MedicineID { get; set; }
        public string MedicineName{ get; set; }
        public int AvailableCount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public MedicineDetails(string medicineName, int availableCount, double price, DateTime daateOfExpiry)
        {
            s_MedicineID++;
            MedicineID="MD"+s_MedicineID;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DateOfExpiry=daateOfExpiry;
        }
    }
}