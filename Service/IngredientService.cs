using Homemade.Domain.Models;
using Homemade.Domain.Repositories;
using Homemade.Domain.Services;
using Homemade.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;

        public IngredientService(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork, IRecipeRepository recipeRepository)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
        }

        public async Task<IngredientResponse> DeleteAsync(int id)
        {
            var existingIngredient = await _ingredientRepository.FindById(id);
            if (existingIngredient == null)
                return new IngredientResponse("Ingredient not found");
            try
            {
                _ingredientRepository.Remove(existingIngredient);
                await _unitOfWork.CompleteAsync();
                return new IngredientResponse(existingIngredient);
            }
            catch(Exception ex)
            {
                return new IngredientResponse($"An error ocurred while deleting Ingredient: {ex.Message}");
            }
        }

        public async Task<IngredientResponse> GetByIdAsync(int id)
        {
            var existingIngredient = await _ingredientRepository.FindById(id);
            if (existingIngredient == null)
                return new IngredientResponse("Ingredient not found");
            return new IngredientResponse(existingIngredient);
        }

        public async Task<IEnumerable<Ingredient>> ListAsync()
        {
            return await _ingredientRepository.ListAsync();
        }

        public async Task<IEnumerable<Ingredient>> ListByRecipeIdAsync(int recipeId)
        {
            return await _ingredientRepository.ListByRecipeIdAsync(recipeId);
        }

        public async Task<IngredientResponse> SaveAsync(Ingredient ingredient, int recipeId)
        {
            var existingRecipe = await _recipeRepository.FindById(recipeId);
            if (existingRecipe == null)
                return new IngredientResponse("Recipe not found");
            ingredient.Recipe = existingRecipe;
            try
            {
                await _ingredientRepository.AddAsync(ingredient);
                await _unitOfWork.CompleteAsync();
                return new IngredientResponse(ingredient);
            }
            catch (Exception ex)
            {
                return new IngredientResponse($"An error ocurred while saving the Ingredient: {ex.Message}");
            }
        }

        public async Task<IngredientResponse> UpdateAsync(int id, Ingredient ingredient)
        {
            var existingIngredient = await _ingredientRepository.FindById(id);
            if (existingIngredient == null)
                return new IngredientResponse("Ingredient not found");
            existingIngredient.Name = ingredient.Name;
            try
            {
                _ingredientRepository.Update(existingIngredient);
                await _unitOfWork.CompleteAsync();
                return new IngredientResponse(existingIngredient);
            }
            catch (Exception ex)
            {
                return new IngredientResponse($"An error ocurred while updating the Ingredient: {ex.Message}");
            }
        }
    }
}
