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
    [Route("api/[controller]")]
    public class CommonChefController : ControllerBase
    {
        private readonly IUserChefService _userChefService;
        private readonly ICommonChefService _commonChefService;
        private readonly IMapper _mapper;

        public CommonChefController(IUserChefService userChefService, ICommonChefService commonChefService, IMapper mapper)
        {
            _userChefService = userChefService;
            _commonChefService = commonChefService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserChefResource>> GetAllByUsersCommondAsync(int userCommonId)
        {
            var userChefs = await _userChefService.ListByUserCommonId(userCommonId);
            var resource = _mapper
                .Map<IEnumerable<UserChef>, IEnumerable<UserChefResource>>(userChefs);
            return resource;
        }

    }
}
