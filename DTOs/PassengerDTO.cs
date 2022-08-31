 using EFAIRLINE.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAIRLINE.DTOs
{
    public class CreatePassengerDto
    {
        public CreateUserDto User { get; set; }
        public bool isActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    public class UpdatePassengerDto
    {
        public UpdateUserDto User { get; set; }
        public string NextOfKin { get; set; }
        public decimal Wallet { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
    }
    public class GetPassengerDto
    {
        public GetUserDto User { get; set; }
        public bool IsActive { get; set; }
        public decimal Wallet { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
