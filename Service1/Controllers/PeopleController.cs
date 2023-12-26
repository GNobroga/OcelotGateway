using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Service1.Controllers
{   
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {   
        [HttpGet]
        public ActionResult<object> Get()
        {
            return new List<object>() 
            {
                new { Name = "Gabriel Cardoso", Age = 21, Number = "12345" },
                new { Name = "José Carlos", Age = 22, Number = "14725" }
            };
        }
    }
}

