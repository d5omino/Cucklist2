using Cucklist.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Cucklist.ViewComponents
{
    public class MyUploadsViewComponent : ViewComponent
    {
        UserManager<ApplicationUser> _usermanager { get; set; }
        public MyUploadsViewComponent(UserManager<ApplicationUser> usermanager)
        {

            _usermanager = usermanager;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ApplicationUser CurrentUser = await _usermanager.GetUserAsync(HttpContext.User);

            return View(CurrentUser);
        }
    }
}
