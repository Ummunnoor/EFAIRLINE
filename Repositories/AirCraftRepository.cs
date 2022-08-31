using EFAirLine.Entities;
using EFAIRLINE.Context;
using EFAIRLINE.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFAirLine.Repositories
{
    public class AirCraftRepository
    {
        private readonly EFAIRLINEDbContext _context;
        public AirCraftRepository(EFAIRLINEDbContext efairlinedbcontext)
        {
            efairlinedbcontext = _context;
        }
        public bool Create(AirCraft airCraft)
        {
            if(airCraft == null)
            {
                Console.WriteLine("AirCraft is not found");
                return false;
            }
            else
            {
                _context.AirCrafts.Add(airCraft);
                _context.SaveChanges();
                return true;
            }
        }
        public bool Update(AirCraft updatedAirCraft)
        {
            _context.Update(updatedAirCraft);
            _context.SaveChanges();
            return true;
        }
        public bool CreateAirCrafts(List<AirCraft> airCrafts)
        {
            _context.AirCrafts.AddRange(airCrafts);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int airCraftId)
        {
            var airCraft = _context.AirCrafts.Where(x => x.Id == airCraftId).SingleOrDefault();
            if(airCraft == null)
            {
               Console.WriteLine("AirCraft not found");
               return false; 
            }
            else
            {
            _context.AirCrafts.Remove(airCraft);
            _context.SaveChanges();
            return true;
            }
        }
        public AirCraft GetById(int airCraftId)
        {
            return _context.AirCrafts.Find(airCraftId);
        }
        public AirCraft GetByCapacity(int capacity)
        {
            return _context.AirCrafts.Find(capacity);
        }
        public List<AirCraft> List()
        {
            return _context.AirCrafts.ToList();
        }
        public Flight GetByFlightNumber(int number)
        {
            return _context.Flights.Find(number);
        }
       
    }
}
