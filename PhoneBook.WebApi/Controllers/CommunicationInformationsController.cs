using Microsoft.AspNetCore.Mvc;
using PhoneBook.DataAccess.UnitofWork.Abstract;
using PhoneBook.Entity.Concrete;

namespace PhoneBook.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommunicationInformationsController : ControllerBase
{
    private readonly IUnitOfWork _UnitOfWork;




    public CommunicationInformationsController(IUnitOfWork _unitOfWork)
    {
        _UnitOfWork = _unitOfWork;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddCommunicationInfo([FromBody] Persons entity)
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
    public async Task<IActionResult> RemoveCommunicationInfo(string Id)
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



}