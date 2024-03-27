using CarRentalSystem.Utility;
using CarRentalSystem.Model;
namespace CarRentalSystem.Repository
{
	internal class ICarLeaseRepositoryImpl : ICarLeaseRepository
	{
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public LeaseProcessor()
        {
            connect = new SqlConnection(DatabaseConnectivity.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void removeCar(int carID)
        {
            cmd.CommandText = "Delete from [Vehicle] where userId=@user";
            cmd.Parameters.AddWithValue("@user", carID);
            connect.Open();
            cmd.Connection = connect;
            int status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
                Console.WriteLine($"The car with {carID} is removed");
            Console.WriteLine($"The car with {carID} is not removed");
        }

        public void addCar(VehicleTable car)
        {
            int status = 0;
            if (CarExists(VehicleTable.vehicleID))
            {
                cmd.CommandText = "Insert into [Vehicle] values @carID";
                cmd.Parameters.AddWithValue("@carID", VehicleTable.vehicle_ID);
                connect.Open();
                cmd.Connection = connect;
                status = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
            }
            else
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "Insert into [Vehicle] values (@carID,@carMake,@carModel,@carYear,@carRate,@carStatus,@passengerCapacity,@engineCapacity)";
                cmd.Parameters.AddWithValue("@carID", VehicleTable.vehicleID);
                cmd.Parameters.AddWithValue("@carMake", VehicleTable.vehicleMake);
                cmd.Parameters.AddWithValue("@carModel", VehicleTable.vehicleModel);
                cmd.Parameters.AddWithValue("@carYear", VehicleTable.vehicleYear);
                cmd.Parameters.AddWithValue("@carRate", VehicleTable.vehicleRate);
                cmd.Parameters.AddWithValue("@carStatus", VehicleTable.vehicleStatus);
                cmd.Parameters.AddWithValue("@passengerCapacity", VehicleTable.passengerCapacity);
		cmd.Parameters.AddWithValue("@engineCapacity", VehicleTable.engineCapacity);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
                connect.Open();
                cmd.CommandText = "Insert into [Vehicle] values(@carID)";
                cmd.Parameters.AddWithValue("@carID", VehicleTable.vehicleID);
                status = cmd.ExecuteNonQuery();
                connect.Close();
                cmd.Parameters.Clear();
                connect.Close();
            }
            if (status > 0)
                Console.WriteLine($"The car is added successfully");
            Console.WriteLine($"The car is not added");
        }

        public bool CarExists(int carID)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as totalcount from [Vehicle] where vehicle_ID=@carID";
            cmd.Parameters.AddWithValue("@vehicle_ID", carID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["totalcount"];
            }
            connect.Close();
            if (count > 0)
                return true;
            return false;
        }

 	public List<VehicleTable> listAvailableCars()
        {
            List<VehicleTable> vehicle = new List<VehicleTable>();
            cmd.CommandText = "Select * from Vehicle";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                VehicleTable vehicles = new VehicleTable();
                vehicles.vehicleID = (int)reader["VehicleID"];
                vehicles.vehicleMake = (string)reader["Vehicle_Make"];
                vehicles.vehicleModel = (string)reader["Vehicle_Model"];
                vehicles.vehicleYear = (decimal)reader["Vehicle_Year"];
                vehicles.vehicleRate = (double)reader["Vehicle_Rate"];
                vehicles.vehicleStatus = (string)reader["Vehicle_Status"];
		vehicles.passengerCapacity = (int)reader["Passenger_Capacity"];
  		vehicles.engineCapacity = (double)reader["Engine_Capacity"];
                vehicles.Add(vehicle);
            }
            connect.Close();
            return vehicle;
        }

 	public List<VehicleTable> listRentedCars()
        {
            List<VehicleTable> vehicle = new List<VehicleTable>();
            cmd.CommandText = "Select * from Vehicle where Vehicle_Status = 'notAvailable'";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                VehicleTable vehicles = new VehicleTable();
                vehicles.vehicleID = (int)reader["VehicleID"];
                vehicles.vehicleMake = (string)reader["Vehicle_Make"];
                vehicles.vehicleModel = (string)reader["Vehicle_Model"];
                vehicles.vehicleYear = (decimal)reader["Vehicle_Year"];
                vehicles.vehicleRate = (double)reader["Vehicle_Rate"];
                vehicles.vehicleStatus = (string)reader["Vehicle_Status"];
		vehicles.passengerCapacity = (int)reader["Passenger_Capacity"];
  		vehicles.engineCapacity = (double)reader["Engine_Capacity"];
                vehicles.Add(vehicle);
            }
            connect.Close();
            return vehicle;
        }

 	public List<VehicleTable> findCarByID(int carID)
        {
            List<VehicleTable> vehicles = new List<VehicleTable>();
            cmd.CommandText = "Select * from Vehicle where VehicleID = @carID";
            cmd.Parameters.AddWithValue("@carID", Vehicle.VehicleID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                VehicleTable vehicles = new VehicleTable();
                vehicles.vehicleID = (int)reader["VehicleID"];
                vehicles.vehicleMake = (string)reader["Vehicle_Make"];
                vehicles.vehicleModel = (string)reader["Vehicle_Model"];
                vehicles.vehicleYear = (decimal)reader["Vehicle_Year"];
                vehicles.vehicleRate = (double)reader["Vehicle_Rate"];
                vehicles.vehicleStatus = (string)reader["Vehicle_Status"];
		vehicles.passengerCapacity = (int)reader["Passenger_Capacity"];
  		vehicles.engineCapacity = (double)reader["Engine_Capacity"];
                vehicles.Add(vehicle);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return vehicles;
        }

 	public List<CustomerTable> listCustomers()
        {
            List<CustomerTable> customer = new List<CustomerTable>();
            cmd.CommandText = "Select * from Customer";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CustomerTable customers = new CustomerTable();
                customers.customerID = (int)reader["CustomerID"];
                customers.firstName = (string)reader["FirstName"];
                customers.lastName = (string)reader["LastName"];
                customers.customerMail = (decimal)reader["CustomerMail"];
                customers.customerNumber = (double)reader["CustomerNumber"];
                customers.Add(vehicle);
            }
            connect.Close();
            return customer;
        }

      public List<CustomerTable> findCustomerByID(int customerID)
        {
            List<CustomerTable> customer = new List<CustomerTable>();
            cmd.CommandText = "Select * from Customer where CutomerID = @customerID";
            cmd.Parameters.AddWithValue("@customerID", Customer.CustomerID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CustomerTable customers = new CustomerTable();
                customers.customerID = (int)reader["CustomerID"];
                customers.firstName = (string)reader["FirstName"];
                customers.lastName = (string)reader["LastName"];
                customers.customerMail = (decimal)reader["CustomerMail"];
                customers.customerNumber = (double)reader["CustomerNumber"];
                customers.Add(vehicle);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return customer;
        }

        public void addCustomer(Customer customer)
        {
            int status = 0;

            cmd.CommandText = "Insert into Customer values (@customerID,@firstName,@lastName,@customerMail,@customerNumber)";
            cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@lastName", customer.LastName);
            cmd.Parameters.AddWithValue("@customerMail", customer.CustomerMail);
            cmd.Parameters.AddWithValue("@customerNumber", customer.CustomerNumber);
            connect.Open();
            cmd.Connection = connect;
            status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();

            if (status > 0)
                Console.WriteLine("The Customer is added successfully");
             Console.WriteLine("The Customer is not added");
        }
        
    }
}

