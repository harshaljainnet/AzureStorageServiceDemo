using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace AzureStorageServiceDemo.Controllers
{
    public class BlobDemoController : Controller
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobDemoController(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [Route("blob/getblobs")]
        [HttpGet]
        public List<string> GetBlobs()
        {
            var container = "mycontainer";
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
            var blobList = blobContainerClient.GetBlobs();
            var blobsNameList = blobList.Select(x => x.Name).ToList();
            return blobsNameList;
        }

        [Route("blob/deleteblob")]
        [HttpGet]
        public List<string> DeleteBlob()
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("mycontainer");
            var blobClient = blobContainerClient.GetBlobClient("Car_2.jpg");
            blobClient.DeleteIfExists();

            var blobsList = blobContainerClient.GetBlobs();
            var blobsNameList = blobsList.Select(x => x.Name).ToList();
            return blobsNameList;
        }
    }
}
