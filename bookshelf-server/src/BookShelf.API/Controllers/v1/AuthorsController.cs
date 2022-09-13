using BookShelf.Application.Authors.v1.Commands.CreateAuthor;
using BookShelf.Application.Authors.v1.Commands.UpdateAuthor;
using BookShelf.Application.Authors.v1.Queries.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthorsController : BaseController
{
    public AuthorsController(IMediator mediator) : base(mediator) { }

    [HttpGet("{authorId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuthorPreviewDto>> GetAuthorDetailsAsync([FromRoute] GetAuthorByIdQuery query, CancellationToken cancellationToken)
    {
        AuthorPreviewDto authorDetails = await _mediator.Send(query, cancellationToken);

        return Ok(authorDetails);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);

        return Ok();
    }
}
