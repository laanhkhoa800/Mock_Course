using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Infrastructure.Data.Repository
{
    public class StudentRepository : IStudentReponsitory
     {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public Task<List<T>> ListSTAsync<T>() where T: class
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public IQueryable<T> ListStudentAsync<T>() where T : class
        {
            var list = _dbContext.Set<T>();
            return list;
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        //public async Task<T> GetByIdAsync<T>(Guid id) where T : class
        //{
        //    return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        //}
    }
}
