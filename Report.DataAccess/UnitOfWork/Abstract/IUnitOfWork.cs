using Report.DataAccess.Abstract;
namespace Report.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IReportRepository ReportRepository { get; }
        int Complate();

    }
}