
using Report.DataAccess.Abstract;
using Report.DataAccess.Concrete;
using Report.DataAccess.DbConnection;
using Report.DataAccess.UnitOfWork.Abstract;

namespace Report.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ReportDbContext _Context { get; set; }
        public IReportRepository ReportRepository { get; set; }


        public UnitOfWork()
        {
            _Context = new ReportDbContext();
            ReportRepository = new ReportRepository(_Context);
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