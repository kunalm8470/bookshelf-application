using BookShelf.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Domain.Interfaces.ThirdParty;

public interface IAuth0ManagementAPIService
{
    public Task<Auth0ManagementAPITokenResponseModel> FetchManagementAPIAccessTokenAsync(Auth0ManagementAPITokenModel accessTokenRequest, CancellationToken cancellationToken = default);
}
