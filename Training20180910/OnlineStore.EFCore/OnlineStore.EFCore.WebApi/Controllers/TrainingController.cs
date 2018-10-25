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
    public class TrainingController : ControllerBase
    {
        private ITrainingRepository trainingRepo;

        public TrainingController(ITrainingRepository trainingRepo)
        {
            this.trainingRepo = trainingRepo;
        }
        // GET: api/Training
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Training>))]
        public ActionResult<IEnumerable<Training>> Get()
        {

            return Ok(trainingRepo.Retrieve().ToList());
        }

        // GET: api/Training/5
        [HttpGet("{id}", Name = "GetTrainingByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Training))]
        public async Task<ActionResult<Training>> Get(Guid id)
        {
            try
            {
                var result = await trainingRepo.RetrieveAsync(id);
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
 

        // POST: api/Training
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Training))]
        public async Task<ActionResult<Training>> Post([FromBody] Training training)
        {
            try
            {
                training.TrainingID = Guid.NewGuid();
                await trainingRepo.CreateAsync(training);
                return CreatedAtRoute("GetTrainingByID",
                    new
                    {
                        id = training.TrainingID
                    },
                    training);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Training/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Training))]
        public async Task<ActionResult<Training>> Put(Guid id, [FromBody] Training training)
        {
            try
            {
                var result = await trainingRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                await trainingRepo.UpdateAsync(id, training);

                return Ok(training);

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
                var result = await trainingRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                await trainingRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
