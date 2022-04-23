using PhoneBook.Entity.DTO;

namespace PhoneBook.Entity.Concrete
{

    public class CommunicationInformations
    {
        public CommunicationInformations()
        {

        }
        public CommunicationInformations(AddCommunicationInformations entity)
        {
            this.Id = null;
            this.PersonsId = entity.PersonsId;
            this.Type = entity.Type;
            this.Context = entity.Context;
            this.IsActive = 1;
        }
        public string? Id { get; set; }
        public string Type { get; set; }
        public string Context { get; set; }
        public int IsActive { get; set; } = 1;
        public string PersonsId { get; set; }
        public Persons Persons { get; set; }
    }
}
