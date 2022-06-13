using Microsoft.EntityFrameworkCore;
using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Data
{

    public class TodoContext
        : DbContext
    {
        public TodoContext(DbContextOptions options)
            : base(options)
        {

        }



        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
