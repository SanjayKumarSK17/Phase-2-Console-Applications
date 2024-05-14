using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryApplication
{
    public enum Department{Select, ECE, EEE, CSE}
    public class UserDetails
    {
        private static int s_userId=3000;
        public string UserID { get; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public Department Department { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }

        public UserDetails(string userName, string gender, Department department, long mobileNumber, string mailID, double walletBalance)
        {
            s_userId++;
            UserID="SF" +s_userId;
            UserName=userName;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;
        }

        public void WalletRecharge(double rechargeAmount)
        {
            WalletBalance=WalletBalance+rechargeAmount;
            Console.WriteLine("--- Recharge Successful--- Balance: " + WalletBalance);
            //return WalletBalance;
        }

        public void DeductBalance(double deduct)
        {
            WalletBalance=WalletBalance-deduct;
            //return WalletBalance;
        }


    }
}