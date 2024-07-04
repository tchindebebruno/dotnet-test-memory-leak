using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PersonService : IPersonService
    {
        public Person CreatePersons()
        {
            Person pers = new()
            {
                Id = Guid.NewGuid(),
                Data = GenerateString('a', 10000000),
            };
            Console.WriteLine($"Person created");

            return pers;
        }

        public Person GetFirstPerson()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Data = GenerateString('a', 50000000),
            };
        }

        private string GenerateString(char c, int length)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
