﻿using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Resource;
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
            CreateMap<SaveIngredientResource, Ingredient>();
            CreateMap<SaveUserChefResource, UserChef>();
            CreateMap<SaveUserCommonResource, UserCommon>();
            CreateMap<SavePublicationResource, PublicationResource>();
            CreateMap<SaveCommentResource, CommentResource>();
            CreateMap<SaveRecipeResource, RecipeResource>();
        }
    }
}
