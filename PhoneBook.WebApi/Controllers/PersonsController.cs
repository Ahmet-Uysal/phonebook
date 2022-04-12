using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.DataAccess.UnitofWork.Abstract;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;

namespace PhoneBook.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;



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
        list = list.Where(x => x.IsActive == 1).ToList();
        return Ok(list);

    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetReport()
    {

        var httpClient = _httpClientFactory.CreateClient("Report");
        var httpResponseMessage = await httpClient.GetAsync(
            "report/CreateReports");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
        }
        return Ok();

    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllPersonsWithCommunicationsInfo()
    {
        var list = await _UnitOfWork.PersonsRepository.GetDetailedPersonList();
        var mappedList = _mapper.Map<List<DetailedPersonInfoDTO>>(list);
        return Ok(mappedList);
    }


}