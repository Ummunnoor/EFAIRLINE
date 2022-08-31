using EFAIRLINE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAIRLINE.DTOs
{
    public class CreateFlightDto
    {
        public int FlightId { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
         public string TakeOffPoint { get; set; }
        public FlightType Type { get; set; }
        public bool isAvailable { get; set; }
        public DateTime BoardDate { get; set; }
    }

    public class GenerateFlightsDto
    {
        public string Destination { get; set; }
         public string TakeOffPoint { get; set; }
        public decimal Price { get; set; }
        public FlightType Type { get; set; }
        public bool isAvailable { get; set; }
    }

    public class UpdateFlightDto
    {
        public string Destination { get; set; }
         public string TakeOffPoint { get; set; }
        public decimal Price { get; set; }
        public FlightType Type { get; set; }
    }

    public class GetFlightDto
    {
        public string Destination { get; set; }
         public string TakeOffPoint { get; set; }
         public DateTime BoardDate { get; set; }
        public int FlightId { get; set; }
        public decimal Price { get; set; }
        public FlightType Type { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class ViewAvailableFlightDto
    {
        public int AvailableNumberOfSeat { get; set; }
        public FlightType Type { get; set; }
        public string Destination { get; set; }
         public string TakeOffPoint { get; set; }
         public DateTime BoardDate { get; set; }
    }
}
