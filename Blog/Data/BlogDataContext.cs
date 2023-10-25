using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
<<<<<<< HEAD
            => options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$");
=======
            => options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=q1w2e3#@!;TrustServerCertificate=True");
        //Server=localhost,1433;Database=Blog;User ID = sa; Password=q1w2e3#@!; TrustServerCertificate=True;
>>>>>>> d0b3793719c3dee71a2387b0a161fe768cc71c57

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}