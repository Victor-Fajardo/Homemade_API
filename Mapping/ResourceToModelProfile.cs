using AutoMapper;
using Homemade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() 
        {
            CreateMap<SaveUserChefResource, UserChef>();
            CreateMap<SaveUserCommonResource, UserCommon>();
        }
    }
}
