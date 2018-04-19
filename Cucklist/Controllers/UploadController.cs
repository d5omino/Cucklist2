using Cucklist.Data;
using Cucklist.Models;
using Cucklist.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Cucklist.Controllers
{
    public class UploadController : Controller
    {
        //Properties and Fields//
        public IContainerService ContainerService;
        public CloudBlobContainer Container;
        public ApplicationDbContext _context;
        public UserManager<ApplicationUser> _usermanager;
        public IHttpContextAccessor _httpcontext { get; set; }

        //Constructors//
        public UploadController(IContainerService containerservice, ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            ContainerService = containerservice;
            Container = ContainerService.GetBlobContainer();
            _context = context;
            _usermanager = usermanager;

        }

        //Methods//
        //task based method that takes care of the physical upload of filies and images into an azure based storage account using blobs for each image. returns a list of cloudblockblobs that were added with this transaction//
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            foreach (IFormFile file in files)
            {
                FileInfo fileinfo = new FileInfo(file.FileName);
                CloudBlockBlob blob = Container.GetBlockBlobReference(fileinfo.Name);
                Stream filestream = file.OpenReadStream();
                Uri blobUri = blob.Uri;
                using (filestream)
                {
                    await blob.UploadFromStreamAsync(filestream);
                    await CreateFileRecord(blob);
                }
            };
            var returnurl = Request.Headers["Referer"];

                return Redirect(returnurl);
        }
        //creates database record of image with link//
        public async Task CreateFileRecord(CloudBlockBlob blob)
        {
            var Owner = await _usermanager.GetUserAsync(User);
            string path = blob.Uri.ToString();
            if (path.EndsWith(".mpg") || path.EndsWith(".avi") || path.EndsWith(".mp4"))
            {
                Video video = new Video(path);
                video.ApplicationUser = Owner;
                video.ApplicationUserId = Owner.Id;
                _context.Add(video);
            }
            if (path.EndsWith(".png") || path.EndsWith(".gif") || path.EndsWith(".jpg"))
            {
                Image image = new Image(path);
                 image.ApplicationUser = Owner;
                image.ApplicationUserId = Owner.Id;
                _context.Add(image);
            }
            if (path.EndsWith(".wav") || path.EndsWith(".mp3") || path.EndsWith(".wma") || path.EndsWith(".m4a"))
            {
                Clip image = new Clip(path);
                image.ApplicationUser = Owner;
                image.ApplicationUserId = Owner.Id;
                _context.Add(image);
            }
            await _context.SaveChangesAsync();

        }

        


    }

}