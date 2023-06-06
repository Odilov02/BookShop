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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission() { Id = 1, PermissionName = "CreateAuthor" },
                new Permission() { Id = 2, PermissionName = "GetAuthor" },
                new Permission() { Id = 3, PermissionName = "UpdateAuthor" },
                new Permission() { Id = 4, PermissionName = "DeleteAuthor" },

                new Permission() { Id = 6, PermissionName = "GetUser" },
                new Permission() { Id = 7, PermissionName = "UpdateUserForAdmin" },

                new Permission() { Id = 8, PermissionName = "GetPermission" },

                new Permission() { Id = 9, PermissionName = "GetBook" },
                new Permission() { Id = 10, PermissionName = "UpdateBook" },
                new Permission() { Id = 11, PermissionName = "DeleteBook" },
                new Permission() { Id = 12, PermissionName = "CreateBook" },

                new Permission() { Id = 13, PermissionName = "CreateCategory" },
                new Permission() { Id = 14, PermissionName = "GetCategory" },
                new Permission() { Id = 15, PermissionName = "UpdateCategory" },
                new Permission() { Id = 16, PermissionName = "DeleteCategory" },

                new Permission() { Id = 17, PermissionName = "UpdateCommentary" },
                new Permission() { Id = 18, PermissionName = "DeleteCommentary" },

                new Permission() { Id = 19, PermissionName = "CreateRole" },
                new Permission() { Id = 20, PermissionName = "GetRole" },
                new Permission() { Id = 21, PermissionName = "UpdateRole" },
                new Permission() { Id = 22, PermissionName = "DeleteRole" }
                );
        }
    }
}
