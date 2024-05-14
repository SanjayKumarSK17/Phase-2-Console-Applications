using System;
namespace SyncfusionAdmission;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();

    //    Operations.AddDefaultData();

        FileHandling.ReadFromCSV();

        Operations.MainMenu();
        
        FileHandling.writeToCSV();
    }
}