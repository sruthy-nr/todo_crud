using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ToDoAPI
{
    [Route("api")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;
        
        public ToDoItemController(ITodoItemRepository todoItemRepository){

            _todoItemRepository = todoItemRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllToDo(){
            var todo = await _todoItemRepository.GetAllAsync();
                        return Ok(todo);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewToDo([FromBody] ToDoItem toDoItem){
            var id = await _todoItemRepository.AddToDoAsync(toDoItem);
                        return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo([FromBody] ToDoItem toDoItem, [FromRoute] int id){
            await _todoItemRepository.UpdateToDoAsync(id, toDoItem);
            return Ok(id);
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateToDoStatus([FromRoute] int id){
            await _todoItemRepository.UpdateToDoStatusAsync(id);
            return Ok(id);
        }
       
       }
}