using PhoneBook.DataAccess.Abstract;
using PhoneBook.Entity.Concrete;
namespace PhoneBook.DataAccess.Abstract
{
    public interface ICommunityInformationRepository : IRepository<CommunicationInformations>
    {
        public Task ChangeStatus(string Id);
    }
}