using AutoMapper;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Persons, PersonsDTO>();
    }
}