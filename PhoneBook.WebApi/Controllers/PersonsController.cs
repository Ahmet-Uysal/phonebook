using System.Collections.Generic;
using AutoMapper;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.DataAccess.UnitofWork.Abstract;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;

namespace PhoneBook.WebApi.Controllers;

[ApiController]
[Route("/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ProducerConfig config = new ProducerConfig
    { BootstrapServers = "localhost:9092" };
    private readonly string topic = "simpletalk_topic";


    public PersonController(IUnitOfWork _unitOfWork, IMapper mapper, IHttpClientFactory httpClientFactory)
    {
        _mapper = mapper;
        _UnitOfWork = _unitOfWork;
        _httpClientFactory = httpClientFactory;
    }
   

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddPerson([FromBody] AddPerson entity)
    {


        await _UnitOfWork.PersonsRepository.Add(new Persons(entity));
        _UnitOfWork.Complate();
        return Ok();

    }
    [HttpDelete]
    [Route("[action]/{Id}")]
    public async Task<IActionResult> Remove(string Id)
    {


        await _UnitOfWork.PersonsRepository.ChangePersonStatus(Id);
        _UnitOfWork.Complate();
        return Ok();

    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllPersons()
    {

        var list = _mapper.Map<List<PersonsDTO>>(await _UnitOfWork.PersonsRepository.GetAll());
       // var list = await _UnitOfWork.PersonsRepository.GetAll();
        list = list.Where(x => x.IsActive == 1).ToList();
        return Ok(list);

    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetReport()
    {

        return Created(string.Empty, SendToKafka(topic, "CreateReport"));

    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllPersonsWithCommunicationsInfo()
    {
        var list = await _UnitOfWork.PersonsRepository.GetDetailedPersonList();
        var mappedList = _mapper.Map<List<DetailedPersonInfoDTO>>(list);
        return Ok(mappedList);
    }
    private Object SendToKafka(string topic, string message)
    {
        using (var producer =
             new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception e)
            {
            }
        }
        return null;
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetFirstReports()
    {
        var httpClient = _httpClientFactory.CreateClient("Report");
        var httpResponseMessage = await httpClient.GetAsync(
            "report/getfirst");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = httpResponseMessage.Content.ReadAsStringAsync();
            return Ok(contentStream.Result);
        }
        return BadRequest();

    }

}