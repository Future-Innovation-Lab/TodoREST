using System.Collections.Generic;
using System.Linq;
using TodoAPI.Data;
using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoRepository : ITodoRepository
    {
        private TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public IEnumerable<TodoItem> All
        {
            get { return _todoContext.TodoItems.ToList(); }
        }

        public bool DoesItemExist(string id)
        {
            return _todoContext.TodoItems.Any(item => item.ID == id);
        }

        public TodoItem Find(string id)
        {
            return _todoContext.TodoItems.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(TodoItem item)
        {
            _todoContext.TodoItems.Add(item);
            _todoContext.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            var todoItem = this.Find(item.ID);

            todoItem.Name = item.Name;
            todoItem.Notes = item.Notes;
            todoItem.Done = item.Done;
            _todoContext.TodoItems.Update(todoItem);
            _todoContext.SaveChanges();
        }

        public void Delete(string id)
        {
            _todoContext.TodoItems.Remove(this.Find(id));
            _todoContext.SaveChanges();
        }
    }
}
