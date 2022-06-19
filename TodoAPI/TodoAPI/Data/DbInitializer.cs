using TodoAPI.Data;
using TodoAPI.Models;
using System.Linq;

namespace BankingApi.Data
{
    public class DbInitialiser
    {
        private readonly TodoContext _context;

        public DbInitialiser(TodoContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.TodoItems.Any())
            {
                _context.TodoItems.Add(new TodoItem
                {
                    ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                    Name = "Learn app development",
                    Notes = "Take Microsoft Learn Courses",
                    Done = true
                });

                _context.TodoItems.Add(new TodoItem
                {
                    ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                    Name = "Develop apps",
                    Notes = "Use Visual Studio and Visual Studio for Mac",
                    Done = false
                });

                _context.TodoItems.Add(new TodoItem
                {
                    ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                    Name = "Publish apps",
                    Notes = "All app stores",
                    Done = false,
                });



                _context.SaveChanges();
            }
        }
    }
}

