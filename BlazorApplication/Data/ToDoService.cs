using BlazorApplication.Model;

using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApplication.Data
{
    public class ToDoService
    {
        
        private readonly ToDoDbContext _todoDbContext;
        
        public ToDoService(ToDoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        

        //Get UserId
        public async Task<List<ToDo>> GetUsersToDoItems(Guid userId)
        {
          return await _todoDbContext.Todos.Where(item => item.userId == userId).ToListAsync();
             
        }
        public async Task Additem (ToDo newItem)
        {
         
            
            _todoDbContext.Todos.Add(newItem);
            await _todoDbContext.SaveChangesAsync();
        }
        //List of ToDos
        public async Task<List<ToDo>> GetAllToDos()
        {
            //context.toDo.Where(b => b.UserId == userId).ToListAsync();
            return await _todoDbContext.Todos.ToListAsync();
        }

        //Add  ToDos
        public async Task<bool> InsertToDo(ToDo ToDo)
        {
            await _todoDbContext.Todos.AddAsync(ToDo);
            await _todoDbContext.SaveChangesAsync();
            return true;
        }

        //Get ToDo By Id  
        public async Task<ToDo> GetToDoById(int id)
        {
            ToDo ToDo = await _todoDbContext.Todos.FirstOrDefaultAsync(c => c.id.Equals(id));
            return ToDo;
        }

        //Update ToDo
        public async Task<bool> UpdateToDo(ToDo ToDo)
        {
            _todoDbContext.Todos.Update(ToDo);
            await _todoDbContext.SaveChangesAsync();
            return true;
        }

        //Delete ToDo
        public async Task<bool> DeleteToDo(ToDo ToDo)
        {
            _todoDbContext.Todos.Remove(ToDo);
            await _todoDbContext.SaveChangesAsync();
            return true;
        }
    }
}
    