
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;

namespace PhoneBook.Entity.Concrete
{
    public class Persons
    {
        public Persons()
        {

        }
        public Persons(AddPerson entity)
        {
            this.Name = entity.Name;
            this.Company = entity.Company;
            this.Surname = entity.Surname;
            this.CommunicationInformation = new List<CommunicationInformations>();
            this.IsActive = 1;
            this.Id = null;
        }

        public string? Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }
        public int IsActive { get; set; } = 1;
        public List<CommunicationInformations> CommunicationInformation { get; set; }
    }
}
