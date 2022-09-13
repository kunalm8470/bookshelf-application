using BookShelf.Domain.Interfaces.CrossCutting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BookShelf.Infrastructure.CrossCutting;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
}
