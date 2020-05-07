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
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
        {
            
            return Ok( await _mapper.ProjectTo<CustomerDTO>(_customer.getAll()).ToListAsync());
          }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var customer = await  _customer.getById(id);
            if (customer == null) return NotFound(new ApiError("Customer not found"));
            return Ok(_mapper.Map<Customer,CustomerDTO>(customer));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomerDTO customerDTO)
        {
            if (!PhoneUnique(customerDTO))
            {
                return BadRequest(new ApiError("Phone number already in use"));
            }
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
           return Ok(_mapper.Map<Customer,CustomerDTO>(await  _customer.add(customer)));

          
        }
        [HttpPut("{id}")]
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
        public async Task<IActionResult> Remove([FromRoute]int id)
        {
            if (await _customer.delete(id) == null) { return NotFound(new ApiError("Customer not Found")); }
            return NoContent();
        }
        private bool PhoneUnique(CustomerDTO customer)
        {
            if(_customer.getAll().Select(c=>c.PhoneNumber == customer.PhoneNumber).Any())
            {
                return false;
            }
            return true;
        }
    }
}