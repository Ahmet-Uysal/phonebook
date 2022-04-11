
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete;
using PhoneBook.DataAccess.DbConnection;
using PhoneBook.DataAccess.UnitofWork.Abstract;

namespace DeliveryBackend.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private PhoneBookDbContext _Context { get; set; }
        public IPersonsRepository PersonsRepository { get; set; }

        public ICommunityInformationRepository CommunityInformationRepository { get; set; }
        public UnitOfWork()
        {
            _Context = new PhoneBookDbContext();
            PersonsRepository = new PersonsRepository(_Context);
            CommunityInformationRepository = new CommunicationInformationRepository(_Context);
        }
        public int Complate()
        {
            return _Context.SaveChanges();
        }
        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}