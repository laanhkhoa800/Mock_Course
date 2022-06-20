using System;
using System.ComponentModel.DataAnnotations;

namespace FA.LegalHCM.Web.Endpoints.ToDoItems
{
    public class UpdateToDoItemRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}