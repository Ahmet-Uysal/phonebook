using Microsoft.AspNetCore.Mvc;

namespace Report.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{




    public ReportController()
    {
    }


    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> CreateReport()
    {
        try
        {

            return Ok("ahmet");
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }




}