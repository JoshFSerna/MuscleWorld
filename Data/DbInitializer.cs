using MuscleWorld.Models;

namespace MuscleWorld.Data
{
    public class DbInitializer
    {
        public static void Initialize(MuscleWorldContext context)
        {
            if (context.Member.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
                new Member {FirstName = "John", LastName = "Doe", age = 37, MembershipExpiration = DateTime.Parse("2023-01-01")},
                new Member {FirstName = "Jane", LastName = "Doe", age = 36, MembershipExpiration = DateTime.Parse("2023-01-01")},
                new Member {FirstName = "Griffin", LastName = "Kennedy", age = 21, MembershipExpiration = DateTime.Parse("2022-05-06")},
                new Member {FirstName = "Jake", LastName = "Whitecar", age = 22, MembershipExpiration = DateTime.Parse("2022-06-14")},
                new Member {FirstName = "Mackenzie", LastName = "Frato", age = 21, MembershipExpiration = DateTime.Parse("2023-02-01")},
                new Member {FirstName = "Kit", LastName = "Hattington", age = 51, MembershipExpiration = DateTime.Parse("2022-12-09")},
                new Member {FirstName = "Johnny", LastName = "Johnson", age = 49, MembershipExpiration = DateTime.Parse("2023-01-07")},
                new Member {FirstName = "Sue", LastName = "Susans", age = 42, MembershipExpiration = DateTime.Parse("2022-04-02")},
                new Member {FirstName = "Elton", LastName = "John", age = 79, MembershipExpiration = DateTime.Parse("2023-02-17")},
            };

            context.Member.AddRange(members);
            context.SaveChanges();
        }
    }
}
