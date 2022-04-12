using Microsoft.AspNetCore.Mvc;
using PhoneBook.DataAccess.UnitofWork.Abstract;
using PhoneBook.Entity.Concrete;
using PhoneBook.Entity.DTO;

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
    public async Task<IActionResult> AddCommunicationInfo([FromBody] AddCommunicationInformations entity)
    {
        await _UnitOfWork.CommunityInformationRepository.Add(new CommunicationInformations(entity));
        _UnitOfWork.Complate();
        return Ok();
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllInfo()
    {
        var list = await _UnitOfWork.CommunityInformationRepository.GetAll();
        return Ok(list);
    }
    [HttpDelete]
    [Route("[action]/{Id}")]
    public async Task<IActionResult> RemoveCommunicationInfo(string Id)
    {
        await _UnitOfWork.CommunityInformationRepository.ChangeStatus(Id);
        _UnitOfWork.Complate();
        return Ok();
    }



}