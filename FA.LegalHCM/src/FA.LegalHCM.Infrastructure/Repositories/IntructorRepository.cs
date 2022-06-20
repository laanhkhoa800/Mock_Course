using Ardalis.Specification;
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
using Ardalis.Specification.EntityFrameworkCore;

namespace FA.LegalHCM.Infrastructure.Data.Repositories
{
    public class IntructorRepository : EfRepository, IInstructorRepository
    {
        private readonly AppDbContext _dbContext;

        public IntructorRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /*    public IQueryable<T> ListInstructorAsync<T>() where T : class
            {
                var list = _dbContext.Set<T>().GetType();
                return list;
            }
    */

        public async Task<List<T>> ListInstructorAsync<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = ApplyListSpecification(spec);
            return await specificationResult.ToListAsync();
        }

        private IQueryable<T> ApplyListSpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<List<T>> SearchInstructorAsync<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = ApplySearchSpecification(spec);
            return await specificationResult.ToListAsync();
        }

        private IQueryable<T> ApplySearchSpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public IQueryable<T> GetInstructorByIdAsync<T>(Guid id) where T : class
        {
            return _dbContext.Set<T>();
        }

        public async Task UpdateInstructorAsync<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByEmail<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = EmailExistedSpecification(spec);
            return await specificationResult.FirstOrDefaultAsync();
        }

        private IQueryable<T> EmailExistedSpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> GetByUserName<T>(ISpecification<T> spec) where T : class
        {
            var specificationResult = UserNameExistedSpecification(spec);
            return await specificationResult.FirstOrDefaultAsync();
        }

        private IQueryable<T> UserNameExistedSpecification<T>(ISpecification<T> spec) where T : class
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

    }
}
