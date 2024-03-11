namespace AzureBlobNotif.Interfaces
{
    public interface IGmail
    {
        bool Send(string fileName, string sasUri);
    }
}
