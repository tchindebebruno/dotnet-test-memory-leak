using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPersonService
    {
        public Person CreatePersons();
        public Person GetFirstPerson();
    }
}
