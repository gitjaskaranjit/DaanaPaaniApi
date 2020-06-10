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
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _package;
        private readonly IMapper _mapper;

        public PackageController(IPackageService package, IMapper mapper)
        {
            _package = package;
            _mapper = mapper;
        }

        // GET: api/Package
        [HttpGet]
        [Description("Get list of all packages")]
        public async Task<ActionResult<IEnumerable<PackageDTO>>> GetPackages()
        {
            var packages = _package.getAll();
            return await _mapper.ProjectTo<PackageDTO>(packages).ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        [SwaggerResponse(404, typeof(ApiError))]
        [Description("Get specific package")]
        public async Task<ActionResult<PackageDTO>> GetPackage(int id)
        {
            var package = await _package.getById(id);
            if (package == null)
            {
                return NotFound(new ApiError("Package not found"));
            }
            return _mapper.Map<Package, PackageDTO>(package);
        }

        // PUT: api/Package/5
        
        [HttpPut("{id}")]
        [OpenApiIgnore]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.PackageId)
            {
                return BadRequest();
            }

            //_context.Entry(package).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PackageExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            throw new NotImplementedException();
        }

        // POST: api/Package
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Description("Create new Package")]
        public async Task<ActionResult<PackageDTO>> PostPackage(PackageDTO package)
        {
            var pack = _mapper.Map<Package>(package);
           var newPackage =   await _package.add(pack);


            return CreatedAtAction("GetPackage", new { id = newPackage.PackageId }, _mapper.Map<PackageDTO>(newPackage));
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        [OpenApiIgnore]
        public async Task<ActionResult<Package>> DeletePackage(int id)
        {
            //    var package = await _context.Packages.FindAsync(id);
            //    if (package == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Packages.Remove(package);
            //    await _context.SaveChangesAsync();

            //    return package;
            throw new NotImplementedException();
        }
    }
}