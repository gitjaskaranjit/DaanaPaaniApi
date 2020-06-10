using AutoMapper;
using DaanaPaaniApi;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace DaaniPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customers;
        private readonly IMapper _mapper;
        private readonly IOrderService _orders;
        private readonly ISieveProcessor _sieveProcessr;

        public CustomerController(IMapper mapper,
                                  ICustomerService customer,
                                  IOrderService orders,
                                  ISieveProcessor sieveProcessor)
        {
            _customers = customer;
            _mapper = mapper;
            _orders = orders;
            _sieveProcessr = sieveProcessor;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Get Specific customer")]
        public async Task<IActionResult> GetCustomer([FromRoute]int id)
        {
            var customer = await _customers.getById(id);
            if (customer == null) return NotFound(new ApiError("Customer not found"));
            return Ok(_mapper.Map<Customer, CustomerDTO>(customer));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [SwaggerResponse(400, typeof(ApiError))]
        [Description("Get the list of all the customers")]
        public async Task<ActionResult<PagedCollection<CustomerDTO>>> GetCustomers([FromQuery]SieveModel sieveModel)
        {
            var customersQuery = _customers.getAll().AsNoTracking();
           customersQuery = _sieveProcessr.Apply(sieveModel, customersQuery, applyPagination: false);
            var totalSize = customersQuery.Count();
            customersQuery = _sieveProcessr.Apply(sieveModel, customersQuery, applySorting: false, applyFiltering: false);
            var customers = await _mapper.ProjectTo<CustomerDTO>(customersQuery).ToListAsync();

            return new PagedCollection<CustomerDTO>
            {
                Page = sieveModel.Page,
                PageSize = sieveModel.PageSize,
                TotalSize = totalSize,
                Items = customers


            };
        }

        [HttpGet("{id}/order")]
        [ProducesResponseType(200)]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Get the orders of specific customer")]
        public async Task<ActionResult<OrderDTO>> GetOrderOfCustomer(int id)
        {
            if (CustomerExist(id))
            {
                var orders = await _mapper.ProjectTo<OrderDTO>(_orders.getAll().Where(o => o.customerId == id)).ToListAsync();

                return Ok(orders);
            }
            else
            {
                return NotFound(new ApiError("Customer doesn't exist"));
            }
        }

        [HttpPost("{id}/order")]
        [ProducesResponseType(201)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Create order for specific customer")]
        public async Task<IActionResult> PostCustomerOrder(int id, [FromBody]OrderDTO orderDTO)
        {
            if (CustomerExist(id))
            {
                orderDTO.CustomerId = id;
                var order = _mapper.Map<OrderDTO, Order>(orderDTO);
                var addedOrder = _mapper.Map<Order, OrderDTO>(await _orders.add(order));
                return CreatedAtAction(nameof(GetOrderOfCustomer), new { id = addedOrder.CustomerId }, addedOrder);
            }
            else
            {
                return NotFound(new ApiError("Customer doesn't exist"));
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Create a customer")]
        public async Task<IActionResult> PostCustomer([FromBody]CustomerDTO customerDTO)
        {
            if (!PhoneUnique(customerDTO))
            {
                return BadRequest(new ApiError("Phone number already in use"));
            }
            customerDTO.AddedDate = DateTime.Now;
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            var addedCustomer = _mapper.Map<Customer, CustomerDTO>(await _customers.add(customer));
            return CreatedAtAction(nameof(GetCustomer), new { id = addedCustomer.CustomerId }, addedCustomer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Set customer to inactive")]
        public async Task<IActionResult> RemoveCustomer([FromRoute]int id)
        {
            var customer = await _customers.getById(id);
            if (customer == null) { return NotFound(new ApiError("Customer not Found")); }
            _customers.delete(customer); return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description(" Update customer information")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            var customeEntity = await _customers.getById(id);
            if (customeEntity == null)
            {
                return NotFound(new ApiError("Customer not found"));
            };
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO, customeEntity);
           await _customers.update(id, customer);
            return NoContent();
        }

        private bool CustomerExist(int id)
        {
            var customer = _customers.getById(id).Result;
            if (customer == null)
            {
                return false;
            }
            return true;
        }

        private bool PhoneUnique(CustomerDTO customer)
        {
            if (_customers.getAll().Where(c => c.PhoneNumber == customer.PhoneNumber).Any())
            {
                return false;
            }
            return true;
        }
    }
}