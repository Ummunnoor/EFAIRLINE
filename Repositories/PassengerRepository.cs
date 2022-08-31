using EFAIRLINE.Context;
using EFAIRLINE.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFAIRLINE.Repositories
{
    public class PassengerRepository
    {
        private readonly EFAIRLINEDbContext _context;
        public PassengerRepository(EFAIRLINEDbContext efairlinedbcontext)
        {
            efairlinedbcontext = _context;
        }
        public bool Create(Passenger passenger)
        {
            if(passenger == null)
            {
                Console.WriteLine("Passenger is null");
                return false;
            }
            else
            {
                _context.Passengers.Add(passenger);
                _context.SaveChanges();
                return true;
            }
        }
        public bool Update(Passenger updatedPassenger)
        {
            _context.Update(updatedPassenger);
            _context.SaveChanges();
            return true;
        }
        public Passenger GetById(int passengerId)
        {
            return _context.Passengers
                .Include(p => p.User)
                .SingleOrDefault(p => p.Id == passengerId);
        }
        public Passenger GetByEmail(string email)
        {
            return _context.Passengers
                .Include(c => c.User)
                .FirstOrDefault(c => c.User.Email == email);
        }
        public bool Delete(int passengerId)
        {
            var passenger = _context.Passengers
               .FirstOrDefault(x => x.Id == passengerId);
            if (passenger == null)
            {
                Console.WriteLine("Passenger is Null");
                return false;
            }
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
            return true;
        }

        public List<Passenger> List()
        {
            return _context.Passengers
                .Include(c => c.User)
                .ToList();
        }



    }
}