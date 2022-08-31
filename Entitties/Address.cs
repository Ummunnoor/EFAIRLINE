using System;
namespace EFAIRLINE.Entities
{
    public class Address: BaseEntity
    {
        public string NumberLine { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }

    }
}