using Microsoft.EntityFrameworkCore;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.DbConnection;
using PhoneBook.Entity.Concrete;

namespace PhoneBook.DataAccess.Concrete
{
    public class PersonsRepository : Repository<Persons>, IPersonsRepository
    {
        private readonly DbSet<Persons> _persons;

        public PhoneBookDbContext Context { get { return _context as PhoneBookDbContext; } }
        public PersonsRepository(PhoneBookDbContext context) : base(context)
        {
            _persons = context.Persons;
        }
        public IEnumerable<Persons> GetFirstCompany()
        {
            return null;
        }

        public async Task ChangePersonStatus(string Id)
        {
            var entity = await _persons.FindAsync(Id);
            entity.IsActive = entity.IsActive == 0 ? 1 : 0;
            _persons.Update(entity);

        }

        public async Task<List<Persons>> GetDetailedPersonList()
        {
            var list = await _persons.Include(x => x.CommunicationInformation).ToListAsync();
            return list;
        }
    }
}
