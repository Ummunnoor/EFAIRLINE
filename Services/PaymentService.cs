using EFAIRLINE.Entities;
using EFAIRLINE.DTOs;
using EFAIRLINE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAirLine.Repositories;

namespace EFAIRLINE.Services
{
    public class PaymentService
    {
        private readonly PaymentRepository _repository;

        public PaymentService(PaymentRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreatePaymentDto createPaymentDto)
        {
            var payment = new Payment()
            {
                Passenger = createPaymentDto.Passenger,
                Price = createPaymentDto.Price,
                PassengerId = createPaymentDto.PassengerId,

            };
            var response = _repository.Create(payment);
            if (response)
            {
                Console.WriteLine("Payment Created Successfully");
            }
            else
            {
                Console.WriteLine("Payment Creation Failed");
            }
        }
        public void Update(int id, UpdatePaymentDto updatePaymentDto)
        {
            var payment = _repository.GetById(id);
            if (payment == null)
            {
                Console.WriteLine("Payment not found");
            }
            else
            {
                payment.Reference = updatePaymentDto.Reference;
                payment.Price = updatePaymentDto.Price;
                var response = _repository.Update(payment);
                if (response!=null)
                {
                    Console.WriteLine("Update Succcessful");
                }
                else
                {
                    Console.WriteLine("Update Unsucccessful");
                }

            }
        }
        public void Cancel(string reference)
        {
             var payment = _repository.GetByReference(reference);
            if (payment == null)
            {
                Console.WriteLine("Payment not found");
                return;
            }
            var response = _repository.Delete(payment); 
            if (response)
            {
                Console.WriteLine("Payment cancelled successfully");
            }
            else
            {
                Console.WriteLine("Payment cancellation failed");
            }
            
        }
    }
}
