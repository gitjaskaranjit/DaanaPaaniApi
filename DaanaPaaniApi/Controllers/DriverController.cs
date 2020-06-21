using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDTO>>> GetDrivers()
        {
            var drivers = _unitOfWork.Driver.GetAllAsync(include: d => d.Include(d => d.driverAddress),
                                                        disableTracking: true);
            return await _mapper.ProjectTo<DriverDTO>(drivers).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<DriverDTO> GetDriver(int id)
        {
            var driver = await _unitOfWork.Driver.GetFirstOrDefault(d => d.DriverId == id,
                                                               include: d => d.Include(d => d.driverAddress),
                                                               disableTracking: true);
            return _mapper.Map<Driver, DriverDTO>(driver);
        }

        [HttpPost]
        public async Task<IActionResult> PostDriver([FromBody] DriverDTO driverDTO)
        {
            var driver = _mapper.Map<DriverDTO, Driver>(driverDTO);
            var NewDriver = _unitOfWork.Driver.Add(driver);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetDriver), new { id = NewDriver.DriverId }, NewDriver);
        }

        [HttpPut("{id}")]
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