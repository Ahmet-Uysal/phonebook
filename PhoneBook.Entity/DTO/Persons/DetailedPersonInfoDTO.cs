using PhoneBook.Entity.DTO;

public class DetailedPersonInfoDTO
{

    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Company { get; set; }
    public List<CommunicationInformationsDTO> CommunicationInformation { get; set; }
}