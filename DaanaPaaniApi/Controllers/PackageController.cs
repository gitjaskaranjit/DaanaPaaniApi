using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaanaPaaniApi;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using AutoMapper;
using DaanaPaaniApi.DTOs;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _package;
        private readonly IMapper _mapper;

        public PackageController(IPackageService package,IMapper mapper)
        {
            _package = package;
            _mapper = mapper;
        }

        // GET: api/Package
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageDTO>>> GetPackages()
        {
            var packages = _package.getAll();
            return await _mapper.ProjectTo<PackageDTO>(packages).ToListAsync();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDTO>> GetPackage(int id)
        {
            var package = await _package.getById(id);
            if (package == null)
            {
                return NotFound();
            }
            return _mapper.Map<Package, PackageDTO>(package) ;
        }

        // PUT: api/Package/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            //if (id != package.PackageId)
            //{
            //    return BadRequest();
            //}

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
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
            //_context.Packages.Add(package);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPackage", new { id = package.PackageId }, package);
            throw new NotImplementedException();
        }

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
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
