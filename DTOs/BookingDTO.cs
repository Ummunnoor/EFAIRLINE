using EFAIRLINE.Entities;
using EFAIRLINE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAIRLINE.DTOs
{
    public class CreateBookingtDto
    {
       public BookingStatus Status { get; set; } public Passenger passenger { get; set; }
        public string TakeOffPoint { get; set; }
        public string Destination { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
    }
    public class UpdateBookingDto
    {
        public Passenger passenger { get; set; }
        public string TakeOffPoint { get; set; }
        public string Destination { get; set; }
        public int FlightId { get; set; }
    }

    public class GetBookingDto
    {
        public Passenger passenger { get; set; }
        public string TakeOffPoint { get; set; }
        public string Destination { get; set; }
        public int FlightId { get; set; }
    }


}
