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
    public class SchoolController : ControllerBase
    {
        private ISchoolRepository schoolRepo;

        public SchoolController(ISchoolRepository schoolRepo)
        {
            this.schoolRepo = schoolRepo;
        }

        // GET: api/School
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<School>))]
        public ActionResult<IEnumerable<School>> Get()
        {
            return Ok(schoolRepo.Retrieve().ToList());
        }

        // GET: api/School/5
        [HttpGet("{id}", Name = "GetSchoolByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(School))]
        public async Task<ActionResult<School>> Get(Guid id)
        {
            try
            {
                var result = await schoolRepo.RetrieveAsync(id);
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

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(School))]
        public async Task<ActionResult<School>> Post([FromBody] School school)
        {
            try
            {
                school.SchoolID = Guid.NewGuid();
                await schoolRepo.CreateAsync(school);
                return CreatedAtRoute("GetSchoolByID",
                    new
                    {
                        id = school.SchoolID
                    }, school);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(School))]
        public async Task<ActionResult<School>> Put(Guid id, [FromBody] School school)
        {
            try
            {
                var result = await schoolRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await schoolRepo.UpdateAsync(id, school);
                return Ok(school);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<School>> Delete(Guid id)
        {
            try
            {
                var result = await schoolRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await schoolRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
