using AutoMapper;
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
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveCommentResource, Comment>();
            CreateMap<SaveRecipeResource, Recipe>();
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<SaveRecipeStepsResource, RecipeStep>();
            CreateMap<SaveChatResource, Chat>();
            CreateMap<SaveMenuResource, Menu>();
            CreateMap<SaveMenuRecipeResource, MenuRecipe>();
            CreateMap<SaveUserResource, User>();

        }
    }
}
