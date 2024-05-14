using System;
namespace ECommerceApplication;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();

        //Operations.AddDefaultData();

        FileHandling.ReadFromCSV();

        Operations.MainMenu();

        FileHandling.WriteToCSV();
    }
}