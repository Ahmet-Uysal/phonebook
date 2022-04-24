using AutoMapper;
using PhoneBook.DataAccess.UnitOfWork.Concrete;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PhoneBook.DataAccess.UnitOfWork.Abstract;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;
using PhoneBook.WebApi.Controllers;
using Report.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microservices.Test.Hosts;

namespace Microservices.Test
{
    public class PersonsControllerTest
    {
        public HttpClient Client { get; set; }
        public PersonsControllerTest()
        {
            Client = new CreateTestClient<PhoneBookProgram>().Client;
        }


        [Fact]
        public async Task GetAllPersonsTest()
        {
            var response = await Client.GetStringAsync("/Person/GetAllPersons") ;
            var resultObject = JsonConvert.DeserializeObject<List<Persons>>(response);
            var dataStore = new UnitOfWork().PersonsRepository;
            var expected = (List<Persons>)await dataStore.GetAll();
            Assert.Equal(expected.Count, resultObject.Count);
        }
        [Fact]
        public async Task AddPersonTest()
        {
            var person = new AddPerson( "ayse","havelsan","dinç");
            var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("/Person/addPerson",content);
            Assert.Equal(true,response.IsSuccessStatusCode);

        }
      
        [Fact]
        public async Task GetAllPersonsWithCommunicationsInfoTest()
        {
            var response = await Client.GetStringAsync("/Person/GetAllPersonsWithCommunicationsInfo");
            var resultObject = JsonConvert.DeserializeObject<List<Persons>>(response);
            var dataStore = new UnitOfWork().PersonsRepository;
            var expected = (List<Persons>)await dataStore.GetDetailedPersonList();
            Assert.Equal(expected.Count, resultObject.Count);
        }
        [Fact]
        public async Task GetFirstReportsTest()
        {
            //iki microservis kendi aralarında haberleşme yaptıkları için bunu test edebilmek için
            //ikisininde açık olması lazım tek bir tanesi için test yapılırken sıkıntı yok url bağımlılığı
            //yok ama  birbirleri ile haberleşen servisler için  birbirlerinin url lerini bilmeleri gerekiyor 
            //bunun testini etmek için test ortamının dışına çıkmadan  nasıl yapabilirim diye araştırdım aynı
            //anda url vererek başlatma işini çözemedim eğer wele ile başlatırsak bu test case de başarıyla geçecek
            
            var response = await Client.GetStringAsync("/Person/GetFirstReports");
            var resultObject = JsonConvert.DeserializeObject<Reports>(response);
            var dataStore = new Report.DataAccess.UnitOfWork.Concrete.UnitOfWork().ReportRepository;
            var expected = (List<Reports>)await dataStore.GetAll();
            Assert.Equal(expected.FirstOrDefault().Id, resultObject.Id);
        }
        [Fact]
        public async Task GetReportTest()
        {

            var response = await Client.GetAsync("/Person/GetReport");
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
   
}