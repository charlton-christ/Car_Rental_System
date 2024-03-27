using System;
using CarRentalSystem.Repository;

namespace CarRentalSystem.Exceptions
{
	internal class CarNotFoundException : Exception
	{
        public CarNotFoundException(string message) : base(message)
        {

        }

        public static void CarNotFound(int vehicleID)
        {
            ICarLeaseRepositoryImpl leaseProcessor = new ICarLeaseRepositoryImpl();
            if (!leaseProcessor.CarExists(vehicleID))
            {
                throw new CarNotFoundException("Car not found");
            }
        }
    }
}

