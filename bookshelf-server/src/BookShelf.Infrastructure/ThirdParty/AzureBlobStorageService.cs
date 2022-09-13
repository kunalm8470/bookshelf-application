using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BookShelf.Domain.DTO;
using BookShelf.Domain.Exceptions;
using BookShelf.Domain.Extensions;
using BookShelf.Domain.Interfaces.ThirdParty;

namespace BookShelf.Infrastructure.ThirdParty
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public virtual async Task<AzureBlobStorageResponseModel> GetBlobAsync(string containerName, string blobName, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            if (!await blobClient.ExistsAsync(cancellationToken))
            {
                throw new ItemNotFoundException("Blob doesn't exist!");
            }

            BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync(cancellationToken: cancellationToken);

            return new AzureBlobStorageResponseModel
            {
                FileContents = downloadResult.Content.ToArray(),
                ContentType = downloadResult.Details.ContentType
            };
        }

        public virtual async Task UploadBlobAsync(Stream readStream, string blobName, string containerName, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            // Get the in memory reference to blobClient
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.UploadAsync(readStream, new BlobHttpHeaders
            {
                ContentType = blobName.GetContentType()
            }, cancellationToken: cancellationToken);
        }

        public virtual async Task DeleteBlobAsync(string containerName, string blobName, CancellationToken cancellationToken = default)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            if (!await blobClient.ExistsAsync(cancellationToken: cancellationToken))
            {
                throw new ItemNotFoundException("Blob doesn't exist!");
            }

            await blobClient.DeleteAsync(cancellationToken: cancellationToken);
        }
    }
}
