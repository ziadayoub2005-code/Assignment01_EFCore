using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EFDay01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDay01.Configuration_Classes
{
    // separation of concern
    // Maintainability
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            //modelBuilder.Entity<Department>().ToView("Departments");
            builder.HasKey(D => D.Id);
            builder.Property(D => D.Id)
             .UseIdentityColumn(10, 10);

            builder.Property(D => D.Name)
                    .IsRequired(true)
                    .HasColumnType("varchar")
                    .HasColumnName("DeptName")
                    .HasDefaultValue("Dept")
                    .HasMaxLength(50);
        }
    }
}
