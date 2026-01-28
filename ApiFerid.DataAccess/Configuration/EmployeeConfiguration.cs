using ApiFerid.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.DataAccess.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Salary).IsRequired().HasPrecision(10, 2);
            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
