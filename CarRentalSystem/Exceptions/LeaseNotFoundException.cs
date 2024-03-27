using System;
using CarRentalSystem.Repository;

namespace CarRentalSystem.Exceptions
{
	internal class LeaseNotFoundException : Exception
	{
        public LeaseNotFoundException(string message) : base(message)
        {

        }

        public static void LeaseNotFound(int orderId)
        {
            ICarLeaseRepositoryImpl leaseProcessor = new ICarLeaseRepositoryImpl();
            if (!leaseProcessor.LeaseExists(orderId))
            {
                throw new LeaseNotFoundException("Lease not found");
            }
        }
    }
}

