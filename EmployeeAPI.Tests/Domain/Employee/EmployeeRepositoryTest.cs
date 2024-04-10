using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EmployeeAPI.Domain;
using EmployeeAPI.Extensions;
using System.IO;

namespace EmployeeAPI.Tests.Domain
{
    public class EmployeeRepositoryTest
    {
        public EmployeeRepositoryTest()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\App_Data"));
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Get all employees, return an employee list from database")]
        public void GetEmployee_ReturnEmployeeList()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository(new EmployeeContext());

            // Act
            var result = employeeRepository.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Get an employee by ID, return the selected employee")]
        public void GetEmployeeById_ReturnSelectedEmployee()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository(new EmployeeContext());
            var id = 1;

            // Act
            var result = employeeRepository.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Employee>(result);
            Assert.Equal(id, result.Id);
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Add an new employee in database, return the added employee")]
        public void ReceiveEmployee_AddGivenEmployeeToDatabase_ReturnAddedEmployee()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository(new EmployeeContext());
            var employee = new Employee
            {
                Name = "JOHN",
                BirthDate = new DateTime(2001, 4, 9),
                HiredDate = new DateTime(2024, 1, 1)
            };

            // Act
            var result = employeeRepository.Add(employee);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Employee>(result);
            Assert.True(result.Id > 0);
            Assert.Equal(employee, result);
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Get employees filtering by name, return an filtered employee list from database")]
        public void ReceiveName_GetEmployeeByGivenName_ReturnFilteredEmployeeList()
        {
            // Arrange
            var name = "john";
            var filter = new Func<Employee, bool>(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            var employeeRepository = new EmployeeRepository(new EmployeeContext());

            // Act
            var result = employeeRepository.GetByFilter(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
            Assert.All(result, (e) => Assert.Contains(e.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Update an employee in database, return the updated employee")]
        public void AddNewEmployee_UpdateAddedEmployee_ReturnUpdatedEmployee()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository(new EmployeeContext());
            var employee = new Employee()
            {
                Name = "",
                BirthDate = DateTime.Today,
                HiredDate = DateTime.Today
            };
            employee = employeeRepository.Add(employee);
            employee.Name = "NAME";
            employee.HiredDate.AddYears(-1);
            employee.BirthDate.AddYears(-24);

            // Act
            var result = employeeRepository.Update(employee);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Employee>(result);
            Assert.Equal(employee.Name, result.Name);
            Assert.Equal(employee.HiredDate, result.HiredDate);
            Assert.Equal(employee.BirthDate, result.BirthDate);
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Delete an employee in database, return the deleted employee")]
        public void AddNewEmployee_DeleteAddedEmployee_ReturnDeletedEmployee()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository(new EmployeeContext());
            var employee = new Employee()
            {
                Name = "",
                BirthDate = DateTime.Today,
                HiredDate = DateTime.Today
            };
            employee = employeeRepository.Add(employee);

            // Act
            employeeRepository.Delete(employee);

            // Assert
            Assert.NotNull(employee);
            Assert.IsType<Employee>(employee);
            Assert.Null(employeeRepository.GetById(employee.Id));
        }

        [Trait("Funcional test", "EmployeeRepository")]
        [Fact(DisplayName = "Delete an employee in database by ID, return the deleted employee")]
        public void AddNewEmployee_DeleteAddedEmployeeById_ReturnDeletedEmployee()
        {
            // Arrange
            var employeeRepository = new EmployeeRepository(new EmployeeContext());
            var employee = new Employee()
            {
                Name = "",
                BirthDate = DateTime.Today,
                HiredDate = DateTime.Today
            };
            employee = employeeRepository.Add(employee);

            // Act
            employeeRepository.Delete(employee.Id);

            // Assert
            Assert.NotNull(employee);
            Assert.IsType<Employee>(employee);
            Assert.Null(employeeRepository.GetById(employee.Id));
        }
    }
}
