using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISieveProcessor _sieveProcessor;

        public OrdersController(IUnitOfWork unitOfWork,
                               IMapper mapper,
                               ISieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        // GET: api/Order
        [HttpGet]
        [Description("Get list of orders")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders([FromQuery] SieveModel sieveModel)
        {
            var ordersQuery = _unitOfWork.Order.GetAllAsync(include: o => o.Include(o => o.Discount).Include(o=>o.OrderItems).ThenInclude(o=>o.Item));
            ordersQuery = _sieveProcessor.Apply(sieveModel, ordersQuery, applyPagination: false);
            var orders = await _mapper.ProjectTo<OrderDTO>(ordersQuery).ToListAsync();

            return orders;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        [Description("Get specific order")]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _unitOfWork.Order.GetFirstOrDefault(o => o.OrderId == id, include: o => o.Include(o => o.Discount).Include(o=>o.OrderItems).ThenInclude(o => o.Item));

            if (order == null)
            {
                return NotFound(new ApiError("Not found"));
            }

            return _mapper.Map<Order, OrderDTO>(order);
        }

        [HttpPut("{id}")]
        [Description("Update specific order")]
        [ProducesResponseType(204)]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO orderDTO)
        {
            var orderEntity = await _unitOfWork.Order.GetFirstOrDefault(o => o.OrderId == id,
                                                                        include: o => o.Include(o => o.Discount));
            if (orderEntity == null)
            {
                return NotFound(new ApiError("Order not found"));
            }
            if (orderDTO.OrderId != id)
            {
                return BadRequest(new ApiError("Invalid request"));
            }
            var order = _mapper.Map<OrderDTO, Order>(orderDTO, orderEntity);
            _unitOfWork.Order.Update(order);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // DELETE: /Order/5
        [HttpDelete("{id}")]
        [Description("Delete Specific order")]
        [ProducesResponseType(204)]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _unitOfWork.Order.GetFirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            _unitOfWork.Order.Delete(id);
            try
            {
                await _unitOfWork.SaveAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Delete exception " + ex.InnerException.Message);
            }
           
            return NoContent();
        }
    }
}