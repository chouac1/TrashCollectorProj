using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<Customer> Customers;
        DbSet<Employee> Employees;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TrashCollectorProject.Models.Customer> Customer { get; set; }
        public DbSet<TrashCollectorProject.Models.Employee> Employee { get; set; }
    }
}
