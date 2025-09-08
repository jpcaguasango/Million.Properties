using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Million.Properties.Domain.Interfaces;
using Million.Properties.WebApi.Dtos;

namespace Million.Properties.WebApi.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesController(IPropertiesService propertiesService, IMapper mapper) : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult> GetProperties(
            CancellationToken cancellationToken)
        {
            var result = await propertiesService.GetProperties();
            
            return Ok(mapper.Map<List<PropertyDto>>(result));
        }
        
        [HttpGet("populate")]
        public async Task<ActionResult> PopulateProperties(
            CancellationToken cancellationToken)
        {
            var result = await propertiesService.PopulateProperties();
            
            return Ok(mapper.Map<List<PropertyDto>>(result));
        }
    }
}
