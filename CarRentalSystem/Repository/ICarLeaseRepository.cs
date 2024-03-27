using CarRentalSystem.Model;
using System;

namespace CarRentalSystem.Repository
{
	internal interface ICarLeaseRepository
	{
		void addCar(VehicleTable car);
		void removeCar(int carID);
		List<VehicleTable> listAvailableCars();
		List<VehicleTable> listRentedCars();
		List<VehicleTable> findCarByID();

		void addCustomer(CustomerTable customer);
		void removeCustomer(int customerID);
		List<CustomerTable> listCustomer();
		List<CustomerTable> findCustomerByID();

		void createLease(int customerID, int carID, DateTime startDate, DateTime endDate);
		void returnCar(int leaseID);
		List<LeaseTable> listActiveLeases();
		List<LeaseTable> listLeaseHistory();

		void recordPayment(LeaseTable lease, double amount);
	}
}

