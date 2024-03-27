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

        public bool IfAdminOrNot(int id)
        {
            string role = "";
            try
            {
                cmd.CommandText = "select [role] from [User] where userId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connect;

                connect.Open();

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    role = (string)r["role"];
                }
                if (role.Equals("Admin"))
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool createProduct(User user, Product product)
        {
            int status = 0;

            cmd.CommandText = "Insert into Product values (@name,@desc,@price,@qty,@type)";
            cmd.Parameters.AddWithValue("@name", product.ProductName);
            cmd.Parameters.AddWithValue("@desc", product.Description);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@qty", product.QuantityInStock);
            cmd.Parameters.AddWithValue("@type", product.Type);
            connect.Open();
            cmd.Connection = connect;
            status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();

            if (status > 0)
                return true;
            return false;
        }

        public bool createUser(User user)
        {
            cmd.CommandText = "Insert into [User] values (@name,@pwd,@role)";
            cmd.Parameters.AddWithValue("@name", user.UserName);
            cmd.Parameters.AddWithValue("@pwd", user.Password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            connect.Open();
            cmd.Connection = connect;
            int status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
                return true;
            return false;
        }

        

        public List<Product> getOrderByUser(User user)
        {
            List<Product> products = new List<Product>();
            cmd.CommandText = "Select * from Product p join [Order] o on p.productId=o.productId where o.userId=@userid";
            cmd.Parameters.AddWithValue("@userid", user.UserId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["productId"];
                product.ProductName = (string)reader["productName"];
                product.Description = (string)reader["description"];
                product.Price = (decimal)reader["price"];
                product.QuantityInStock = Convert.IsDBNull(reader["quantityInStock"]) ? null : (int)reader["quantityInStock"];
                product.Type = (string)reader["type"];
                products.Add(product);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return products;
        }

        public bool OrderExists(int orderId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from [Order] where orderId=@id";
            cmd.Parameters.AddWithValue("@id", orderId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            if (count > 0)
                return true;
            return false;
        }
        
    }
}

