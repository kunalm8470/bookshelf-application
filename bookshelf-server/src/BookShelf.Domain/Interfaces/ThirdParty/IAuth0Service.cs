using BookShelf.Domain.DTO;

namespace BookShelf.Domain.Interfaces.ThirdParty;

public interface IAuth0Service
{
    public Task<Auth0SignupResponseModel> SignupUserAsync(Auth0SignupModel signupRequest, CancellationToken cancellationToken = default);
    Task<string> TriggerResetPasswordAsync(Auth0ChangePasswordModel changePasswordModel, CancellationToken cancellationToken = default);
}
