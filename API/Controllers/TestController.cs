using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : Controller
{
    // GET
    [HttpGet]
    [Route("Sync")]
    public IActionResult GetSync()
    {
        Thread.Sleep(1000);
        return Ok();
    }
    
    [HttpGet]
    [Route("Async")]
    public async Task<IActionResult> GetASync()
    {
        await Task.Delay(1000);
        return Ok();
    }
}