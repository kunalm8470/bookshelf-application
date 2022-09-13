using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class AccountsController : BaseController
{
    public AccountsController(IMediator mediator) : base(mediator)
    {

    }

    [HttpPost("Register")]
    public IActionResult RegisterUser()
    {
        return Ok();
    }

    [HttpPost("ResetPassword")]
    public IActionResult ResetPassword()
    {
        return Ok();
    }
}
