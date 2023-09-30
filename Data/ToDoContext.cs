using Microsoft.EntityFrameworkCore;
namespace ToDoAPI.Data
{
        public class ToDoContext : DbContext
        {
            public ToDoContext(DbContextOptions<ToDoContext> options)
                : base(options)
            { }
            public DbSet<ToDoItem> ToDoItem { get; set; }

        }
}