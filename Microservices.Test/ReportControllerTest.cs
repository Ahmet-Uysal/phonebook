using Newtonsoft.Json;
using Report.DataAccess.UnitofWork.Abstract;
using Report.DataAccess.UnitOfWork.Concrete;
using Report.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Test
{
    public class ReportControllerTest
    {
        [Fact]
        public async Task GetFirstTest()
        {
            var application = new ReportTestHost();
            var client = application.CreateClient();
            var response = await client.GetStringAsync("/Report/GetFirst");
            var resultObject = JsonConvert.DeserializeObject<Reports>(response);
            IUnitOfWork a = new UnitOfWork();
            var expected = (List<Reports>)await a.ReportRepository.GetAll();
            Assert.Equal(expected.FirstOrDefault().Id, resultObject.Id);

        }
        [Fact]
        public async Task GetAllReportsTest()
        {
            var application = new ReportTestHost();
            var client = application.CreateClient();
            var response = await client.GetStringAsync("/Report/GetAllReports");
            var resultObject = JsonConvert.DeserializeObject<List<Reports>>(response);
            IUnitOfWork a = new UnitOfWork();
            var expected = (List<Reports>)await a.ReportRepository.GetAll();
            Assert.Equal(expected.Count, resultObject.Count);
        }
    }
}
