using System;
using System.Collections.Generic;
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
    public class StudentController : ControllerBase
    {

        private IStudentRepository studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Student[]))]
        public IEnumerable<Student> Get()
        {
            return studentRepo.Retrieve().ToList();
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "GetStudentByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Student))]
        public ActionResult<Student> Get(Guid id)
        {
            try
            {
                var result = studentRepo.GetPersonWithForeignKey(id);
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

        // POST: api/Student
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Student))]
        public async Task<ActionResult<Student>> Post([FromBody] Student student)
        {
            try
            {
                student.StudentID = Guid.NewGuid();
                await studentRepo.CreateAsync(student);
                return CreatedAtRoute("GetStudentByID",
                    new
                    {
                        id = student.StudentID
                    },
                    student);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Student))]
        public async Task<ActionResult<Student>> Put(Guid id, [FromBody] Student student)
        {
            try
            {
                var result = await studentRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await studentRepo.UpdateAsync(id, student);

                return Ok(student);

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
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await studentRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                await studentRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
