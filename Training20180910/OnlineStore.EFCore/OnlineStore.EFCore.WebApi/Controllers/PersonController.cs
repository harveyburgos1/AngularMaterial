using System;
using System.Collections.Generic;
using System.IO;
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
    public class PersonController : ControllerBase
    {
        IPersonRepository personRepo;
        public PersonController(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        // GET: api/Person
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Person[]))]
        public IEnumerable<Person> Get()
        {
            return personRepo.Retrieve().ToList();
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "GetPersonByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Person))]
        public async Task<ActionResult<Person>> Get(string id)
        {
            try
            {
                var result = await personRepo.RetrieveAsync(id);
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

        [HttpGet("{page}/{itemsPerPage}", Name = "GetPersonWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Person>))]
        public ActionResult<PaginationResult<Person>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Person>();
                result = personRepo.GetPersonWithPagination(page, itemsPerPage, filter);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // POST: api/Person
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Person))]
        public async Task<ActionResult<Person>> Post([FromBody] Person person)
        {
            try
            {
                person.PersonID = Guid.NewGuid();
                await personRepo.CreateAsync(person);
                return CreatedAtRoute("GetPersonByID",
                    new
                    {
                        id = person.PersonID
                    },
                    person);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Person))]
        public async Task<ActionResult<Person>> Put(Guid id, [FromBody] Person person)
        {
            try
            {
                var result = await personRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return Ok();
                }
                await personRepo.UpdateAsync(id, person);
                return Ok(person);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Person>> Delete(Guid id)
        {
            try
            {
                var result = await personRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await personRepo.DeleteAsync(id);
                
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
