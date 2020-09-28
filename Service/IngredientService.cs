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
        public readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<IngredientResponse> DeleteAsync(int id)
        {
            var existingIngredient = await _ingredientRepository.FindById(id);
            if (existingIngredient == null)
                return new IngredientResponse("Ingredient not found");
            try
            {
                _ingredientRepository.Remove(existingIngredient);
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

        public async Task<IngredientResponse> SaveAsync(Ingredient ingredient)
        {
            try
            {
                await _ingredientRepository.AddAsync(ingredient);
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
                return new IngredientResponse(existingIngredient);
            }
            catch (Exception ex)
            {
                return new IngredientResponse($"An error ocurred while updating the Ingredient: {ex.Message}");
            }
        }
    }
}
