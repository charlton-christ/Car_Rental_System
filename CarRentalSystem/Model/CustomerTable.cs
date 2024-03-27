using System;
namespace CarRentalSystem.Model
{
	internal class CustomerTable
	{
		private int customerID;
		private string firstName;
		private string lastName;
		private string customerEmail;
		private string customerNumber;

		public int CustomerID { get { return customerID; } set { customerID = value; } }
		public string FirstName { get { return firstName; } set { firstName = value; } }
		public string LastName { get { return lastName; } set { lastName = value; } }
		public string CustomerEmail { get { return customerEmail; } set { customerEmail = value; } }
		public string CustomerNumber { get { return customerNumber; } set { customerNumber = value; } }


		public CustomerTable()
		{
		}

		public CustomerTable(int customerID, string firstName, string lastName, string customerEmail, string customerNumber)
		{
			CustomerID = customerID;
			FirstName = firstName;
			LastName = lastName;
			CustomerEmail = customerEmail;
			CustomerNumber = customerNumber;
		}

        public override string ToString()
        {
            return $"{CustomerID} {FirstName} {LastName} {CustomerEmail} {CustomerNumber}";
        }
    }
}

