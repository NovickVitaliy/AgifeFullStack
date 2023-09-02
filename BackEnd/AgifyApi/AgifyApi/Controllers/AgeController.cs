using System.Net.Mime;
using AgifyApi.Filters;
using AgifyApi.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace AgifyApi.Controllers;

[TypeFilter(typeof(CORSResourceFilter))]
[Route("[controller]")]
public class AgeController : Controller
{
    private readonly IAgeService _ageService;

    public AgeController(IAgeService ageService)
    {
        _ageService = ageService;
    }
    
    [Route("[action]/{name?}")]
    public async Task<IActionResult> Index(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return StatusCode(StatusCodes.Status400BadRequest, new ContentResult()
            {
                Content = "<h1>Loh</h1>",
                ContentType = "text/html",
                StatusCode = 400
            });
        }

        var data = await _ageService.GetAge(name);
        
        return Json(data);
    }
}