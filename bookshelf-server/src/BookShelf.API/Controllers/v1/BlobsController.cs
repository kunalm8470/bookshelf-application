using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlobsController : BaseController
    {
        public BlobsController(IMediator mediator) : base(mediator)
        {
                
        }
    }
}
