using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orders;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orders, IMapper mapper)
        {
            _orders = orders;
            _mapper = mapper;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = _orders.getAll();
            return await _mapper.ProjectTo<OrderDTO>(orders).ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _orders.getById(id);

            if (order == null)
            {
                return NotFound(new ApiError("Not found"));
            }

            return _mapper.Map<Order, OrderDTO>(order);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [OpenApiIgnore]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            //if (id != order.OrderId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(order).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrderExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();

            throw new NotImplementedException();
        }

        // POST: api/Order
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [OpenApiIgnore]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            //_context.Orders.Add(order);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
            throw new NotImplementedException();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        [OpenApiIgnore]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            //var order = await _context.Orders.FindAsync(id);
            //if (order == null)
            //{
            //    return NotFound();
            //}

            //_context.Orders.Remove(order);
            //await _context.SaveChangesAsync();

            //return order;

            throw new NotImplementedException();
        }

        private bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}