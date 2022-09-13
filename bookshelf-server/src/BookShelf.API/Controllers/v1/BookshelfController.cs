using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class BookshelfController : BaseController
{
	public BookshelfController(IMediator mediator) : base(mediator)
	{

	}
}
