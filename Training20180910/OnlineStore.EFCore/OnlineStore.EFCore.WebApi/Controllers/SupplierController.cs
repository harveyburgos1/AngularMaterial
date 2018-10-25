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
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository supplierRepo;
        public SupplierController(ISupplierRepository supplierRepo)
        {
            this.supplierRepo = supplierRepo;
        }
        // GET: api/Supplier
        [HttpGet]
        public ActionResult<Supplier> Get()
        {
            return Ok(supplierRepo.Retrieve());
        }

        // GET: api/Supplier/5
        [HttpGet("{id}", Name = "GetBySupplierID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(List<Supplier>))]
        public async Task<ActionResult<Supplier>> Get(int id)
        {
            try
            {
                var result = await supplierRepo.RetrieveAsync(id);
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

        [HttpGet("{page}/{itemsPerPage}", Name = "GetSupplierWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Supplier>))]
        public ActionResult<PaginationResult<Supplier>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Supplier>();
                result = supplierRepo.RetrieveSupplierWithPagination(page, itemsPerPage, filter);
                return Ok(result);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Supplier
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Supplier))]
        public async Task<ActionResult<Supplier>> Post([FromBody] Supplier supplier)
        {
            try
            {
                supplier.SupplierID = Guid.NewGuid();
                await supplierRepo.CreateAsync(supplier);
                return CreatedAtRoute("GetBySupplierID",
                    new
                    {
                        id = supplier.SupplierID
                    },
                    supplier);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Supplier/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Supplier))]
        public async Task<ActionResult<Supplier>> Put(Guid id, [FromBody] Supplier supplier)
        {
            try
            {
                var result = await supplierRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await supplierRepo.UpdateAsync(id, supplier);
                return Ok(supplier);
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
        public async Task<ActionResult<Supplier>> Delete(Guid id)
        {
            try
            {
                var result = supplierRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await supplierRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
