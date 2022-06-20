using System;

namespace FA.LegalHCM.Web.Endpoints.ToDoItems
{
    public class ToDoItemResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}