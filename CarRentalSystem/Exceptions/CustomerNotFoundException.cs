using System;
using CarRentalSystem.Repository;

namespace CarRentalSystem.Exceptions
{
	internal class CustomerNotFoundException : Exception
	{
        public CustomerNotFoundException(string message) : base(message)
        {

        }

        public static void UserNotFound(int userId)
        {
            ICarLeaseRepositoryImpl leaseProcessor = new ICarLeaseRepositoryImpl();
            if (!leaseProcessor.CustomerExists(userId))
            {
                throw new CustomerNotFoundException("Customer not found");
            }
        }
    }
}

