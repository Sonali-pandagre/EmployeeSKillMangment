using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employeeskillmanagment;
using Employeeskillmanagment.Models;
using Microsoft.EntityFrameworkCore;
namespace Employeeskillmanagment.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

     
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FirstName = "Sonali",
                LastName = "Pandagre",
                DOJ = DateOnly.FromDateTime(new DateTime(2022, 11, 3)),
                Designation = "Developer",
                Email = "sonalipandagre2@gmail.com"
                // DepartmentId = 1
            },
                new Employee
                {
                    Id = 2,
                    FirstName = "Rashmi",
                    LastName = "Bansal",
                    DOJ = DateOnly.FromDateTime(new DateTime(2022, 11, 3)),
                    Designation = "Tester",
                    Email = "rashmi@gmail.com"
                    // DepartmentId = 2

                },
            new Employee
            {
                Id = 3,
                FirstName = "Mayuri",
                LastName = "Shirbhate",
                DOJ = DateOnly.FromDateTime(new DateTime(2022, 10, 3)),
                Designation = "Designer",
                Email = "aditya@gmail.com"
                //  DepartmentId = 2

            },
            new Employee
            {
                Id = 4,
                FirstName = "Anima",
                LastName = "Sahu",
                DOJ = DateOnly.FromDateTime(new DateTime(2021, 10, 3)),
                Designation = "Architecture",
                Email = "animasahu10@gmail.com"
                // DepartmentId = 3

            },
            new Employee
            {
                Id = 5,
                FirstName = "Divya",
                LastName = "das",
                DOJ = DateOnly.FromDateTime(new DateTime(2020, 10, 4)),
                Designation = "Sr. Developer",
                Email = "divydas20@gmail.com"
                // DepartmentId = 1
            },
            new Employee
            {
                Id = 6,
                FirstName = "Ankush",
                LastName = "Pandagre",
                DOJ = DateOnly.FromDateTime(new DateTime(2021, 12, 4)),
                Designation = "Frotend Developer",
                Email = "ankushpandagre100@gmail.com"
                // DepartmentId = 4
            }
            );
        }
      //  public object Departments { get; internal set; }
    }
}