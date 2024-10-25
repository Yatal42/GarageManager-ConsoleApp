namespace GarageLogic
{
    public class GarageVehicle
    {
        public Vehicle Vehicle { get; private set; }
        public Garage.eVehicleStatus Status { get; set; }
        public string OwnerName { get; private set; }
        public string OwnerPhoneNumber { get; private set; }

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, Garage.eVehicleStatus i_Status)
        {
            Vehicle = i_Vehicle;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            Status = i_Status;
        }
    }
}
