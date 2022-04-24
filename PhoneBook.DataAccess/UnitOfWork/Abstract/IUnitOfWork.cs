using PhoneBook.DataAccess.Abstract;
namespace PhoneBook.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonsRepository PersonsRepository { get; }
        ICommunityInformationRepository CommunityInformationRepository { get; }
        int Complate();

    }
}