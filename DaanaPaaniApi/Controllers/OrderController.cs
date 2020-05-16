using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("Get list of orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = _orders.getAll();
            return await _mapper.ProjectTo<OrderDTO>(orders).ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        [Description("Get specific order")]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _orders.getById(id);

            if (order == null)
            {
                return NotFound(new ApiError("Not found"));
            }

            return _mapper.Map<Order, OrderDTO>(order);
        }

        // DELETE: /Order/5
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
    }
}