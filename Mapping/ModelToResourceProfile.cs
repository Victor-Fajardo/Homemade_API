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
            CreateMap<Comment, CommentResource>();
            CreateMap<Publication, PublicationResource>();
            CreateMap<Recipe, RecipeResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<RecipeStep, RecipeStepsResource>();
            CreateMap<Chat, ChatResource>();
            CreateMap<Menu, MenuResource>();
            CreateMap<MenuRecipe, MenuRecipeResource>();
            CreateMap<User, UserResource>();

        }
    }
}
