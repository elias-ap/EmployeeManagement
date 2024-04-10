using EmployeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeAPI.Tests.Controllers
{
    public class EmployeeControllerTest
    {
        [Trait("Functional test", "EmployeeController")]
        [Fact(DisplayName = "Return an employee list from API")]
        public void Get()
        {
            // Arrange
            var controller = new EmployeeAPI.Controllers.EmployeeController(new EmployeeRepository(new EmployeeContext()));

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
        }
    }
}
