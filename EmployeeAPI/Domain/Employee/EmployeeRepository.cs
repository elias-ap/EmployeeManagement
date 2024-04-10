using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Domain
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public Employee Add(Employee employee)
        {
            employee = _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee is null)
                return null;

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            employee = _context.Employees.Remove(employee);
            _context.SaveChanges();
            return employee;
        }

        public IEnumerable<Employee> GetByFilter(Func<Employee, bool> filter)
        {
            return _context.Employees.Where(filter);
        }

        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }
    }
}