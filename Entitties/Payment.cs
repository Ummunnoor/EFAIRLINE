using EFAIRLINE.Enum;
namespace EFAIRLINE.Entities
{
    public class Payment: BaseEntity
    {
        public int PassengerId { get; set; } 
        public bool IsPaid { get; set; }
        public string Reference { get; set; }
        public Passenger Passenger { get; set; }
        public decimal Price { get; set; }
        
    }
}