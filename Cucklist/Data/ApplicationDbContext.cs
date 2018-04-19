using Cucklist.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cucklist.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Image>().HasOne(u => u.ApplicationUser)
                                   .WithMany(i => i.Images)
                                   .HasForeignKey(u => u.ApplicationUserId)
                                   .HasConstraintName("FK_Image_AspNetUsers_ApplicationUserId");
            builder.Entity<Video>().HasOne(u => u.ApplicationUser)
                                   .WithMany(v => v.Videos)
                                   .HasForeignKey(u => u.ApplicationUserId)
                                   .HasConstraintName("FK_Video_AspNetUsers_ApplicationUserId");
            builder.Entity<Clip>() .HasOne(u => u.ApplicationUser)
                                   .WithMany(c => c.Clips)
                                   .HasForeignKey(u => u.ApplicationUserId)
                                   .HasConstraintName("FK_Clip_AspNetUsers_ApplicationUserId");
        }
        public DbSet<Image> Image { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Clip> Clip { get; set; }
    }
}
