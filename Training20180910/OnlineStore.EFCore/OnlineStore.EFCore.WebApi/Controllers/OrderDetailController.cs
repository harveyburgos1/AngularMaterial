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
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository orderDetailRepo;




        public OrderDetailController(IOrderDetailRepository orderDetailRepo)
        {
            this.orderDetailRepo = orderDetailRepo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(OrderDetail[]))]
        public IEnumerable<OrderDetail> Get()
        {
            return orderDetailRepo.Retrieve().ToList();
        }

        // GET: api/OrderDetail/5
        [HttpGet("{id}", Name = "GetOrderDetailByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(OrderDetail))]
        public ActionResult<OrderDetail> Get(Guid id)
        {
            try
            {
                var result = orderDetailRepo.GetOrderDetailsWithForeignKey(id);
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

        // POST: api/OrderDetail
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(OrderDetail))]
        public async Task<ActionResult<OrderDetail>> Post([FromBody] OrderDetail orderDetail)
        {
            try
            {
                orderDetail.OrderDetailID = Guid.NewGuid();
                await orderDetailRepo.CreateAsync(orderDetail);
                return CreatedAtRoute("GetOrderDetailByID",
                    new
                    {
                        id = orderDetail.OrderDetailID
                    },
                    orderDetail);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/OrderDetail/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(OrderDetail))]
        public async Task<ActionResult<OrderDetail>> Put(Guid id, [FromBody] OrderDetail orderDetail)
        {
            try
            {
                var result = await orderDetailRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await orderDetailRepo.UpdateAsync(id, orderDetail);

                return Ok(orderDetail);

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
                var result = await orderDetailRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                await orderDetailRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
