using CQRS_lib.CQRS.Commands;
using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data.Models;
using CQRS_lib.Reos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CQRS_21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _repo;
        private readonly IMediator _mediator;

        public ItemsController(IItemsRepo repo,IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            ///var items = _repo.GetItems();
            
            var result = await _mediator.Send(new GetAllItemsQuery());

            return Ok(result);
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public ActionResult<Items> GetById(int id)
        {
            var item = _repo.GetItems(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Items item)
        {
            //var result = _repo.InsertItem(item);
            //if (result > 0)
            //    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);

            //return BadRequest("Could not insert item.");

            var result = await _mediator.Send(new InsertItemsCommand(item));

            return Ok(result);
        }

        // PUT: api/items/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Items item)
        {
            if (id != item.Id)
                return BadRequest("ID mismatch.");

            var result = _repo.UpdateItem(item);
            if (result > 0)
                return NoContent();

            return NotFound("Item not found.");
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repo.DeleteItem(id);
            if (result > 0)
                return NoContent();

            return NotFound("Item not found.");
        }
    }
}
