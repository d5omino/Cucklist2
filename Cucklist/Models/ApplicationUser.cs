using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;

namespace Cucklist.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<Clip> Clips { get; set; }

    }
}
