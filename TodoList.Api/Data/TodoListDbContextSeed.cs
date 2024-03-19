﻿using Microsoft.AspNetCore.Identity;
using TodoList.Api.Entities;
using TodoList.Api.Enums;
using Task = System.Threading.Tasks.Task;

namespace TodoList.Api.Data
// Khi khoi dong tu dong bom du lieu mau vao DB
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            if (context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    PhoneNumber = "0123456789",
                    UserName = "admin",
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123#");
                context.Users.Add(user);
            }
            if (context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task(){
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
