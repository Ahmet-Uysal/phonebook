using PhoneBook.DataAccess.Abstract;
namespace PhoneBook.DataAccess.UnitofWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonsRepository PersonsRepository { get; }
        ICommunityInformationRepository CommunityInformationRepository { get; }
        int Complate();

    }
}