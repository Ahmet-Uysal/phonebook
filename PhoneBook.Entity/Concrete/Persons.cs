
using PhoneBook.Entity.Concrete;

namespace PhoneBook.Entity.Concrete
{
    public class Persons
    {

        public string? Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; } = null!;

        public string Company { get; set; } = null!;
        public List<CommunicationInformations> CommunicationInformation { get; set; }
    }
}
