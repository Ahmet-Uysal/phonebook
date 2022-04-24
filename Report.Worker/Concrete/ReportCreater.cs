using Report.DataAccess.UnitOfWork.Concrete;
using Report.DataAccess.DbConnection;
using Report.DataAccess.UnitofWork.Abstract;
using Report.Entity.Concrete;
using Report.Worker.Abstract;

namespace Report.Worker.Concrete
{
    public class ReportCreater : IReportCreater
    {
        private readonly IUnitOfWork _unitofWork = new UnitOfWork();
        public void CreateReport()
        {
            var report = new Reports { Id = null, Path = "-", ReportDate = DateTime.Now.ToString(), ReportState = "Getting Ready" };
            _unitofWork.ReportRepository.Add(report);
            _unitofWork.Complate();
            Thread.Sleep(5000);
            report.ReportState = "Ready";
            report.Path = "home";
            _unitofWork.ReportRepository.Update(report);
            _unitofWork.Complate();
        }

    }
}