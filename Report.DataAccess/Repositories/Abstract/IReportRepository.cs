using Report.DataAccess.Abstract;
using Report.Entity.Concrete;
namespace Report.DataAccess.Abstract
{
    public interface IReportRepository : IRepository<Reports>
    {
    }
}