using BlazorApp4.Server.Services.RecipeService;
using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Pkcs;
using System.Xml.XPath;

namespace BlazorApp4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public readonly IRecipeRepository recipeRepository;
        
        public RecipeController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet("getCakeRecipe/{id:int}")]
        public async Task<ActionResult<Recipe>> GetCakeRecipe(int id)
        {
            var result = await recipeRepository.GetRecipeForCake(id);

            if (result == null)
            {
                return BadRequest("Couldn't find recipe for this cake id.");
            }

            return result;
        }

        [HttpPost("addIngredientToRecipe/{recipeId:int}")]
        public async Task<ActionResult<ServiceResponse<string>>> AddIngredientToRecipe(int recipeId, IngredientDto ingredientDto)
        {
            var response = await recipeRepository.AddIngredientToRecipe(recipeId, ingredientDto);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("addRecipeForCake/{cakeId:int}")]
        public async Task<ActionResult<Recipe>> AddRecipeForCake(int cakeId, RecipeDto newRecipeDto)
        {
            var result = await recipeRepository.AddRecipeForCake(cakeId, newRecipeDto);

            if(result == null)
            {
                return BadRequest("Couldn't add recipe for a cake with supplied id. " +
                    "Either cake with this id doesn't exist or cake with this id already has a recipe.");
            }

            return result;
        }

        [HttpDelete("deleteIngredientFromRecipe/{recipeId:int}/{ingredientId:int}")]
        public async Task<ActionResult<Ingredient>> DeleteIngredientFromRecipe(int recipeId, int ingredientId)
        {
            var result = await recipeRepository.DeleteIngredientFromRecipe(recipeId, ingredientId);

            if (result == null)
            {
                return BadRequest("Ingredient could not be deleted. Either could not find recipe or ingredient.");
            }

            return result;
        }

        [HttpPatch("renameRecipe/{recipeId:int}")]
        public async Task<ActionResult<ServiceResponse<string>>> RenameRecipeTitle(int recipeId, RecipeTitleDto recipeTitleDto)
        {
            var response = await recipeRepository.ChangeRecipeTitle(recipeId, recipeTitleDto);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
