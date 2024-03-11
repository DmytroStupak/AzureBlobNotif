using AzureBlobNotif.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureBlobNotif
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IGmail _gmail;
        private readonly IUriSasGener _uriSasGener;

        public Function1(ILogger<Function1> logger, IGmail gmail, IUriSasGener uriSasGener)
        {
            _logger = logger;
            _gmail = gmail;
            _uriSasGener = uriSasGener;
        }

        [Function(nameof(Function1))]
        public async Task Run([BlobTrigger("files/{name}", Connection = "")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
            
            _gmail.Send(name, _uriSasGener.GetBlobSASTOkenByFile(name));

        }
    }
}
