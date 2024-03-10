using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureBlobNotif
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function1))]
        public async Task Run([BlobTrigger("files/{name}", Connection = "")] Stream stream, string name)
        {
            var myBlobUrl = $"{Const.CONTAINER_URL}{name}?";
            var sas = await SasGener.GetBlobSASTOkenByFile(name);
            var sasUri = myBlobUrl + sas;
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");

            Gmail.Send(name, sasUri);
        }
    }
}
