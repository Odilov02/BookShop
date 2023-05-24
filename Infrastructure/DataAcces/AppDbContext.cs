using Application.Abstraction;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAcces
{
    public class AppDbContext : DbContext, IApplicatonDbcontext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Commentary> Commentarys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
