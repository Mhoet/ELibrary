using ELibrary.API.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.API.Data
{
    public class ElibraryDbContext : IdentityDbContext<User>
    {
        public ElibraryDbContext(DbContextOptions<ElibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        /* protected override void OnModelCreating(ModelBuilder builder)
         {
             base.OnModelCreating(builder);
             builder.ApplyConfiguration(new RoleConfiguration());
             builder.ApplyConfiguration(new AdminConfiguration());
         }*/
    }
}