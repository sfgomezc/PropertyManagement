using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManagementApi.Application.DTOs;
using PropertyManagementApi.Application.Contracts;

namespace PropertyManagementApi.Controllers.V1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDTO>>> GetProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return Ok(properties);
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDTO>> GetProperty(int id)
        {
            var propertyDTO = await _propertyService.GetPropertyByIdAsync(id);

            if (propertyDTO == null)
            {
                return NotFound();
            }

            return Ok(propertyDTO);
        }

        // POST: api/Properties
        [HttpPost]
        public async Task<ActionResult<PropertyDTO>> CreateProperty(PropertyDTO propertyDTO)
        {
            var createdProperty = await _propertyService.CreatePropertyAsync(propertyDTO);

            return CreatedAtAction(nameof(GetProperty), new { id = createdProperty.PropertyID }, createdProperty);
        }

        // PUT: api/Properties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyDTO propertyDTO)
        {
            if (id != propertyDTO.PropertyID)
            {
                return BadRequest("Property ID mismatch");
            }

            var updatedProperty = await _propertyService.UpdatePropertyAsync(id, propertyDTO);

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