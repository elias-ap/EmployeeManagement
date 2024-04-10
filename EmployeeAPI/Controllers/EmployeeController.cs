using EmployeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("api/get")]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        [Route("api/get/{id}")]
        public Employee Get(int id)
        {
            return _employeeRepository.GetById(id);
        }

        [Route("api/add")]
        public Employee Post([FromBody]Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        [Route("api/update")]
        public Employee Put([FromBody]Employee employee)
        {
            return _employeeRepository.Update(employee);
        }

        [Route("api/delete/{id}")]
        public Employee Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        [Route("api/delete/")]
        public Employee Delete([FromBody]Employee employee)
        {
            return _employeeRepository.Delete(employee);
        }
    }
}
