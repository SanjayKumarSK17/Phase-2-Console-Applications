using System;
namespace BloodBankApplication;
class Program
{
    public static void Main(string[] args)
    {
        Operations.AddDefaultData();

        Operations.MainMenu();
    }
}