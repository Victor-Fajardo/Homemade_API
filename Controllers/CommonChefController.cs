using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Extensions;
using Homemade.Resource;
using Microsoft.AspNetCore.Mvc;

namespace Homemade.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommonChefController : ControllerBase
    {
        private readonly IUserCommonService _userCommonService;
        private readonly IUserChefService _userChefService;
        private readonly ICommonChefService _commonChefService;
        private readonly IMapper _mapper;

        public CommonChefController(IUserCommonService userCommonService, IUserChefService userChefService, ICommonChefService commonChefService, IMapper mapper)
        {
            _userCommonService = userCommonService;
            _userChefService = userChefService;
            _commonChefService = commonChefService;
            _mapper = mapper;
        }

        

        [HttpGet]
        public async Task<IEnumerable<UserChefResource>> GetAllByUsersChefIdAsync(int userchefId)
        {
            var userCommons = await _userCommonService.ListByUserChefId(userchefId);
            var resource = _mapper
                .Map<IEnumerable<UserCommon>, IEnumerable<UserChefResource>>(userCommons);
            return resource;
        }

        [HttpPost("{userCommonId}/{userChefId}")]
        public async Task<IActionResult> AssignUserChef(int userCommonId, int userChefId)
        {
            var result = await _commonChefService.AssingCommonChefAsync(userCommonId, userChefId);
            if (!result.Succes)
                return BadRequest(result.Message);
            UserChef userChef = _userChefService.GetByIdAsync(userChefId).Result.Resource;
            var resource = _mapper.Map<UserChef, UserChefResource>(userChef);
            return Ok(resource);
        }

        

    }
}
