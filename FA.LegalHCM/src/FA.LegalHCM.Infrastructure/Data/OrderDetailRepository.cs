using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Infrastructure.Data
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderDetailRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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


        public IQueryable<T> ListAsync<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public async Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
