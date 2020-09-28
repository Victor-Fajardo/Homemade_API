using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Ingredient, IngredientResource>();
            CreateMap<UserChef, UserChefResource>();
            CreateMap<UserCommon, UserCommonResource>();
        }
    }
}
