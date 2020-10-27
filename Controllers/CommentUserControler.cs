using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Homemade.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Homemade.Resource;
using Homemade.Domain.Models;

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/user/{userId}/comments")]
    public class CommentUserControler : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentUserControler(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [SwaggerOperation(
            Summary = "List all Comment by User Id",
            Description = "List of Comment for a User",
            OperationId = "ListAllCommentsByUser",
            Tags = new[] { "Comments" }
        )]
        [SwaggerResponse(200, "List of Comment for a User", typeof(IEnumerable<CommentResource>))]
        [HttpGet("userId")]
        public async Task<IEnumerable<CommentResource>> GetAllByUserIdAsync(int userId)
        {
            var comment = await _commentService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Comment>, IEnumerable<CommentResource>>(comment);
            return resources;
        }
    }
}
