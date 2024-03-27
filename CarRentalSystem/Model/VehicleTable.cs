using System;
namespace CarRentalSystem.Model
{
	internal class VehicleTable
	{
		private int vehicleID;
		private string vehicleMake;
		private string vehicleModel;
		private int vehicleYear;
		private double vehicleRate;
		private string vehicleStatus;
		private int passengerCapacity;
		private double engineCapacity;

		public int VehicleID { get { return vehicleID; } set { vehicleID = value; } }
		public string VehicleMake { get { return vehicleMake; } set { vehicleMake = value; } }
		public string VehicleModel { get { return vehicleModel; } set { vehicleModel = value; } }
        public int VehicleYear { get { return vehicleYear; } set { vehicleYear = value; } }
		public double VehicleRate { get { return vehicleRate; } set { vehicleRate = value; } }
		public string VehicleStatus { get { return vehicleStatus;}
		set
			{
				if(value == "Available" || value == "NotAvailable")
				{
					vehicleStatus = value;
				}

				else
				{
					throw new ArgumentException("Staus should only be Available or NotAvailable");
				}
			}
		}
		public int PassengerCapacity { get { return passengerCapacity; } set { passengerCapacity = value; } }
		public double EngineCapacity { get { return engineCapacity; } set { engineCapacity = value; } }

        public VehicleTable()
		{

		}

		public VehicleTable(int vehicleID, string vehicleMake, string vehicleModel, int vehicleYear, double vehicleRate, string vehicleStatus, int passengerCapacity, double engineCapacity)
		{
			VehicleID = vehicleID;
			VehicleMake = vehicleMake;
			VehicleModel = vehicleModel;
			VehicleYear = vehicleYear;
			VehicleRate = vehicleRate;
			VehicleStatus = vehicleStatus;
			PassengerCapacity = passengerCapacity;
			EngineCapacity = engineCapacity;
		}

        public override string ToString()
        {
            return $"{VehicleID} {VehicleMake} {VehicleModel} {VehicleYear} {VehicleRate} {VehicleStatus} {PassengerCapacity} {EngineCapacity}";
        }
    }
}

