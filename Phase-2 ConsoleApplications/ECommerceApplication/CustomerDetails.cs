using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class CustomerDetails
    {
        private static int s_customerID=3000;
        public string CustomerID { get;  }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long MobileNumber { get; set; }
        public double WalletBalance { get; set; }
        public string EmailID { get; set; }

        public CustomerDetails(string customerName, string city, long mobileNumber, double walletBalance, string emailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            CustomerName=customerName;
            City=city;
            MobileNumber=mobileNumber;
            WalletBalance=walletBalance;
            EmailID=emailID;
        }

        public CustomerDetails(string customer)
        {
            string[] array=customer.Split(',');

            CustomerID=array[0];
            s_customerID=int.Parse(array[0].Remove(0,3));
            CustomerName=array[1];
            City=array[2];
            MobileNumber=long.Parse(array[3]);
            WalletBalance=double.Parse(array[4]);
            EmailID=array[5];
        }

        public void WalletRecharge(double rechargeAmount)
        {
            WalletBalance=WalletBalance+rechargeAmount;
            Console.WriteLine("Recharged Successful & Your Current Wallet Balance: "+WalletBalance);
            
        }

        public void DeductBalance(double deductedAmount)
        {
            WalletBalance=WalletBalance-deductedAmount; 
        }
    }
}