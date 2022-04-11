using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.DbConnection;
using PhoneBook.Entity.Concrete;

namespace PhoneBook.DataAccess.Concrete
{
    public class PersonsRepository : Repository<Persons>, IPersonsRepository
    {


        public PhoneBookDbContext Context { get { return _context as PhoneBookDbContext; } }
        public PersonsRepository(PhoneBookDbContext context) : base(context)
        {

        }
        public IEnumerable<Persons> GetFirstCompany()
        {
            return null;
        }

    }
}
