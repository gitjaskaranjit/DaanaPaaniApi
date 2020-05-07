using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaanaPaaniApi;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using AutoMapper;
using DaanaPaaniApi.DTOs;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _item;
        private readonly IMapper _mapper;
        public ItemController(IItemService item, IMapper mapper)
        {
            _item = item;
            _mapper = mapper;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return Ok( await _mapper.ProjectTo<ItemDTO>(_item.getAll()).ToListAsync());
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            var item = await _item.getById(id);

            if (item == null)
            {
                return NotFound(new ApiError("Item not found"));
            }

            return _mapper.Map<Item,ItemDTO>(item);
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemDTO itemDTO)
        {
            var itemEntity = await _item.getById(id);
            if(itemEntity == null)
            {
                return NotFound(new ApiError("Item doesn't exist"));
            }
            if (id != itemDTO.ItemId)
            {
                return BadRequest(new ApiError("Invalid parameters"));
            }
            var item = _mapper.Map<ItemDTO, Item>(itemDTO,itemEntity);

            await _item.update(id,item);

            return NoContent();
        }

        // POST: api/Item
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
        {
           var item =  _mapper.Map<ItemDTO, Item>(itemDTO);
            var addedItem = await _item.add(item);

            return CreatedAtAction("GetItem", new { id = addedItem.ItemId}, addedItem);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var item = await _item.getById(id);
            if (item == null)
            {
                return NotFound();
            }

            _item.delete(item);
             return NoContent();
        }

    }
}
