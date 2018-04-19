namespace Cucklist.Models
{
    public class Image : Media
    {

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserId { get; set; }

        public Image()
        {

        }

        public Image(string path) => Path = path;
    }
}
