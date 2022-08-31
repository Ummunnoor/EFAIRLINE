using System;
using System.ComponentModel.DataAnnotations;

namespace EFAIRLINE.Entities
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressId { get; set; }
        public Flight Flight { get; set;}
        public Address Address { get; set; }

    }
}