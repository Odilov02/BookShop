using Application.Abstraction;
using Domain.Entities;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterfaces
{
    public class CategoryService:Repository<Category>,ICategoryService
    {
        private readonly IApplicatonDbcontext _db;

    public CategoryService(IApplicatonDbcontext db) : base(db)
    {
        _db = db;
    }
}
}
