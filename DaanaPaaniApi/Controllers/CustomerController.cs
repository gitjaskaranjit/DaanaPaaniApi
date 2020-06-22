using AutoMapper;
using DaanaPaaniApi;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
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
        private readonly IMapper _mapper;
        private readonly IGeocodeService _geocodeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISieveProcessor _sieveProcessr;

        public CustomerController(IMapper mapper,
                                  IGeocodeService geocodeService,
                                  IUnitOfWork unitOfWork,
                                  ISieveProcessor sieveProcessor)
        {
            _geocodeService = geocodeService;
            _mapper = mapper;
            _sieveProcessr = sieveProcessor;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Get Specific customer")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await CustomerExist(id);
            if (customer == null) return NotFound(new ApiError("Customer not found"));
            return Ok(_mapper.Map<Customer, CustomerDTO>(customer));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [Description("Get the list of all the customers")]
        public async Task<ActionResult<PagedCollection<CustomerDTO>>> GetCustomers([FromQuery] SieveModel sieveModel)
        {
            var customersQuery = _unitOfWork.Customer.GetAllAsync(include: c => c.Include(c => c.Address).Include(c => c.driver), disableTracking: true);
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
            if (await CustomerExist(id) != null)
            {
                var orders = await _mapper.ProjectTo<OrderDTO>(_unitOfWork.Order.GetAllAsync(o => o.customerId == id)).ToListAsync();

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
        public async Task<IActionResult> PostCustomerOrder(int id, [FromBody] OrderDTO orderDTO)
        {
            if (await CustomerExist(id) == null)
            {
                return NotFound(new ApiError("Customer doesn't exist"));
            }
            else
            {
                orderDTO.CustomerId = id;
                var order = _mapper.Map<OrderDTO, Order>(orderDTO);
                var NewOrder = _unitOfWork.Order.Add(order);
                await _unitOfWork.SaveAsync();
                return CreatedAtAction(nameof(GetOrderOfCustomer), new { id = NewOrder.customerId }, NewOrder);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Create a customer")]
        public async Task<IActionResult> PostCustomer([FromBody] CustomerDTO customerDTO)
        {
            if (!PhoneUnique(customerDTO))
            {
                return BadRequest(new ApiError("Phone number already in use"));
            }
            customerDTO.AddedDate = DateTime.Now;
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
            var locationInfo = await _geocodeService.GetLocationInfoAsync(customer.Address);
            if (!_geocodeService.Error)
            {
                var NewCustomer = _unitOfWork.Customer.Add(customer);
                var location = new DaanaPaaniApi.Model.Location
                {
                    LocationPoints = new Point(locationInfo.Items[0].Position.Lat, locationInfo.Items[0].Position.Lng) { SRID = 4326 },
                    placeId = locationInfo.Items[0].Id,
                    formatted_address = locationInfo.Items[0].Title,
                    customer = NewCustomer
                };
                _unitOfWork.Location.Add(location);
                await _unitOfWork.SaveAsync();
                return CreatedAtAction(nameof(GetCustomer), new { id = NewCustomer.CustomerId }, NewCustomer);
            }
            else
            {
                throw new InvalidOperationException("Problem occured check your address");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Set customer to inactive")]
        public async Task<IActionResult> RemoveCustomer([FromRoute] int id)
        {
            var customer = await CustomerExist(id);
            if (customer == null) { return NotFound(new ApiError("Customer not Found")); }
            var orders = _unitOfWork.Order.GetAllAsync(o => o.customerId == id);
            await orders.ForEachAsync(a => a.EndDate = DateTime.Today);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [SwaggerResponse(400, typeof(ApiError))]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description(" Update customer information")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            var customeEntity = await CustomerExist(id);
            if (customeEntity == null)
            {
                return NotFound(new ApiError("Customer not found"));
            };
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO, customeEntity);
            _unitOfWork.Customer.Update(customer);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("locations")]
        [ProducesResponseType(200)]
        [Description("Get the list of all the customers Locations")]
        public ActionResult<IEnumerable<LocationDTO>> GetCustomerLocations([FromQuery] SieveModel sieveModel)
        {
            var LocationsQuery = _unitOfWork.Location.GetAllAsync().AsNoTracking();
            LocationsQuery = _sieveProcessr.Apply(sieveModel, LocationsQuery, applyPagination: false);
            return LocationsQuery.Select((l =>
                new LocationDTO
                {
                    Latitude = l.LocationPoints.X,
                    Longitude = l.LocationPoints.Y,
                    formatted_address = l.formatted_address,
                    customer = new CustomerDTO
                    {
                        CustomerId = l.customer.CustomerId,
                        Fullname = l.customer.Fullname,
                        Email = l.customer.Email,
                        PhoneNumber = l.customer.PhoneNumber,
                        AddedDate = l.customer.AddedDate
                    }
                }
            )).ToList();
        }

        private Task<Customer> CustomerExist(int id)
        {
            var customer = _unitOfWork.Customer.GetFirstOrDefault(c => c.CustomerId == id,
                                                                        include: c => c.Include(c => c.Address).Include(c => c.driver),
                                                                        disableTracking: true);
            return customer;
        }

        private bool PhoneUnique(CustomerDTO customer)
        {
            if (_unitOfWork.Customer.GetAllAsync(c => c.PhoneNumber == customer.PhoneNumber).Any())
            {
                return false;
            }
            return true;
        }
    }
}