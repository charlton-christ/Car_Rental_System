using System;
namespace CarRentalSystem.Model
{
	public class LeaseTable
	{
		private int leaseID;
		private int vehicleID;
		private int customerID;
		private DateOnly startDate;
		private DateOnly endDate;
		private string type;

		public int LeaseID { get { return leaseID; } set { leaseID = value; } }
		public int VehicleID { get { return vehicleID; } set { vehicleID = value; } }
		public int CustomerID { get { return customerID; } set { customerID = value; } }
		public DateOnly StartDate { get { return startDate; } set { startDate = value; } }
		public DateOnly EndDate { get { return endDate; } set { endDate = value; } }
		public string Type
		{
			get { return type; }
			set
			{
				if(value == "DailyLease" || value == "MonthlyLease")
				{
					type = value;
				}
				else
				{
					throw new ArgumentException("Type should only be DailyLease or MonthlyLease");
				}
			}
		}

		public LeaseTable()
		{
		}

		public LeaseTable(int leaseID, int vehicleID, int customerID, DateOnly startDate, DateOnly endDate, string type)
		{
			LeaseID = leaseID;
			VehicleID = vehicleID;
			CustomerID = customerID;
			StartDate = startDate;
			EndDate = endDate;
			Type = type;
		}

        public override string ToString()
        {
            return $"{LeaseID} {VehicleID} {CustomerID} {StartDate} {EndDate} {Type}";
        }
    }
}

