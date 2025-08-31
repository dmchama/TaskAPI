using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=DESKTOP-J3LV3I3\\SQLEXPRESS;Database=NewTodoDb;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1,Name = "Chamara", AddressNo = "24", Street = "Street 1", City = "Colombo 1" },
                new Author { Id = 2,Name = "Sampath", AddressNo = "25", Street = "Street 2", City = "Colombo 3" },
            }
            );

            modelBuilder.Entity<Todo>().HasData(new Todo[]
            {
                new Todo 
                {
                Id = 1,
                Title = "title 1 - DB",
                Description = "des 1 - DB",
                Created = new DateTime(2025, 08, 30),
                Due = new DateTime(2025, 09, 04),
                Status = TodoStatus.New,
                AuthorId = 1,
                },

                new Todo
                {
                Id = 2,
                Title = "title 2 - DB",
                Description = "des 2 - DB",
                Created = new DateTime(2025, 08, 29),
                Due = new DateTime(2025, 09, 05),
                Status = TodoStatus.InProgress,
                AuthorId = 2,
                },
            }
            );
        }



    }
}
