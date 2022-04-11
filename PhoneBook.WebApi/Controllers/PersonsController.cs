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



    public PersonController(IUnitOfWork _unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _UnitOfWork = _unitOfWork;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddPerson([FromBody] AddPerson entity)
    {
        try
        {

            await _UnitOfWork.PersonsRepository.Add(new Persons(entity));
            _UnitOfWork.Complate();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpDelete]
    [Route("[action]/{Id}")]
    public async Task<IActionResult> Remove(string Id)
    {
        try
        {

            await _UnitOfWork.PersonsRepository.ChangePersonStatus(Id);
            _UnitOfWork.Complate();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllPersons()
    {
        try
        {
            var list = _mapper.Map<List<PersonsDTO>>(await _UnitOfWork.PersonsRepository.GetAll());
            list = list.Where(x => x.IsActive == 1).ToList();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllPersonsGroupByLocation()
    {
        try
        {

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllPersonsWithCommunicationsInfo()
    {
        try
        {

            var list = await _UnitOfWork.PersonsRepository.GetDetailedPersonList();
            var mappedList = _mapper.Map<List<DetailedPersonInfoDTO>>(list);

            return Ok(mappedList);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }


}