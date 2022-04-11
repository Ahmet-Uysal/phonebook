using Microsoft.AspNetCore.Mvc;
using PhoneBook.DataAccess.UnitofWork.Abstract;
using PhoneBook.Entity.Concrete;

namespace PhoneBook.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IUnitOfWork _UnitOfWork;




    public PersonController(IUnitOfWork _unitOfWork)
    {
        _UnitOfWork = _unitOfWork;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddPerson([FromBody] Persons entity)
    {
        try
        {

            await _UnitOfWork.PersonsRepository.Add(entity);
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

            await _UnitOfWork.PersonsRepository.Remove(Id);
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
            var list = await _UnitOfWork.PersonsRepository.GetAll();
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

            var list = await _UnitOfWork.PersonsRepository.GetAll();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }


}