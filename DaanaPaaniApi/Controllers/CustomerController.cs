using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DaanaPaaniApi;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DaaniPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;
       
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper, ICustomerService customer)
        {
            _customer = customer;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PagedCollection<CustomerDTO>>> Get(
                                                                            [FromQuery]PagingOptions pagingOptions = null,
                                                                            [FromQuery]SortingOptions<CustomerDTO,Customer> sortingOptions = null,
                                                                            [FromQuery] SearchOptions<CustomerDTO,Customer> searchOptions = null
                                                                             )
        {
            pagingOptions.Limit = pagingOptions.Limit ?? 10;
            pagingOptions.Offset = pagingOptions.Offset ?? 0;
            var customersQuery = _customer.getAll();

            customersQuery = sortingOptions.Apply(customersQuery);
            customersQuery = searchOptions.Apply(customersQuery);
            var customers =  await _mapper.ProjectTo<CustomerDTO>(customersQuery).ToListAsync();

            var pagedCollection = new PagedCollection<CustomerDTO>
            {
                Offset = pagingOptions.Offset.Value,
                Limit = pagingOptions.Limit.Value,
                Size = customers.Count,
                Items = customers.Skip(pagingOptions.Offset.Value)
                                 .Take(pagingOptions.Limit.Value)
            };
            return pagedCollection;
          }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var customer = await  _customer.getById(id);
            if (customer == null) return NotFound(new ApiError("Customer not found"));
            return Ok(_mapper.Map<Customer,CustomerDTO>(customer));
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Post([FromBody]CustomerDTO customerDTO)
        {
            if (!PhoneUnique(customerDTO))
            {
                return BadRequest(new ApiError("Phone number already in use"));
            }
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            var addedCustomer = _mapper.Map<Customer, CustomerDTO>(await _customer.add(customer));
            return CreatedAtAction(nameof(GetById), new { id = addedCustomer.CustomerId }, addedCustomer);

          
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, CustomerDTO customerDTO)
        {
            var customeEntity =    await _customer.getById(id);
            if (customeEntity == null)
            {
                return NotFound(new ApiError("Customer not found"));
            };
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO,customeEntity);
           var updatedCustomer =  await _customer.update(id, customer);
            return NoContent();
    }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            var customer = await  _customer.getById(id);
            if (customer == null) { return NotFound(new ApiError("Customer not Found")); }
            _customer.delete(customer);
            return NoContent();
        }
        private bool PhoneUnique(CustomerDTO customer)
        {
            if (_customer.getAll().Where(c => c.PhoneNumber == customer.PhoneNumber).Any())
            {
                return false;
            }
            return true;
        }
    }
}