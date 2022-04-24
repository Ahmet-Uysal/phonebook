﻿using AutoMapper;
using DeliveryBackend.DataAccess.UnitOfWork.Concrete;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PhoneBook.DataAccess.UnitofWork.Abstract;
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

namespace Microservices.Test
{
    public class PersonsControllerTest
    {
        [Fact]
        public async Task GetAllPersonsTest()
        {
          
            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var response = await client.GetStringAsync("/Person/GetAllPersons") ;
            var resultObject = JsonConvert.DeserializeObject<List<Persons>>(response);
            IUnitOfWork a = new UnitOfWork();
            var expected = (List<Persons>)await a.PersonsRepository.GetAll();
            Assert.Equal(expected.Count, resultObject.Count);

        }
        [Fact]
        public async Task AddPersonTest()
        {
            var person = new AddPerson( "ayse","havelsan","dinç");
            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Person/addPerson",content);
          
            Assert.Equal(true,response.IsSuccessStatusCode);

        }
      
        [Fact]
        public async Task GetAllPersonsWithCommunicationsInfoTest()
        {
            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var response = await client.GetStringAsync("/Person/GetAllPersonsWithCommunicationsInfo");
            var resultObject = JsonConvert.DeserializeObject<List<Persons>>(response);
            IUnitOfWork a = new UnitOfWork();
            var expected = (List<Persons>)await a.PersonsRepository.GetDetailedPersonList();
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
            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var response = await client.GetStringAsync("/Person/GetFirstReports");
            var resultObject = JsonConvert.DeserializeObject<Reports>(response);
            Report.DataAccess.UnitofWork.Abstract.IUnitOfWork a = new Report.DataAccess.UnitOfWork.Concrete.UnitOfWork();
            var expected = (List<Reports>)await a.ReportRepository.GetAll();

            Assert.Equal(expected.FirstOrDefault().Id, resultObject.Id);
        }
        [Fact]
        public async Task GetReportTest()
        {

            var application = new PhoneBookTestHost();
            var client = application.CreateClient();
            var response = await client.GetAsync("/Person/GetReport");
            //var resultObject = JsonConvert.DeserializeObject<List<Persons>>(response);
            //IUnitOfWork a = new UnitOfWork();
            //var expected = (List<Persons>)await a.PersonsRepository.GetAll();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        }
    }
   
}