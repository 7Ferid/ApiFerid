using ApiFerid.Core.Entities;
using ApiFerid.DataAccess.Interceptor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Context
{
    internal class AppDbContext(BaseAuditableInterceptor _interceptor, DbContextOptions options) : DbContext(options)
    {
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); 
            

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
