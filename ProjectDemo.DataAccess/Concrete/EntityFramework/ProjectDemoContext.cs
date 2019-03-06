using Microsoft.EntityFrameworkCore;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.DataAccess.Concrete.EntityFramework
{
    public class ProjectDemoContext : DbContext
    {
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=True");

        }
       
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
