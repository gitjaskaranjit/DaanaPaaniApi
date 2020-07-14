using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderTempletesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderTempletesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Package
        [HttpGet]
        [Description("Get list of all packages")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<OrderTempleteDTO>>> GetPackages()
        {
            var orderTempletes =  _unitOfWork.OrderTemplete.GetAllAsync();
            return _mapper.ProjectTo<OrderTempleteDTO>(orderTempletes).ToList();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        [SwaggerResponse(404, typeof(ApiError))]
        [ProducesResponseType(200)]
        [Description("Get specific package")]
        public async Task<ActionResult<OrderTempleteDTO>> GetPackage(int id)
        {
            var templete = await _unitOfWork.OrderTemplete.GetFirstOrDefault(p => p.OrderTempleteId == id,
                                                                                include: o=>o.Include(i=>i.OrderTempleteItems).ThenInclude(i=>i.Item),
                                                                      disableTracking: true);
            if (templete == null)
            {
                return NotFound(new ApiError("templete not found"));
            }
            return _mapper.Map<OrderTemplete, OrderTempleteDTO>(templete);
        }

        // PUT: api/Package/5

        [HttpPut("{id}")]
        [Description("Update specific Package")]
        [ProducesResponseType(204)]
        [SwaggerResponse(400, typeof(ApiError))]
        public async Task<IActionResult> PutPackage(int id, OrderTempleteDTO orderTempleteDTO)
        {
            var orderTempleteEntity = await _unitOfWork.OrderTemplete.GetFirstOrDefault(p => p.OrderTempleteId == id);
            if (orderTempleteEntity == null)
            {
                return BadRequest(new ApiError("Package not found"));
            }
            if (id != orderTempleteDTO.OrderTempleteId)
            {
                return BadRequest(new ApiError("Invalid Request"));
            }
            var package = _mapper.Map<OrderTempleteDTO, OrderTemplete>(orderTempleteDTO, orderTempleteEntity);
            _unitOfWork.OrderTemplete.Update(package);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Package
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Description("Create new Package")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<OrderTempleteDTO>> PostPackage(OrderTempleteDTO orderTempleteDTO)
        {
            var templete = _mapper.Map<OrderTemplete>(orderTempleteDTO);
            var NewTemplete = _unitOfWork.OrderTemplete.Add(templete);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetPackage", new { id = NewTemplete.OrderTempleteId }, _mapper.Map<OrderTemplete,OrderTempleteDTO>(NewTemplete));
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<ActionResult<OrderTempleteDTO>> DeletePackage(int id)
        {
            var orderTempleteEntity = await _unitOfWork.OrderTemplete.GetFirstOrDefault(p => p.OrderTempleteId == id);
            if (orderTempleteEntity == null)
            {
                return NotFound(new ApiError("Package not found"));
            }

            _unitOfWork.OrderTemplete.Delete(id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}