using Report.DataAccess.Abstract;
namespace Report.DataAccess.UnitofWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IReportRepository ReportRepository { get; }
        int Complate();

    }
}