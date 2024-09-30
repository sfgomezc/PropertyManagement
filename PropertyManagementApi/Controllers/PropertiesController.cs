using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementApi.DTOs;
using PropertyManagementApi.Models;
using PropertyManagementApi.Services;

namespace PropertyManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertyService propertyService, IMapper mapper)
        {
            _propertyService = propertyService;
            _mapper = mapper;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            var propertyDTOs = _mapper.Map<IEnumerable<PropertyDTO>>(properties);
            return Ok(propertyDTOs);
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDTO>> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            var propertyDTO = _mapper.Map<PropertyDTO>(property);
            return Ok(propertyDTO);
        }

        // POST: api/Properties
        [HttpPost]
        public async Task<ActionResult<PropertyDTO>> CreateProperty(PropertyDTO propertyDTO)
        {
            var property = _mapper.Map<Property>(propertyDTO);
            var createdProperty = await _propertyService.CreatePropertyAsync(property);
            var createdPropertyDTO = _mapper.Map<PropertyDTO>(createdProperty);

            return CreatedAtAction(nameof(GetProperty), new { id = createdPropertyDTO.PropertyID }, createdPropertyDTO);
        }

        // PUT: api/Properties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyDTO propertyDTO)
        {
            if (id != propertyDTO.PropertyID)
            {
                return BadRequest("Property ID mismatch");
            }

            var property = _mapper.Map<Property>(propertyDTO);
            var updatedProperty = await _propertyService.UpdatePropertyAsync(id, property);

            if (updatedProperty == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await _propertyService.DeletePropertyAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}