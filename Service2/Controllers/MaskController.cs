using Microsoft.AspNetCore.Mvc;
using Service2.ObjectValues;
using Service2.Services;

namespace Service2.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MaskController : ControllerBase
{

    private readonly IPeopleService _service;

    public MaskController(IPeopleService service)
    {
        _service = service;
    }

    public ActionResult<IEnumerable<PeopleVO>> Index()
    {

        return Ok(_service.FindAll());
    }
}