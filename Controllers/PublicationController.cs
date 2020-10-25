using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Extensions;
using Homemade.Resource;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Create a Publication",
            Description = "Create a Publication",
            OperationId = "CreatePublication",
            Tags = new[] { "Publications" }
        )]
        [SwaggerResponse(200, "Publication was created", typeof(PublicationResource))]
        [HttpPost("userId")]
        public async Task<IActionResult> PostAsync([FromBody] SavePublicationResource resource, int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);

            var result = await _publicationService.SaveAsync(publication, userId);

            if (!result.Succes)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);

            return Ok(publicationResource);
        }

        [SwaggerOperation(
            Summary = "Update a Publication",
            Description = "Update a Publication",
            OperationId = "UpdatePublication",
            Tags = new[] { "Publications" }
        )]
        [SwaggerResponse(200, "Publication was updated", typeof(PublicationResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePublicationResource resource)
        {
            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, publication);

            if (!result.Succes)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Publication",
            Description = "Delete a Publication",
            OperationId = "DeletePublication",
            Tags = new[] { "Publications" }
        )]
        [SwaggerResponse(200, "Publication was delete", typeof(PublicationResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _publicationService.Delete(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
    }
}
