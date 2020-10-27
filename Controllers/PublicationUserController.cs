using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Resource;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/user/{userId}/publications")]
    public class PublicationUserController : ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationUserController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }
        [SwaggerOperation(
            Summary = "List all Publication by User Id",
            Description = "List of Publication for a User",
            OperationId = "ListAllPublicationsByUser",
            Tags = new[] { "Publications" }
        )]
        [SwaggerResponse(200, "List of Publication for a User", typeof(IEnumerable<PublicationResource>))]
        [HttpGet]
        public async Task<IEnumerable<PublicationResource>> GetAllByUserIdAsync(int userId)
        {
            var publication = await _publicationService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publication);
            return resources;
        }

    }
}
