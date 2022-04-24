using Microsoft.AspNetCore.Mvc;
using Report.DataAccess.UnitOfWork.Abstract;

namespace Report.WebApi.Controllers;

[ApiController]
[Route("/[controller]")]
public class ReportController : ControllerBase
{

    private readonly IUnitOfWork _UnitOfWork;


    public ReportController(IUnitOfWork UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }


    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllReports()
    {
        try
        {
            var list = await _UnitOfWork.ReportRepository.GetAll();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetFirst()
    {
        try
        {
            var list = await _UnitOfWork.ReportRepository.GetAll();
            return Ok(list.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }




}