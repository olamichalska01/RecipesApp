using BlazorApp4.Shared.DataTransferObjects;
using BlazorApp4.Shared;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp4.Client.Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient httpClient;

        public RecipeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Recipe> GetRecipeContent(int id)
        {
            Recipe result = await httpClient.GetFromJsonAsync<Recipe>($"api/Recipe/getCakeRecipe/{id}");

            Console.WriteLine(result.RecipeId);
            Console.WriteLine(result.PictureUrl);

            return result;
        }

        public async Task AddNewRecipe(NewCakeDto newCakeDto, int newCakeId)
        {
            RecipeDto NewCakeRecipe = new RecipeDto
            {
                RecipeTitle = newCakeDto.RecipeTitle,
                RecipeSteps = newCakeDto.RecipeSteps,
                RecipePicture = newCakeDto.Picture,
            };

            await httpClient.PostAsJsonAsync($"/api/Recipe/addRecipeForCake/{newCakeId}", NewCakeRecipe);
        }

        public async Task DeleteIngredientFromRecipe(int recipeId, int ingredientId)
        {
            await httpClient.DeleteAsync($"api/Recipe/deleteIngredientFromRecipe/{recipeId}/{ingredientId}");
        }

        public async Task<ServiceResponse<string>> AddIngredientToRecipe(int recipeId, IngredientDto newIngredient)
        {
            var result = await httpClient.PostAsJsonAsync($"api/Recipe/addIngredientToRecipe/{recipeId}", newIngredient);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> ChangeRecipeTitle(RecipeTitleDto recipeTitleDto, Recipe RecipeContents)
        {
            var jsonRequest = JsonConvert.SerializeObject(recipeTitleDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

            var result = await httpClient.PatchAsync($"api/Recipe/renameRecipe/{RecipeContents.RecipeId}", content);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
