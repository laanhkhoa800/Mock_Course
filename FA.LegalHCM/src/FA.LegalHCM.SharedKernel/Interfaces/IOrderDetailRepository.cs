using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.SharedKernel.Interfaces
{
    public interface IOrderDetailRepository
    {
        IQueryable<T> ListAsync<T>() where T : class;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class;
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
