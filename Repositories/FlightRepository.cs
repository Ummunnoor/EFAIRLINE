using EFAIRLINE.Context;
using EFAIRLINE.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFAirLine.Repositories
{
    public class FlightRepository
    {
        private readonly EFAIRLINEDbContext _context;
        public FlightRepository(EFAIRLINEDbContext efairlinedbcontext)
        {
            efairlinedbcontext = _context;
        }
        public bool Create(Flight flight)
        {
            if(flight == null)
            {
                Console.WriteLine("Flight is null");
                return false;
            }
            else
            {
                _context.Flights.Add(flight);
                _context.SaveChanges();
                return true;
            }
        }
        public bool Update(Flight updatedFlight)
        {
            _context.Update(updatedFlight);
            _context.SaveChanges();
            return true;
        }
        public bool CreateFlights(List<Flight> flights)
        {
            _context.Flights.AddRange(flights);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int flightId)
        {
            var flight = _context.Flights.Where(x => x.Id == flightId).SingleOrDefault();
            if(flight == null)
            {
               Console.WriteLine("Flight not found");
               return false; 
            }
            else
            {
            _context.Flights.Remove(flight);
            _context.SaveChanges();
            return true;
            }
        }
        public Flight GetById(int flightId)
        {
            return _context.Flights.Find(flightId); 
        }
        public List<Flight> List()
        {
            return _context.Flights.ToList();
        }
        public List<Flight> GetByFlightStatus(bool isAvailable)
        {
             return _context.Flights.Where(x => x.IsAvailable == isAvailable).ToList();
        }
        public bool ChangeFlightStatus(string takeOffPoint,string destination, bool isAvailable)
        {
            var flight = _context.Flights.Where(c => c.TakeOffPoint == takeOffPoint&& c.Destination == destination).SingleOrDefault();
            if (flight == null)
            {
                return false;
                Console.WriteLine("Flight not available");
            }
            flight.IsAvailable = isAvailable;
            _context.Flights.Update(flight);
            _context.SaveChanges();
           return isAvailable;
        }
        public Flight GetByAvailableNumberOfSeat(int availableNumberOfSeat)
        {
            return _context.Flights.Find(availableNumberOfSeat);
        }
    }
}
 