using Azure.Storage.Blobs;
using BookShelf.Domain.DTO;

namespace BookShelf.Infrastructure.ThirdParty
{
    public class ProfileBlobStorageService : AzureBlobStorageService
    {
        private readonly string _containerName;

        public ProfileBlobStorageService(
            BlobServiceClient blobServiceClient, 
            string containerName
        ) : base(blobServiceClient)
        {
            _containerName = containerName;
        }

        public async Task DeleteBlobAsync(string blobName, CancellationToken cancellationToken = default)
        {
            await base.DeleteBlobAsync(_containerName, blobName, cancellationToken);
        }

        public Task<AzureBlobStorageResponseModel> GetBlobAsync(string blobName, CancellationToken cancellationToken = default)
        {
            return base.GetBlobAsync(_containerName, blobName, cancellationToken);
        }

        public Task UploadBlobAsync(Stream readStream, string blobName, CancellationToken cancellationToken = default)
        {
            return base.UploadBlobAsync(readStream, blobName, _containerName, cancellationToken);
        }
    }
}
