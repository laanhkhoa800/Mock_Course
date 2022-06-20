using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.SharedKernel.Interfaces
{
    public interface IUserRepository
    {
        //Task<T> GetByIdAsync<T>(Guid id) where T :class;
        IQueryable<T> List<T>() where T : class;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class;
        Task<T> AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task LoginAsync<User>(string email, string password);
        
    }
}
