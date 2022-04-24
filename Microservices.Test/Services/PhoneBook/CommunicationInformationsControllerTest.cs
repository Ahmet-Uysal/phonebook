using PhoneBook.DataAccess.UnitOfWork.Concrete;
using Newtonsoft.Json;
using PhoneBook.DataAccess.UnitOfWork.Abstract;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microservices.Test.Hosts;

namespace Microservices.Test
{
    public class CommunicationInformationsControllerTest
    {
        public HttpClient Client { get; set; }
        public CommunicationInformationsControllerTest()
        {
            Client = new CreateTestClient<PhoneBookProgram>().Client;
        }

        [Fact]
        public async Task AddCommunicationInfoTest()
        {
            var person = new AddCommunicationInformations("Email", "Ahmet@ahmet.com", "7478eb91-da9e-47db-9de5-59dcd777f6a3");
            var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/CommunicationInformations/AddCommunicationInfo", content);
            Assert.Equal(true, response.IsSuccessStatusCode);
        }
        [Fact]
        public async Task GetAllInfoTest()
        {
            var response = await Client.GetStringAsync("/CommunicationInformations/GetAllInfo");
            var resultObject = JsonConvert.DeserializeObject<List<CommunicationInformations>>(response);
            var dataStore = new UnitOfWork().CommunityInformationRepository;
            var expected = (List<CommunicationInformations>)await dataStore.GetAll();
            Assert.Equal(expected.Count, resultObject.Count);
        }
    }
}
