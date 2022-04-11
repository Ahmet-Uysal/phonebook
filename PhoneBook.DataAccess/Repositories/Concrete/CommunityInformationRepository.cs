using PhoneBook.DataAccess.DbConnection;
using PhoneBook.DataAccess.Abstract;

using PhoneBook.Entity.Concrete;

namespace PhoneBook.DataAccess.Concrete
{
    public class CommunicationInformationRepository : Repository<CommunicationInformations>, ICommunityInformationRepository
    {


        public PhoneBookDbContext Context { get { return _context as PhoneBookDbContext; } }
        public CommunicationInformationRepository(PhoneBookDbContext context) : base(context)
        {

        }
        public IEnumerable<Persons> GetFirstCompany()
        {
            return null;
        }

    }
}

