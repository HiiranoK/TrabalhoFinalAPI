using Microsoft.AspNetCore.Mvc;

namespace CityEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityEventsController : ControllerBase
    {
        

        [HttpGet]
        public void Get()
        {
            
        }
    }
}