using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTHApplication
{
    public class PackDetails
    {
        public string PackID { get; set;}
        public string PackName { get; set; }
        public double Price { get; set; }
        public int Validity { get; set; }
        public int NoOfChannels{ get; set;}

        public PackDetails(string packID, string packName, double price, int validity, int noOfChannels)
        {
            PackID=packID;
            PackName=packName;
            Price=price;
            Validity=validity;
            NoOfChannels=noOfChannels;
        }
    }
}