
using Microsoft.WindowsAzure.Storage.Blob;

namespace Cucklist.Services
{
    public interface IContainerService
    {



        CloudBlobContainer GetBlobContainer();
    }
}