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
    public class RecipeStepsService : IRecipeStepsService
    {
        private readonly IRecipeStepsRepository _recipeStepsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeStepsService(IRecipeStepsRepository recipeStepsRepository, IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeStepsRepository = recipeStepsRepository;
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeStepsResponse> Delete(int id)
        {
            var existingRecipeSteps = await _recipeStepsRepository.FindById(id);
            if (existingRecipeSteps == null)
                return new RecipeStepsResponse("RecipeSteps not found");

            try
            {
                _recipeStepsRepository.Remove(existingRecipeSteps);
                await _unitOfWork.CompleteAsync();
                return new RecipeStepsResponse(existingRecipeSteps);
            }
            catch (Exception ex)
            {
                return new RecipeStepsResponse($"An error ocurred while deleting RecipeSteps: {ex.Message}");
            }
        }

        public async Task<IEnumerable<RecipeStep>> ListByRecipeIdAsync(int recipeId)
        {
            return await _recipeStepsRepository.ListByRecipeIdAsync(recipeId);
        }

        public async Task<RecipeStepsResponse> SaveAsync(RecipeStep recipeStep, int recipeId)
        {
            var existingRecipe = await _recipeRepository.FindById(recipeId);
            if (existingRecipe == null)
                return new RecipeStepsResponse("Recipe not found");
            recipeStep.Recipe = existingRecipe;
            try
            {
                await _recipeStepsRepository.AddAsync(recipeStep);
                await _unitOfWork.CompleteAsync();
                return new RecipeStepsResponse(recipeStep);
            }
            catch (Exception ex)
            {
                return new RecipeStepsResponse(
                    $"An error ocurred while saving the RecipeStep: {ex.Message}");
            }
        }

        public async Task<RecipeStepsResponse> UpdateAsync(int id, RecipeStep recipeStep)
        {
            var existingRecipeSteps = await _recipeStepsRepository.FindById(id);
            if (existingRecipeSteps == null)
                return new RecipeStepsResponse("RecipeSteps not found");

            existingRecipeSteps.Instructions = recipeStep.Instructions;
            existingRecipeSteps.Picture = recipeStep.Picture;

            try
            {
                _recipeStepsRepository.Update(existingRecipeSteps);
                await _unitOfWork.CompleteAsync();
                return new RecipeStepsResponse(existingRecipeSteps);
            }
            catch (Exception ex)
            {
                return new RecipeStepsResponse($"An error ocurred while updating RecipeStep: {ex.Message}");
            }
        }
    }
}
