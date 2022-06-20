
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.SharedKernel.Interfaces
{
    public interface IStudentReponsitory
    {
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class;
        Task<List<T>> ListSTAsync<T>() where T : class;
        IQueryable<T> ListStudentAsync<T>() where T : class;

        Task UpdateAsync<T>(T entity) where T : class;
       // Task<T> GetByIdAsync<T>(Guid id) where T : class;
    }
}
