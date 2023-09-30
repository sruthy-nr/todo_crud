using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoAPI;

public interface ITodoItemRepository
{
    Task<List<ToDoItem>> GetAllAsync();
    Task<int> AddToDoAsync(ToDoItem toDoItem);
    Task UpdateToDoAsync(int id, ToDoItem toDoItem);
    Task UpdateToDoStatusAsync(int id);
}
