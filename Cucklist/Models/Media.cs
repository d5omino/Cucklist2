using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucklist.Models
{
    public abstract class Media
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string Filename { get; set; }
        [Required]
        [Url]
        public string Path { get; set; }
        public string FullName
        {
            get { return string.Format("{0}.{1}", Filename, FileExtension); }
        }
        public string Description { get; set; }
    }
}
