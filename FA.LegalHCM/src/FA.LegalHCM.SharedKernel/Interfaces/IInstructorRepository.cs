using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace FA.LegalHCM.SharedKernel.Interfaces
{
    public interface IInstructorRepository: IRepository
    {
        //IQueryable<T> ListInstructorAsync<T>() where T : class;
        Task<List<T>> ListInstructorAsync<T>(ISpecification<T> spec) where T : class;
        Task<List<T>> SearchInstructorAsync<T>(ISpecification<T> spec) where T : class;
        IQueryable<T> GetInstructorByIdAsync<T>(Guid id) where T : class;
        Task UpdateInstructorAsync<T>(T entity) where T : class;
        Task<T> GetByEmail<T>(ISpecification<T> spec) where T : class;
        Task<T> GetByUserName<T>(ISpecification<T> spec) where T : class;
    }
}
