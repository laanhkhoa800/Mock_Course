using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Infrastructure.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id).AsTask();
        }

        public IQueryable<T> List<T>() where T : class
        {
            return _dbContext.Set<T>().AsQueryable<T>();
        }

        public IQueryable<T> List<T>(Expression<Func<T, bool>> query) where T : class
        {
            return _dbContext.Set<T>().AsQueryable<T>().Where(query);
        }

        public async Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = ApplySpecification(spec);

            return await specificationResult.ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePermissionAsync<T>(List<T> listRolePermission) where T : class
        {
            _dbContext.Set<T>().RemoveRange(listRolePermission);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();

            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}