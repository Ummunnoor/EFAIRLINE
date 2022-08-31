using EFAIRLINE.Context;
using EFAIRLINE.Entities;
using EFAIRLINE.Enum;
using Microsoft.EntityFrameworkCore;
namespace EFHOTELAPP.Repositories
{
    public class BookingRepository
    {
         private readonly EFAIRLINEDbContext _context;
        public BookingRepository(EFAIRLINEDbContext efairlinedbcontext)
        {
            efairlinedbcontext = _context;
        }
        public bool Create(Booking booking)
        {
            if(booking == null)
            {
                Console.WriteLine("Booking is not found");
                return false;
            }
            else
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return true;
            }
        }
        public bool Update(int bookingId, Booking updatedBooking)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking can not be null");
                return false;
            }
            else
            {
                booking.TakeOffPoint = updatedBooking.TakeOffPoint;
                booking.Destination = updatedBooking.Destination;
                _context.Bookings.Update(booking);
                _context.SaveChanges();
                return true;
            }
        }
        public List<Booking> List()
        {
            return _context.Bookings.ToList();
        }
        public List<Booking> GetByBookingStatus(BookingStatus status)
        {
            return _context.Bookings.Where(b => b.Status == status).ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public Booking GetByBookingRef(string reference)
        {
            return _context.Bookings.FirstOrDefault(b => b.Reference == reference);
        }
        public List<Booking> GetBookingsByCheckedInStatus(bool isBoarded)
        {
            return _context.Bookings.Where(b => b.IsBoarded == isBoarded).ToList();
        }
        public bool Delete(int bookingId)
        {
            var booking = _context.Bookings.Where(x => x.Id == bookingId).SingleOrDefault();
            if(booking == null)
            {
               Console.WriteLine("Booking not found");
               return false; 
            }
            else
            {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return true;
            }
        }
    }
}