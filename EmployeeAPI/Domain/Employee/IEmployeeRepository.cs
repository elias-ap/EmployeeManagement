using System;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeAPI.Domain
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);

        IEnumerable<Employee> GetByFilter(Func<Employee, bool> filter);

        IEnumerable<Employee> Get();

        Employee Add(Employee employee);

        Employee Remove(Employee employee);
    }
}