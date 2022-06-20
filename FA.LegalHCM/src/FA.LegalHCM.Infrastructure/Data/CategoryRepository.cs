using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Infrastructure.Data
{
    public class CategoryRepository : EfRepository,ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
