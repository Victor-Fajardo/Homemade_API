using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Homemade.Domain.Models;
using Homemade.Domain.Services;
using Homemade.Extensions;
using Homemade.Resource;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homemade.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService;
            _mapper = mapper;
        }

        // GET: api/<IngredientController>
        [HttpGet]
        public async Task<IEnumerable<IngredientResource>> GetAllAsync()
        {
            var ingredients = await _ingredientService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Ingredient>,
                IEnumerable<IngredientResource>>(ingredients);
            return resource;
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IngredientController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveIngredientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);

            var result = await _ingredientService.SaveAsync(ingredient);

            if (!result.Succes)
                return BadRequest(result.Message);
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
            return Ok(ingredientResource);
        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveIngredientResource resource)
        {
            var ingredient = _mapper.Map<SaveIngredientResource, Ingredient>(resource);
            var result = await _ingredientService.UpdateAsync(id, ingredient);
            if (!result.Succes)
                return BadRequest(result.Message);
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
            return Ok(ingredientResource);
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ingredientService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var ingredientResource = _mapper.Map<Ingredient, IngredientResource>(result.Resource);
            return Ok(ingredientResource);
        }
    }
}
