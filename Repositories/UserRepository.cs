using EFAIRLINE.Context;
using EFAIRLINE.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFAirLine.Repositories
{
    public class UserRepository
    {
        private readonly EFAIRLINEDbContext _context;
        public UserRepository(EFAIRLINEDbContext efairlinedbcontext)
        {
            efairlinedbcontext = _context;
        }
        public bool Create(User user)
        {
            if(user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
        }
        
        public bool Update(User updatedUser)
        {
            _context.Users.Update(updatedUser);
                _context.SaveChanges();
                return true;
        }
       
        public List<User> List()
        {
            return _context.Users
            .Include(c => c.Address)
            .ToList();
        }
        public User GetById(int UserId)
        {
            return _context.Users
            .Include(u => u.Address)
            .Where(u => u.Id == UserId).SingleOrDefault();
        }
         public User GetByEmail(string email)
        {
            return _context.Users
            .Include(u => u.Address)
            .Where(u => u.Email == email).FirstOrDefault();
        }
        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

    } 
}
