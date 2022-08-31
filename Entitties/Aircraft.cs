using EFAIRLINE.Entities;

namespace EFAirLine.Entities
{
    public class AirCraft : BaseEntity
    {
        public string Number { get; set; }
        public List<Flight> Flights { get; set; }
        public int Capacity { get; set; }
         public string Name { get; set; }
    }
}