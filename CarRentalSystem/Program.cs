using CarRentalSystem.Car_Rental_System;

namespace CarRentalSystem;

internal class Program
{
    static void Main(string[] args)
    {
        SystemManagement systemManagement = new SystemManagement();
        systemManagement.menu();
    }
}

