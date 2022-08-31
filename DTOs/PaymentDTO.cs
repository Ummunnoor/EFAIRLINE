using EFAIRLINE.Entities;
using EFAIRLINE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAIRLINE.DTOs
{
    public class CreatePaymentDto
    {
        public GetUserDto User { get; set; }
        public Passenger Passenger { get; set; }
        public decimal Price { get; set; }
        public int PassengerId { get; set; }
        
    }
    public class UpdatePaymentDto
    {
        public int PassengerId { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public string Reference { get; set; }
    }
    public class GetPaymentDto
    {
        public GetUserDto User { get; set; }
        public string Reference { get; set; }

        public int PassengerId { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
    }


}