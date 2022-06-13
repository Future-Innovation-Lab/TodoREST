using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public static class InitialData
    {
        public static void Seed(this TodoContext dbContext)
        {
            if (!dbContext.TodoItems.Any())
            {

                dbContext.TodoItems.Add(new TodoItem
                {
                    ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                    Name = "Learn app development",
                    Notes = "Take Microsoft Learn Courses",
                    Done = true
                });

                dbContext.TodoItems.Add(new TodoItem
                {
                    ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                    Name = "Develop apps",
                    Notes = "Use Visual Studio and Visual Studio for Mac",
                    Done = false
                });

                dbContext.TodoItems.Add(new TodoItem
                {
                    ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                    Name = "Publish apps",
                    Notes = "All app stores",
                    Done = false,
                });



                dbContext.SaveChanges();
            }
        }
    }
}
