using Application.Interfaces.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAcces.Interceptor
{
    public class AuditableEntitySaveChangesInterceptor: SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;
        private DbContext _context;

        public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {

            return base.SavingChanges(eventData, result);
        }
        public void UpdateEntity(DbContext context)
        {
            if (context==null)
            {
                return;
            }
            foreach (var item in context.ChangeTracker.Entries<>)
            {

            }
        }
    }
}
