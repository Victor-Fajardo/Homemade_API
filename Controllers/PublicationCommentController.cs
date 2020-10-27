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
    [Route("/api/publications/{publicationId}/comments")]
    public class PublicationCommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public PublicationCommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [SwaggerOperation(
            Summary = "List all Comment by Publication Id",
            Description = "List of Comment for a Publication",
            OperationId = "ListAllCommentsByPublication",
            Tags = new[] { "Comments" }
        )]
        [SwaggerResponse(200, "List of Comment for a Publication", typeof(IEnumerable<CommentResource>))]
        [HttpGet("userId")]
        public async Task<IEnumerable<CommentResource>> GetAllByPublicationIdAsync(int userId)
        {
            var comment = await _commentService.ListByPublicationIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comment);
            return resources;
        }
    }
}
