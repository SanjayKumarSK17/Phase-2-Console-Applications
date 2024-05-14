using System;
namespace OnlineMedicalApplication;
class Program
{
    public static void Main(string[] args)
    {
        Operations.AddDefaultData();

        Operations.MainMenu();
    }
}