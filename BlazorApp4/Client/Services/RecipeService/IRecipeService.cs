using BlazorApp4.Shared.DataTransferObjects;
using BlazorApp4.Shared;

namespace BlazorApp4.Client.Services.RecipeService
{
    public interface IRecipeService
    {
        Task<ServiceResponse<string>> AddIngredientToRecipe(int recipeId, IngredientDto newIngredient);
        Task DeleteIngredientFromRecipe(int recipeId, int ingredientId);
        Task<ServiceResponse<string>> ChangeRecipeTitle(RecipeTitleDto recipeTitleDto, Recipe RecipeContents);
        Task<Recipe> GetRecipeContent(int id);
        Task AddNewRecipe(NewCakeDto newCakeDto, int newCakeId);
    }
}
