using Microsoft.EntityFrameworkCore;
using BlazorApplication.Model;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Runtime.CompilerServices;
using BlazorApplication.Pages;

namespace BlazorApplication.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<todo>().HasData(
               new()
               {
                   id = 1,
                   Title = "Reading",
                   Description = "Read atleast 2 books in a week",
                   DateTime = DateTime.Now,
                   IsDone= true



               },
               new()
               {
                   id = 2,
                   Title = "Washing",
                   Description = "Do laundary",
                   DateTime = DateTime.Now,
                   IsDone = false
               }
               );
        }
    }
}