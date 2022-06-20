using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.SharedKernel.Interfaces
{
    public interface IRoleRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : class;

        IQueryable<T> List<T>() where T : class;

        IQueryable<T> List<T>(Expression<Func<T, bool>> query) where T : class;

        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : class;

        Task<T> AddAsync<T>(T entity) where T : class;

        Task<T> UpdateAsync<T>(T entity) where T : class;

        Task DeleteAsync<T>(T entity) where T : class;

        Task DeletePermissionAsync<T>(List<T> listRolePermission) where T : class;

    }
}