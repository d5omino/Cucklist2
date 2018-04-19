using Cucklist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cucklist.ViewComponents
{
    public class FileUploadViewComponent : ViewComponent
    {
        UserManager<ApplicationUser> _usermanager { get; set; }
        public FileUploadViewComponent(UserManager<ApplicationUser> usermanager)
        {

            _usermanager = usermanager;

        }
        [Authorize]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ApplicationUser CurrentUser = await _usermanager.GetUserAsync(HttpContext.User);


            return View(CurrentUser);
        }


    }
}
