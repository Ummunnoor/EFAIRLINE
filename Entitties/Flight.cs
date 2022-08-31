using System;
using EFAirLine.Entities;
using EFAIRLINE.Enum;
namespace EFAIRLINE.Entities
{
    public class Flight: BaseEntity
    {
        public int Number { get; set; }
        public int AvailableNumberOfSeat { get; set; }
        public FlightType Type { get; set; }
         public AirCraft AirCraft { get; set; }
        public List<Passenger> Passengers { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
         public string TakeOffPoint { get; set; }
          public DateTime BoardDate { get; set; }
        public bool IsAvailable { get; set; }
        public int FlightId { get; internal set; }
    }
}