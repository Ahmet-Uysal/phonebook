using Report.DataAccess.DbConnection;
using Report.DataAccess.Abstract;
using Report.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Report.DataAccess.Concrete
{
    public class ReportRepository : Repository<Reports>, IReportRepository
    {
        private readonly DbSet<Reports> _reports;


        public ReportDbContext Context { get { return _context as ReportDbContext; } }
        public ReportRepository(ReportDbContext context) : base(context)
        {
            _reports = context.Reports;
        }

    }
}