namespace Cucklist.Models
{
    public class Clip : Media
    {

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserId { get; set; }

        public Clip()
        {

        }

        public Clip(string path) => Path = path;
    }
}
