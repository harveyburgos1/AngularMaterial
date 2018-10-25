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
    public class ItemsController : ControllerBase
    {
        private IItemRepository itemRepo;

        public ItemsController(IItemRepository itemRepo)
        {
            this.itemRepo = itemRepo;
        }
        // GET: api/Items
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Item>))]
        public ActionResult<IEnumerable<Item>> Get()
        {

            return Ok(itemRepo.Retrieve().ToList());
        }

        // GET: api/Items/5
        [HttpGet("{id}", Name = "GetItemsByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Item))]
        public async Task<ActionResult<Item>> Get(Guid id)
        {
            try
            {
                var result = await itemRepo.RetrieveAsync(id);
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

        [HttpGet("{page}/{itemsPerPage}", Name = "GetItemsWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Item>))]
        public ActionResult<PaginationResult<Item>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Item>();
                result = itemRepo.RetrieveItemWithPagination(page, itemsPerPage, filter);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Items
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Item))]
        public async Task<ActionResult<Item>> Post([FromBody] Item item)
        {
            try
            {
                item.ItemID = Guid.NewGuid();
                await itemRepo.CreateAsync(item);
                return CreatedAtRoute("GetItemsByID",
                    new
                    {
                        id = item.ItemID
                    },
                    item);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Item))]
        public async Task<ActionResult<Item>> Put(Guid id, [FromBody] Item item)
        {
            try
            {
                var result = await itemRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await itemRepo.UpdateAsync(id, item);

                return Ok(item);

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
                var result = await itemRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                await itemRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
