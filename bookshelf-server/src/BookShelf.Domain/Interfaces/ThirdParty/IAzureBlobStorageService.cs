using BookShelf.Domain.DTO;

namespace BookShelf.Domain.Interfaces.ThirdParty;

public interface IAzureBlobStorageService
{
    public Task<AzureBlobStorageResponseModel> GetBlobAsync(string containerName, string blobName, CancellationToken token = default);
    public Task UploadBlobAsync(Stream readStream, string blobName, string containerName, CancellationToken token = default);
    public Task DeleteBlobAsync(string containerName, string blobName, CancellationToken token = default);
}
