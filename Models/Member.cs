using System.ComponentModel.DataAnnotations;

namespace MuscleWorld.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
        [DataType(DataType.Date)]
        public DateTime MembershipExpiration { get; set; }
    }
}
