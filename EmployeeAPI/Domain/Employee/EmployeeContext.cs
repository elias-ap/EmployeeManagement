using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Domain
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext() : base($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='{Path.GetFullPath("../../App_Data/Database.mdf")}';Integrated Security=True;Connect Timeout=30")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .ToTable("EMPLOYEES");

            modelBuilder
                .Entity<Employee>()
                .HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasColumnName("ID");

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.Name)
                .HasColumnName("NAME");

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.Age)
                .HasColumnName("AGE");

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.BirthDate)
                .HasColumnName("BIRTH_DATE");

            modelBuilder
                .Entity<Employee>()
                .Property(e => e.HiredDate)
                .HasColumnName("HIRED_DATE");

        }
    }
}