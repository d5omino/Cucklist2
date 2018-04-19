namespace Cucklist.Models
{
    public class Video : Media
    {

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual string ApplicationUserId { get; set; }


        public Video()
        {

        }

        public Video(string path) => Path = path;

    }
}
