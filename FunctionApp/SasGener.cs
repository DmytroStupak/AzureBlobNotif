using Azure.Storage;

namespace AzureBlobNotif
{
    public class SasGener
    {
        public static async Task<string> GetBlobSASTOkenByFile(string fileName)
        {
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
                return sasToken;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
