
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cucklist.Services
{
    public class ContainerService :IContainerService
    {
        public CloudBlobContainer GetBlobContainer()
        {
        CloudStorageAccount AzureStorageAccount= new CloudStorageAccount(
            new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("cucklist" ,"VcoQXs+kmnhPoTONzfiVZLAj4RnnS2eFzSIs2yZLMIPR9NBtC9Tdi9k+ZsPwmwf7mZAXx7BK3ZW2U493A5HcxA=="),
                true);

        CloudBlobClient StorageClient = AzureStorageAccount.CreateCloudBlobClient();

        CloudBlobContainer Container = StorageClient.GetContainerReference("images");



        return Container;

        }



    }
}
