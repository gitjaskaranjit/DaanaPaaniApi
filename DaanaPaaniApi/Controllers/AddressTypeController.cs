using AutoMapper;
using DaanaPaaniApi.DTOs;
using DaanaPaaniApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private readonly IAddressTypeService _addressType;
        private readonly IMapper _mapper;

        public AddressTypeController(IAddressTypeService addressType, IMapper mapper)
        {
            _addressType = addressType;
            _mapper = mapper;
        }

        // GET: /AddressType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressTypeDTO>>> GetAddressTypes()
        {
            var addressType = _addressType.getAll();
            return await _mapper.ProjectTo<AddressTypeDTO>(addressType).ToListAsync();
        }

        // GET: /AddressType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressTypeDTO>> GetAddressType(int id)
        {
            var addressType = await _addressType.getById(id);

            if (addressType == null)
            {
                return NotFound(new ApiError("Not Found"));
            }

            return _mapper.Map<AddressTypeDTO>(addressType);
        }
    }
}