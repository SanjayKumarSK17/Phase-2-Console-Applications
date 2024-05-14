using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHApplication
{
    public class RechargeHistory
    {
        private static int s_rechargeID=100;
        public string RechargeID { get; }
        public string UserID { get; set; }
        public string PackID{ get; set; }
        public DateTime RechargeDate{ get; set; }
        public double RechargeAmount { get; set; }
        public DateTime ValidTill { get; set; }
        public int NumberOfChannels { get; set; }

        public RechargeHistory(string userID, string packID, DateTime rechargedate,double rechargeAmount, DateTime validTill, int numberOfChannels)
        {
            s_rechargeID++;
            RechargeID="RP"+s_rechargeID;
            UserID=userID;
            PackID=packID;
            RechargeDate=rechargedate;
            RechargeAmount=rechargeAmount;
            ValidTill=validTill;
            NumberOfChannels=numberOfChannels;
        }
    }
}