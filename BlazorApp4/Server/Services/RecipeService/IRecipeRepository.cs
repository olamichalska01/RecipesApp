using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;

namespace BlazorApp4.Server.Services.RecipeService
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Recipe> GetRecipeForCake(int cakeId);
        Task<Recipe> AddRecipeForCake(int cakeId, RecipeDto newRecipeDto);
        Task<Recipe> DeleteRecipe(int recipeId);
        Task<ServiceResponse<string>> AddIngredientToRecipe(int recipeId, IngredientDto ingredientDto);
        Task<Ingredient> DeleteIngredientFromRecipe(int recipeId, int ingredientId);
        Task<Recipe> GetRecipeByRecipeId(int id);
        Task<ServiceResponse<string>> ChangeRecipeTitle(int recipeId, RecipeTitleDto recipeTitleDto);
    }
}
