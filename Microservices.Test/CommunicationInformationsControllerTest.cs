using DeliveryBackend.DataAccess.UnitOfWork.Concrete;
using Newtonsoft.Json;
using PhoneBook.DataAccess.UnitofWork.Abstract;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microservices.Test
{
    public class CommunicationInformationsControllerTest
    {
        [Fact]
        public async Task AddCommunicationInfoTest()
        {
            var person = new AddCommunicationInformations("Email", "Ahmet@ahmet.com", "7478eb91-da9e-47db-9de5-59dcd777f6a3");
            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/CommunicationInformations/AddCommunicationInfo", content);

            Assert.Equal(true, response.IsSuccessStatusCode);
        }
        [Fact]
        public async Task GetAllInfoTest()
        {
            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var response = await client.GetStringAsync("/CommunicationInformations/GetAllInfo");
            var resultObject = JsonConvert.DeserializeObject<List<CommunicationInformations>>(response);
            IUnitOfWork a = new UnitOfWork();
            var expected = (List<CommunicationInformations>)await a.CommunityInformationRepository.GetAll();
            Assert.Equal(expected.Count, resultObject.Count);
        }
    }
}
