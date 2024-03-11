namespace AzureBlobNotif.Interfaces
{
    public interface IUriSasGener
    {
        string GetBlobSASTOkenByFile(string fileName);
    }
}
