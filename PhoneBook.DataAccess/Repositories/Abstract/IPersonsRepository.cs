using PhoneBook.DataAccess.Abstract;
using PhoneBook.Entity.Concrete;
namespace PhoneBook.DataAccess.Abstract
{
    public interface IPersonsRepository : IRepository<Persons>
    {
        public Task ChangePersonStatus(string Id);
        public Task<List<Persons>> GetDetailedPersonList();
    }
}