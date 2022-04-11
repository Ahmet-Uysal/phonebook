using PhoneBook.DataAccess.DbConnection;
using PhoneBook.DataAccess.Abstract;

using PhoneBook.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.DataAccess.Concrete
{
    public class CommunicationInformationRepository : Repository<CommunicationInformations>, ICommunityInformationRepository
    {
        private readonly DbSet<CommunicationInformations> _communicationInformations;


        public PhoneBookDbContext Context { get { return _context as PhoneBookDbContext; } }
        public CommunicationInformationRepository(PhoneBookDbContext context) : base(context)
        {
            _communicationInformations = context.CommunicationInformations;
        }
        public IEnumerable<Persons> GetFirstCompany()
        {
            return null;
        }

        public async Task ChangeStatus(string Id)
        {
            var entity = await _communicationInformations.FindAsync(Id);
            entity.IsActive = entity.IsActive == 0 ? 1 : 0;
            _communicationInformations.Update(entity);
        }
    }
}

