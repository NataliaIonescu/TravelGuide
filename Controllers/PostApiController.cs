using TravelGuide.Services.Interfaces;
using TravelGuide.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogPosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly ICityService _cityService;
        public PostApiController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var cityNames = await _cityService.GetCityNamesWhichContainTerm(term);
                return Ok(cityNames);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}