using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EmployeeAPI.Domain;

namespace EmployeeAPI.Tests.Domain
{
    public class EmployeeRepositoryTest
    {
        [Fact(DisplayName = "Get all employees, return an employee list from database")]
        public void GetEmployee_ReturnEmployeeList()
        {
            // Arrange
            var repository = new EmployeeRepository(new EmployeeContext());

            // Act
            var result = repository.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
        }

        [Fact(DisplayName = "Get an employee by ID, return selected employee")]
        public void GetEmployeeById_ReturnSelectedEmployee()
        {
            // Arrange
            var repository = new EmployeeRepository(new EmployeeContext());
            var id = 1;

            // Act
            var result = repository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Employee>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact(DisplayName = "Add an new employee in database, return added employee")]
        public void ReceiveEmployee_AddEmployeeToDatabase_ReturnAddedEmployee()
        {
            // Arrange
            var repository = new EmployeeRepository(new EmployeeContext());
            var employee = new Employee
            {
                Name = "JOHN",
                Age = 23,
                BirthDate = new DateTime(2001, 4, 9),
                HiredDate = new DateTime(2024, 1, 1)
            };

            // Act
            var result = repository.Add(employee);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Employee>(result);
            Assert.True(result.Id > 0);
            Assert.Equal(employee, result);
        }

        [Fact(DisplayName = "Get employees filtering by name, return an filtered employee list from database")]
        public void ReceiveName_GetEmployeeByName_ReturnFilteredEmployeeList()
        {
            // Arrange
            var name = "john";
            var filter = new Func<Employee, bool>(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            var repository = new EmployeeRepository(new EmployeeContext());

            // Act
            var result = repository.GetByFilter(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
            Assert.All(result, (e) => Assert.Contains(e.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
