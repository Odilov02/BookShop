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
        private DbContextOptions<AppDbContext> _options;
        public AppDbContext(DbContextOptions<AppDbContext> options, AuditableEntitySaveChangesInterceptor interceptor)
            : base(options)
        {
            _interceptor = interceptor;
            _options = options;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<Role>().Navigation(x => x.permissions).AutoInclude();
                modelBuilder.Entity<Permission>().HasData(
                new Permission() { Id = Guid.NewGuid(), PermissionName = "CreateAuthor" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "GetAuthor" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "UpdateAuthor" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "DeleteAuthor" },

                new Permission() { Id = Guid.NewGuid(), PermissionName = "GetUser" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "UpdateUserForAdmin" },

                new Permission() { Id = Guid.NewGuid(), PermissionName = "GetPermission" },

                new Permission() { Id = Guid.NewGuid(), PermissionName = "GetBook" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "UpdateBook" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "DeleteBook" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "CreateBook" },

                new Permission() { Id = Guid.NewGuid(), PermissionName = "CreateCategory" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "GetCategory" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "UpdateCategory" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "DeleteCategory" },

                new Permission() { Id = Guid.NewGuid(), PermissionName = "DeleteCommentary" },

                new Permission() { Id = Guid.NewGuid(), PermissionName = "CreateRole" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "GetRole" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "UpdateRole" },
                new Permission() { Id = Guid.NewGuid(), PermissionName = "DeleteRole" }
                );
            }
        }
    }
}