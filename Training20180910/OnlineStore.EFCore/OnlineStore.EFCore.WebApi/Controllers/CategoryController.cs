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
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepo;
        
        public CategoryController(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        // GET: api/Category
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Category>))]
        public ActionResult<IEnumerable<Category>> Get()
        {

            return Ok(categoryRepo.Retrieve().ToList());
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategoryByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Category))]
        public async Task<ActionResult<Category>> Get(Guid id)
        {
            try
            {
                var result = await categoryRepo.RetrieveAsync(id);
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
        [HttpGet("{page}/{itemsPerPage}", Name = "GetCategoryWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Category>))]
        public ActionResult<PaginationResult<Category>> Get(int page, int itemsPerPage,string filter)
        {
            try
            {
                var result = new PaginationResult<Category>();
                result = categoryRepo.RetrieveCategoryWithValidation(page, itemsPerPage,filter);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Category
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Category))]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            try
            {
                category.CategoryID = Guid.NewGuid();
                await categoryRepo.CreateAsync(category);
                return CreatedAtRoute("GetCategoryByID",
                    new
                    {
                        id = category.CategoryID
                    },
                    category);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Category))]
        public async Task<ActionResult<Category>> Put(Guid id, [FromBody] Category category)
        {
            try
            {
                var result = await categoryRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await categoryRepo.UpdateAsync(id, category);

                return Ok(category);

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
                var result = await categoryRepo.RetrieveAsync(id);
                if(result == null)
                {
                    return NotFound();
                }

                await categoryRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
