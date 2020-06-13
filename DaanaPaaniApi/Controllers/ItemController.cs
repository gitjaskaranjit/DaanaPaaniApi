﻿using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepository<Item> _item;
        private readonly IMapper _mapper;

        public ItemController(IRepository<Item> item, IMapper mapper)
        {
            _item = item;
            _mapper = mapper;
        }

        // GET: /Item
        [HttpGet]
        [ProducesResponseType(200)]
        [Description("Get list of items")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return Ok(await _mapper.ProjectTo<ItemDTO>(_item.getAll()).ToListAsync());
        }

        // GET: /Item/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Get specific item")]
        public async Task<ActionResult<ItemDTO>> GetItem(int id)
        {
            var item = await _item.getById(id);

            if (item == null)
            {
                return NotFound(new ApiError("Item not found"));
            }

            return _mapper.Map<Item, ItemDTO>(item);
        }

        // PUT: /Item/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [ProducesResponseType(204)]
        [Description("Update item information")]
        public async Task<IActionResult> PutItem(int id, ItemDTO itemDTO)
        {
            var itemEntity = await _item.getById(id);
            if (itemEntity == null)
            {
                return NotFound(new ApiError("Item doesn't exist"));
            }
            if (id != itemDTO.ItemId)
            {
                return BadRequest(new ApiError("Invalid parameters"));
            }
            var item = _mapper.Map<ItemDTO, Item>(itemDTO, itemEntity);

            await _item.update(id, item);

            return NoContent();
        }

        // POST: /Item
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [SwaggerResponse(400, typeof(ApiError))]
        [ProducesResponseType(201)]
        [Description("Create new item")]
        public async Task<ActionResult<Item>> PostItem(ItemDTO itemDTO)
        {
            var item = _mapper.Map<ItemDTO, Item>(itemDTO);
            var addedItem = _mapper.Map<Item, ItemDTO>(await _item.add(item));
            return CreatedAtAction("GetItem", new { id = addedItem.ItemId }, addedItem);
        }

        // DELETE:/Item/5
        [HttpDelete("{id}")]
        [SwaggerResponse(404, typeof(ApiError))]
        [ProducesResponseType(204)]
        [Description("Delete item (Not Recommended)")]
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