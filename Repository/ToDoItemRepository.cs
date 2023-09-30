using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoAPI;
using ToDoAPI.Data;
using System.Threading.Tasks;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly ToDoContext _context;

    public TodoItemRepository(ToDoContext context)
    {
        _context = context;
    }

    public async Task<List<ToDoItem>> GetAllAsync()
    {
        var todo = await _context.ToDoItem.Select(x => new ToDoItem()
        {
            Id = x.Id,
            Text = x.Text,
            Fromtime = x.Fromtime,
            Totime = x.Totime,
            Completed = x.Completed,
            Date = x.Date
        }
        ).ToListAsync();
        
         return todo;
    }

    public async Task<int> AddToDoAsync(ToDoItem toDoItem)
    {
        var todo = new ToDoItem()
        {
            Text = toDoItem.Text,
            Fromtime = toDoItem.Fromtime,
            Totime = toDoItem.Totime,
            Completed = toDoItem.Completed,
            Date = toDoItem.Date
        };
        _context.ToDoItem.Add(todo);
        await _context.SaveChangesAsync();
        return todo.Id;
    }

     public async Task UpdateToDoAsync(int id, ToDoItem toDoItem)
    {
        var todo = await _context.ToDoItem.FindAsync(id);
        if (todo != null)
        {
            todo.Text = toDoItem.Text;
            todo.Fromtime = toDoItem.Fromtime;
            todo.Totime = toDoItem.Totime;
            todo.Completed = toDoItem.Completed;
            todo.Date = toDoItem.Date;
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task UpdateToDoStatusAsync(int id)
    {
        var status = await _context.ToDoItem.FindAsync(id);
        if (status != null)
        {
            status.Completed = !status.Completed;
            await _context.SaveChangesAsync();
        }

    }
}
