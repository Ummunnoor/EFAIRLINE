using EFAIRLINE.Enum;
namespace EFAIRLINE.Entities
{
    public class Passenger: BaseEntity
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
        public Gender Gender { get; set; }
        public decimal Wallet { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}