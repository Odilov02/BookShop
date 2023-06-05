using Application.Abstraction;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Infrastructure.DataAcces.Interceptor;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAcces
{
    public class AppDbContext : DbContext, IApplicatonDbcontext
    {
        private AuditableEntitySaveChangesInterceptor _interceptor;

        public AppDbContext(DbContextOptions<AppDbContext> options, AuditableEntitySaveChangesInterceptor interceptor)
            : base(options)
        {
            _interceptor = interceptor;
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
        }
    }
}
