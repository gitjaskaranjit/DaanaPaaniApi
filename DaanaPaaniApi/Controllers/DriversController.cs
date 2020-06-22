using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriversController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Description("Get List of all drivers")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<DriverDTO>>> GetDrivers()
        {
            var drivers = _unitOfWork.Driver.GetAllAsync(include: d => d.Include(d => d.driverAddress),
                                                        disableTracking: true);
            return await _mapper.ProjectTo<DriverDTO>(drivers).ToListAsync();
        }

        [HttpGet("{id}")]
        [Description("Get Specific driver")]
        [ProducesResponseType(200)]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<ActionResult<DriverDTO>> GetDriver(int id)
        {
            var driver = await _unitOfWork.Driver.GetFirstOrDefault(d => d.DriverId == id,
                                                               include: d => d.Include(d => d.driverAddress),
                                                               disableTracking: true);
            if(driver == null)
            {
                return NotFound(new ApiError("Driver not found"));
            }
            return _mapper.Map<Driver, DriverDTO>(driver);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerResponse(400,typeof(ApiError))]
        [Description("Create new driver")]
        public async Task<IActionResult> PostDriver([FromBody] DriverDTO driverDTO)
        {
            var driver = _mapper.Map<DriverDTO, Driver>(driverDTO);
            var NewDriver = _unitOfWork.Driver.Add(driver);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetDriver), new { id = NewDriver.DriverId }, NewDriver);
        }

        [HttpPut("{id}")]
        [Description("Update specific Driver")]
        [ProducesResponseType(204)]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<IActionResult> PutDriver(int id, [FromBody] DriverDTO driverDTO)
        {
            var driverEntity = await _unitOfWork.Driver.GetFirstOrDefault(d => d.DriverId == id,
                                                                include: d => d.Include(d => d.driverAddress),
                                                                disableTracking: true);
            if (driverEntity == null) return NotFound(new ApiError("Driver not found"));

            var driver = _mapper.Map<DriverDTO, Driver>(driverDTO, driverEntity);
            _unitOfWork.Driver.Update(driver);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Description("Delete specific Driver")]
        [ProducesResponseType(204)]
        [SwaggerResponse(404, typeof(ApiError))]
        public async Task<IActionResult> Delete(int id)
        {
            var driverEntity = await _unitOfWork.Driver.GetFirstOrDefault(d => d.DriverId == id,
                                                                include: d => d.Include(d => d.driverAddress),
                                                                disableTracking: true);
            if (driverEntity == null) return NotFound(new ApiError("Driver not found"));
            _unitOfWork.Driver.Delete(id);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}