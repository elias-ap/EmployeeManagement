using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Domain
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("EMPLOYEES");

            HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasColumnName("ID");

            Property(e => e.Name)
                .HasColumnName("NAME");

            Property(e => e.BirthDate)
                .HasColumnName("BIRTH_DATE");

            Property(e => e.HiredDate)
                .HasColumnName("HIRED_DATE");
        }
    }
}