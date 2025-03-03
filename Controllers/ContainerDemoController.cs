using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace AzureStorageServiceDemo.Controllers
{
    public class ContainerDemoController : Controller
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ContainerDemoController(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        // This returns the list of containers in storage account
        [Route("container/getcontainers")]
        [HttpGet]
        public List<string> GetContainers()
        {
            var containersList = _blobServiceClient.GetBlobContainers();
            var containersNameList = containersList.Select(x => x.Name).ToList();
            return containersNameList;
        }

        // Create new container
        [Route("container/createcontainer")]
        [HttpGet]
        public List<string> CreateContainer()
        {
            var newContainer = "mythirdcontainer";
            _blobServiceClient.CreateBlobContainer(newContainer);

            var containersList = _blobServiceClient.GetBlobContainers();
            var containersNameList = containersList.Select(x => x.Name).ToList();
            return containersNameList;
        }
        
    }
}
