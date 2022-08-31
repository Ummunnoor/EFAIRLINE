using EFAIRLINE.Enum;
using System;
namespace EFAIRLINE.Entities
{
    public class Booking: BaseEntity
    {
        public BookingStatus Status { get; set; }
        public Passenger passenger { get; set; }
        public string Reference { get; set; }
        public int PassengerId { get; set; }
        public DateTime TakeOffDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string TakeOffPoint { get; set; }
        public string Destination { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
         public bool IsBoarded { get; set; }

    }
}