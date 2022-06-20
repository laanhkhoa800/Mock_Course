using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FA.LegalHCM.SharedKernel;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.LegalHCM.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(Guid id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id.Equals(id));
        }

        public Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToListAsync();
        }
       
        public async Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : BaseEntity
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task DeleteListAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            _dbContext.Set<T>().RemoveRange(_dbContext.Set<T>().Where(expression));

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync<T>(Guid id) where T : BaseEntity
        {
            T existing = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(existing);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            return _dbContext.Set<T>().Where(expression);
        }
        public async Task<IQueryable<T>> ListReview<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return  ApplySpecification(spec);
           
        }

    }
}
