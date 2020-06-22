﻿using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using ProjNet.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PackagesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Package
        [HttpGet]
        [Description("Get list of all packages")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<PackageDTO>>> GetPackages()
        {
            var packages = _unitOfWork.Package.GetAllAsync(include: s => s.Include(p => p.PackageItems).ThenInclude(p => p.Item),
                                                           disableTracking: true);
            return await _mapper.ProjectTo<PackageDTO>(packages).ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        [SwaggerResponse(404, typeof(ApiError))]
        [ProducesResponseType(200)]
        [Description("Get specific package")]
        public async Task<ActionResult<PackageDTO>> GetPackage(int id)
        {
            var package = await _unitOfWork.Package.GetFirstOrDefault(p => p.PackageId == id,
                                                                      include: s => s.Include(p => p.PackageItems).ThenInclude(p => p.Item),
                                                                      disableTracking: true);
            if (package == null)
            {
                return NotFound(new ApiError("Package not found"));
            }
            return _mapper.Map<Package, PackageDTO>(package);
        }

        // PUT: api/Package/5

        [HttpPut("{id}")]
        [Description("Update specific Package")]
        [ProducesResponseType(204)]
        [SwaggerResponse(400, typeof(ApiError))]
        public async Task<IActionResult> PutPackage(int id, PackageDTO packageDTO)
        {
            var packageEntity = await _unitOfWork.Package.GetFirstOrDefault(p => p.PackageId == id);
            if (packageEntity == null)
            {
                return BadRequest(new ApiError("Package not found"));
            }
            if (id != packageDTO.PackageId)
            {
                return BadRequest(new ApiError("Invalid Request"));
            }
            var package = _mapper.Map<PackageDTO, Package>(packageDTO, packageEntity);
            _unitOfWork.Package.Update(package);

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
        public async Task<ActionResult<PackageDTO>> PostPackage(PackageDTO packageDTO)
        {
            var package = _mapper.Map<Package>(packageDTO);
            var NewPackage = _unitOfWork.Package.Add(package);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetPackage", new { id = NewPackage.PackageId }, NewPackage);
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [SwaggerResponse(404,typeof(ApiError))]
        public async Task<ActionResult<Package>> DeletePackage(int id)
        {
            var packageEntity = await _unitOfWork.Package.GetFirstOrDefault(p => p.PackageId == id);
            if (packageEntity == null)
            {
                return NotFound(new ApiError("Package not found"));
            }

            _unitOfWork.Package.Delete(id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}