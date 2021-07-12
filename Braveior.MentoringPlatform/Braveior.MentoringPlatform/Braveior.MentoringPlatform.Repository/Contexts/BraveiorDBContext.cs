using Braveior.MentoringPlatform.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Braveior.MentoringPlatform.Repository.Contexts
{
    public class BraveiorDBContext : DbContext
    {
        public BraveiorDBContext()
        {
        }
        public BraveiorDBContext(DbContextOptions<BraveiorDBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.\\sqlexpress;User ID=sa;Password=password$$;Initial Catalog=braveiordb");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Kanboard> Kanboards { get; set; }

        public DbSet<Institution> Institutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var institutions = new Institution[] {
                new Institution { InstitutionId = 1, Name = "Modern Engineering College", Type = "College", City = "Coimbatore", Country= "India", District="Coimbatore", State="Tamilnadu", Pincode="641035"},
                new Institution { InstitutionId = 2, Name = "West Arts College", Type = "College", City = "Coimbatore", Country= "India", District="Coimbatore", State="Tamilnadu", Pincode="641035"}
            };
            var users = new User[] {
                new User { UserId = 1, Name = "Ramesh Kumar", InstitutionId = 1, Password="password", Role = "student", Email = "ramesh@email.com" },
                new User { UserId = 2, Name = "Mary John",  InstitutionId = 2, Password="password", Role = "student", Email = "mary@email.com"  }
            };
            var products = new Product[] {
                new Product { ProductId = 1, Name = "Kube Assist", Description = ""},
                new Product { ProductId = 2, Name = "Braveior Kanboard ", Description = ""  }
            };
            var kanboards = new Kanboard[] {
                new Kanboard { KanboardId = 1, Name = "Kube Assist -  Modern Engineering College ", InstitutionId = 1},
                new Kanboard { KanboardId = 2, Name = "Kube Assist -  West Arts College", InstitutionId = 2}
            };
            var tasks = new Task[] {
                new Task { TaskId = 1, Name = "Task 1", Description="Task 1 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 2, Name = "Task 2", Description="Task 2 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 3, Name = "Task 3", Description="Task 3 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 4, Name = "Task 4", Description="Task 4 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 5, Name = "Task 5", Description="Task 5 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 6, Name = "Task 6", Description="Task 6 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 7, Name = "Task 7", Description="Task 7 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 8, Name = "Task 8", Description="Task 8 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 9, Name = "Task 9", Description="Task 9 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5},
                new Task { TaskId = 10, Name = "Task 10", Description="Task 10 description", ProductId = 1,  KanboardId=1, Status = "NOT-STARTED", StoryPoint = 5, StartDate=DateTime.Now, CompletionDate= DateTime.Now, EstimatedDays=10, ActualDays=5}

            };

            modelBuilder.Entity<Institution>().HasData(institutions);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Kanboard>().HasData(kanboards);
            modelBuilder.Entity<Task>().HasData(tasks);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
