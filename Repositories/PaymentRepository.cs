using EFAIRLINE.Context;
using EFAIRLINE.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFAirLine.Repositories
{
    public class PaymentRepository
    {
        private readonly EFAIRLINEDbContext _context;
        public PaymentRepository(EFAIRLINEDbContext efairlinedbcontext)
        {
            efairlinedbcontext = _context;
        }
        public bool Create(Payment payment)
        {
            if (payment == null)
            {
                return false;
            }
            else
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return true;
            }
        }
        public Payment Update(Payment updatedPayment)
        {
              _context.Update(updatedPayment);
              _context.SaveChanges();
              return updatedPayment;

        }
        public List<Payment> List()
        {
            return _context.Payments.ToList();
        }
        public Payment GetById(int id)
        {
            return _context.Payments
            .Include(p => p.Passenger)
            .SingleOrDefault(p => p.Id == id);
        }
         public Payment GetByReference(string reference)
        {
            return _context.Payments
            .Include(p => p.Passenger)
            .SingleOrDefault(p => p.Reference == reference);
        }
        public List<Payment> GetByPaymentStatus(bool status)
        {
            return _context.Payments
                .Include(p => p.Passenger)
                .Where(p => p.IsPaid == status).ToList();
        }
        public bool Delete(Payment reference)
        {
               _context.Payments.Remove(reference);
               _context.SaveChanges();
               return true;
            
        }
        public bool ChangePaymentStatus(string paymentRef, bool status)
        {
            var payment = GetByReference(paymentRef);
            if (payment == null)
            {
                Console.WriteLine("Payment not found");
                return false;
            }
            else
            {
                payment.IsPaid = status;
                _context.Payments.Update(payment);
                _context.SaveChanges();
                return true;
            }
        }  

    }
}
