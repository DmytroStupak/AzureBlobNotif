using Azure.Storage;
using AzureBlobNotif.Interfaces;

namespace AzureBlobNotif
{
    public class UriSasGener : IUriSasGener
    {
        public string GetBlobSASTOkenByFile(string fileName)
        {
            var myBlobUrl = $"{Const.CONTAINER_URL}{fileName}?";

            try
            {
                var azureStorageAccount = Const.STORAGE_ACCOUNT;
                var azureStorageAccessKey = Const.KEY;
                Azure.Storage.Sas.BlobSasBuilder blobSasBuilder = new Azure.Storage.Sas.BlobSasBuilder()
                {
                    BlobContainerName = Const.CONTAINER,
                    BlobName = fileName,
                    ExpiresOn = DateTime.UtcNow.AddHours(1),
                };
                blobSasBuilder.SetPermissions(Azure.Storage.Sas.BlobSasPermissions.Read);
                var sasToken = blobSasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(azureStorageAccount,
                    azureStorageAccessKey)).ToString();
                
                var sasUri = myBlobUrl + sasToken;
                
                return  sasUri;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
