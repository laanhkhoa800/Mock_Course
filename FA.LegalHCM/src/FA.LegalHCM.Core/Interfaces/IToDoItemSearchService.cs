using Ardalis.Result; 
using FA.LegalHCM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync();
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string searchString);
    }
}
