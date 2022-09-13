using BookShelf.Domain.Constants;
using BookShelf.Domain.DTO;
using BookShelf.Domain.Interfaces.ThirdParty;
using System.Net.Http.Json;
using System.Text.Json;

namespace BookShelf.Infrastructure.ThirdParty
{
    public class Auth0ManagementAPIService : IAuth0ManagementAPIService
    {
        private readonly HttpClient _httpClient;

        public Auth0ManagementAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Auth0ManagementAPITokenResponseModel> FetchManagementAPIAccessTokenAsync(Auth0ManagementAPITokenModel accessTokenRequest, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Auth0ManagementAPITokenModel>(Auth0ManagementAPIConstants.TokenEndpoint, accessTokenRequest, cancellationToken);

            response.EnsureSuccessStatusCode();

            Stream contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);

            Auth0ManagementAPITokenResponseModel accessTokenResponse = await JsonSerializer.DeserializeAsync<Auth0ManagementAPITokenResponseModel>(contentStream, cancellationToken: cancellationToken);

            return accessTokenResponse;
        }
    }
}
