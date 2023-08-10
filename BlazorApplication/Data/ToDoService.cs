using BlazorApplication.Model;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace BlazorApplication.Data
{
    public class ToDoService
    {
        
        private readonly ToDoDbContext _todoDbContext;
        private readonly IDataProtector _dataProtector;

        public ToDoService(ToDoDbContext todoDbContext, IDataProtectionProvider dataProtectionProvider)
        {
            _todoDbContext = todoDbContext;
            _dataProtector = dataProtectionProvider.CreateProtector("ToDoFields");
        }

      

        //Get UserId
        public async Task<List<ToDo>> GetUsersToDoItems(Guid userId)
        {
            //return await _todoDbContext.Todos.Where(item => item.userId == userId).ToListAsync();

            var todos = await _todoDbContext.Todos.Where(item => item.userId == userId).ToListAsync();

            foreach (var todo in todos)
            {
                todo.Title = Decrypt(todo.Title);
                todo.Description = Decrypt(todo.Description);
            }

            return todos;

        }
        //Add  ToDos
        public async Task Additem (ToDo newItem)
        {
            newItem.Title = Encrypt(newItem.Title);
            newItem.Description = Encrypt(newItem.Description);

            _todoDbContext.Todos.Add(newItem);
            await _todoDbContext.SaveChangesAsync();
        }
        //List of ToDos
        public async Task<List<ToDo>> GetAllToDos(ToDo newItem)
        {
            var todos = await _todoDbContext.Todos.ToListAsync();

            foreach (var todo in todos)
            {
                todo.Title = Decrypt(todo.Title);
                todo.Description = Decrypt(todo.Description);
            }

            return todos;

           
        }

        // Functions to encrypt and decrypt
        private string Encrypt(string input)
        {
            byte[] encryptedBytes = _dataProtector.Protect(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(encryptedBytes);
            // return _dataProtector.Protect(input);
        }

        public string Decrypt(string encryptedInput)
        {
            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedInput);
                byte[] decryptedBytes = _dataProtector.Unprotect(encryptedBytes);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
            catch (Exception ex)
            {
               
                return "Decryption Error";
            }
            // return _dataProtector.Unprotect(encryptedInput);
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
    