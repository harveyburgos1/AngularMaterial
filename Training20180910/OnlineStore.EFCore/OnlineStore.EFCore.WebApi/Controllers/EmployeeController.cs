using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;

namespace OnlineStore.EFCore.WebApi.Controllers
{
    [EnableCors("OnlineStoreAngular6")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Employee>))]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(employeeRepo.Retrieve());
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "GetEmployeeByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Employee))]
        public async Task<ActionResult<Employee>>  Get(Guid id)
        {
            try
            {
                var result = await employeeRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{page}/{itemsPerPage}", Name = "GetEmployeeWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Employee>))]
        public ActionResult<PaginationResult<Employee>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Employee>();
                result = employeeRepo.RetrieveEmployeeWithPagination(page, itemsPerPage, filter);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Employee))]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            try
            {
                employee.EmployeeID = Guid.NewGuid();
                await employeeRepo.CreateAsync(employee);
                return CreatedAtRoute("GetEmployeeByID", 
                    new { id = employee.EmployeeID},employee);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Employee))]
        public async Task<ActionResult<Employee>> Put(Guid id, [FromBody] Employee employee)
        {
            try
            {
                var result = await employeeRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await employeeRepo.UpdateAsync(id, employee);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Employee>> Delete(Guid id)
        {
            try
            {
                var result = await employeeRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await employeeRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
