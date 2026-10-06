using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDay01.Configuration_Classes;
using EFDay01.Models;
using Microsoft.EntityFrameworkCore;





namespace EFDay01.DbContexts
{
    // Connection Data :  Connection string (Key , Value)
    // ServerName , Connect How , Database Name

    // Microsoft.EntityFrameworkCore.SqlServer : Pkg 01
    // Microsoft.EntityFrameworkCore.tools : Pkg 02 : manage migrations

    // OnConfiguring() >> DbContext >> library >> Package
    // install packages : Js : NPM
    // Dot Net : NPM >> nuget package manager >> nuget.org>>connected
    // How?
    // What?
    internal class CompanyDbContext : DbContext
    {
        // Connection Data
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Company;Trusted_Connection=True;");
        }
        // Map Model(class)
        // public List<Employee> Employees { get; set; }

        // Collection + support EF operation
        public DbSet<Employee> Employees { get; set; }








        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Code configurations inside OnModelCreating
        //    ////  Code : Configurations(advanced configuration)
        //    /// 1- advanced configurations
        //    /// 2- separation of concern
        //    /// 3- No Source Code (Separate layers(Models))

        //    //// level 01
        //    //modelBuilder.Entity<Department>()
        //    //   .ToTable("Departments");
        //    ////modelBuilder.Entity<Department>().ToView("Departments");
        //    //modelBuilder.Entity<Department>()
        //    //    .HasKey(D => D.Id);
        //    //modelBuilder.Entity<Department>()
        //    //    .Property(D => D.Id)
        //    //    .UseIdentityColumn(10, 10);

        //    //modelBuilder.Entity<Department>()
        //    //        .Property(D => D.Name)
        //    //        .IsRequired(true)
        //    //        .HasColumnType("varchar")
        //    //        .HasColumnName("DeptName")
        //    //        .HasDefaultValue("Dept")
        //    //        .HasMaxLength(50);


        //    //// level 02 - EF core 3.1
        //    //modelBuilder.Entity<Department>(D =>
        //    //{
        //    //    D.ToTable("Departments");
        //    //    //modelBuilder.Entity<Department>().ToView("Departments");
        //    //    D.HasKey(D => D.Id);
        //    //    D.Property(D => D.Id)
        //    //     .UseIdentityColumn(10, 10);

        //    //    D.Property(D => D.Name)
        //    //            .IsRequired(true)
        //    //            .HasColumnType("varchar")
        //    //            .HasColumnName("DeptName")
        //    //            .HasDefaultValue("Dept")
        //    //            .HasMaxLength(50);
        //    //});


        //    ////level 03
        //    modelBuilder.ApplyConfiguration(new DepartmentConfigurations());


        //    // self : one line for all configurations >> Project
        //}
    }
}
