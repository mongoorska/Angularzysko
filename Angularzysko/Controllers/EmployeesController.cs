using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Angularzysko.Models;
using Angularzysko.Interfaces;


namespace Angularzysko.Controllers
{
    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeesController : Controller
    {
        private readonly IMyData _myData;

        public EmployeesController(IMyData myData)
        {
            _myData = myData;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _myData.GetEmployees();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var employee = _myData.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            _myData.AddEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Employee employee)
        {
            if (_myData.GetEmployee(id) == null) return NotFound();
            else
            {
                _myData.UpdateEmployee(id, employee);
                return Ok(employee);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_myData.GetEmployee(id) == null) return NotFound();
            else
            {
                _myData.DeleteEmployee(id);
                return Ok(_myData.GetEmployee(id));
            }

        }




    }
}