namespace BookShelf.Domain.DTO
{
    public class AzureBlobStorageResponseModel
    {
        public byte[] FileContents { get; set; }
        public string ContentType { get; set; }
    }
}
