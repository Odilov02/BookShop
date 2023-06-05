using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction
{
    public interface IApplicatonDbcontext
    {
        DbSet<T> Set<T>() where T : class;
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Commentary> Commentaries { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
