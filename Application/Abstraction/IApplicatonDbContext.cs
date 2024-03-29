﻿using Domain.Entities;
using Domain.Entities.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Abstraction
{
    public interface IApplicatonDbcontext
    {
        EntityEntry Entry(object entity);
        DbSet<T> Set<T>() where T : class;
        DbSet<Book> Books { get; }
        DbSet<Commentary> Commentaries { get; }
        DbSet<Category> Categories { get; }
        DbSet<Author> Authors { get; }
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<Permission> Permissions { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
