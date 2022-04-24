using Microservices.Test.Hosts;
using Newtonsoft.Json;
using Report.DataAccess.UnitOfWork.Abstract;
using Report.DataAccess.UnitOfWork.Concrete;
using Report.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Test
{
    public class ReportControllerTest
    {
        public HttpClient Client { get; set; }
        public ReportControllerTest()
        {
            Client = new CreateTestClient<ReportProgram>().Client;
        }

        [Fact]
        public async Task GetFirstTest()
        {
            var response = await Client.GetStringAsync("/Report/GetFirst");
            var resultObject = JsonConvert.DeserializeObject<Reports>(response);
            var dataStore = new UnitOfWork().ReportRepository;
            var expected = (List<Reports>)await dataStore.GetAll();
            Assert.Equal(expected.FirstOrDefault().Id, resultObject.Id);

        }
        [Fact]
        public async Task GetAllReportsTest()
        {
            
            var response = await Client.GetStringAsync("/Report/GetAllReports");
            var resultObject = JsonConvert.DeserializeObject<List<Reports>>(response);
            var dataStore = new UnitOfWork().ReportRepository;
            var expected = (List<Reports>)await dataStore.GetAll();
            Assert.Equal(expected.Count, resultObject.Count);
        }
    }
}
