using Microsoft.EntityFrameworkCore;
using BlazorApplication.Model;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Runtime.CompilerServices;
using BlazorApplication.Pages;
using ToDo = BlazorApplication.Model.ToDo;

namespace BlazorApplication.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<Model.ToDo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ToDo>().HasData(
               new()
               {
                   id = 1,
                   userId = Guid.Parse("202f8468-44aa-47de-8002-193442a83701"),
                   Title = "Reading",
                   Description = "Read atleast 2 books in a week",
                 
        


               },
               new()
               {
                   id = 2,
                   Title = "Washing",
                   Description = "Do laundary",
                   // DateTime = DateTime.Now,
                   //IsDone = false
               }
               );
        }
    }
}