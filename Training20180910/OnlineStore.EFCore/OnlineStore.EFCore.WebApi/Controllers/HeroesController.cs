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
    public class HeroesController : ControllerBase
    {
        private IHeroRepository heroRepo;

        public HeroesController(IHeroRepository heroRepo)
        {
            this.heroRepo = heroRepo;
        }
        // GET: api/Heroes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Hero>))]
        public ActionResult<IEnumerable<Hero>> Get()
        {

            return Ok(heroRepo.Retrieve().ToList());
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "GetHeroesByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Hero))]
        public async Task<ActionResult<Hero>> Get(Guid id)
        {
            try
            {
                var result = await heroRepo.RetrieveAsync(id);
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

        [HttpGet("{page}/{itemsPerPage}", Name = "GetHeroesWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Hero>))]
        public ActionResult<PaginationResult<Hero>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Hero>();
                result = heroRepo.RetrieveHeroesWithPagination(page, itemsPerPage, filter);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Heroes
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Hero))]
        public async Task<ActionResult<Hero>> Post([FromBody] Hero hero)
        {
            try
            {
                hero.HeroID = Guid.NewGuid();
                await heroRepo.CreateAsync(hero);
                return CreatedAtRoute("GetHeroesByID",
                    new
                    {
                        id = hero.HeroID
                    },
                    hero);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Hero))]
        public async Task<ActionResult<Hero>> Put(Guid id, [FromBody] Hero hero)
        {
            try
            {
                var result = await heroRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await heroRepo.UpdateAsync(id, hero);

                return Ok(hero);

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
                var result = await heroRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                await heroRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
