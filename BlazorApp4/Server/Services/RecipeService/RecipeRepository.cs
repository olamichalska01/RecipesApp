using BlazorApp4.Shared;
using BlazorApp4.Shared.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using BlazorApp4.Server.Models;

namespace BlazorApp4.Server.Services.RecipeService
{
    public class RecipeRepository : IRecipeRepository
    {
        public readonly CakesDBContext cakesDBContext;
        public RecipeRepository(CakesDBContext cakesDBContext)
        {
            this.cakesDBContext = cakesDBContext;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await cakesDBContext.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.UnitOfMeasure)
                .ToListAsync();
        }

        public async Task<Recipe> DeleteRecipe(int recipeId)
        {
            var result = await cakesDBContext.Recipes
               .FirstOrDefaultAsync(e => e.CakeId == recipeId);

            if (result != null)
            {
                cakesDBContext.Recipes.Remove(result);
                await cakesDBContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Recipe> GetRecipeByRecipeId(int id)
        {
            var recipe = await cakesDBContext.Recipes
                .FirstOrDefaultAsync(r => r.RecipeId == id);

            if(recipe != null)
            {
                return recipe;
            }

            return null;
        }

        public async Task<Recipe> GetRecipeForCake(int cakeId)
        {
            var recipe = await cakesDBContext.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.UnitOfMeasure)
                .FirstOrDefaultAsync(r => r.CakeId == cakeId);

            if (recipe != null)
            {
                return recipe;
            }

            return null;
        }

        public async Task<ServiceResponse<string>> AddIngredientToRecipe(int recipeId, IngredientDto ingredientDto)
        {
            List<Recipe> recipes = new List<Recipe>();
            var recipe = await cakesDBContext.Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.RecipeId == recipeId);
            
            if (recipe == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "No recipe with supplied id was found"
                };
            }

            if(ingredientDto.Amount <= 0 || ingredientDto.IngredientName == "" || 
                ingredientDto.UnitOfMeasureName == "")
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Please fill out all fields."
                };
            }

            recipes.Add(recipe);

            var newIngredient = new Ingredient
            {
                IngredientName = ingredientDto.IngredientName,
                Amount = ingredientDto.Amount,
                UnitOfMeasure = new UnitOfMeasure { UnitOfMeasureName = ingredientDto.UnitOfMeasureName },
                Recipes = recipes
            };

            if(recipe.ContainsIngredient(newIngredient))
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "This ingredient has already been added to this recipe."
                };
            }

            await cakesDBContext.Ingerdients.AddAsync(newIngredient);
            await cakesDBContext.SaveChangesAsync();

            return new ServiceResponse<string> { Data = newIngredient.IngredientName, Message = "Ingredient was added"};
        }

        public async Task<Ingredient> DeleteIngredientFromRecipe(int recipeId, int ingredientId)
        {
            var recipe = await cakesDBContext.Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.RecipeId == recipeId);

            var recipeIngredient = await cakesDBContext.Ingerdients
                .FirstOrDefaultAsync(r => r.IngredientId == ingredientId);

            if (recipe == null || recipeIngredient == null)
            {
                return null;
            }

            recipe.Ingredients.Remove(recipeIngredient);
            await cakesDBContext.SaveChangesAsync();

            return recipeIngredient;
        }

        public async Task<Recipe> AddRecipeForCake(int cakeId, RecipeDto newRecipeDto)
        {
            var cake = await cakesDBContext.Cakes
                .Include(c => c.Recipe)
                .FirstOrDefaultAsync(c => c.CakeId == cakeId);

            if (cake == null || cake.Recipe != null)
            {
                return null;
            }

            Recipe newCakeRecipe = new Recipe
            {
                CakeId = cakeId,
                RecipeTitle = newRecipeDto.RecipeTitle,
                RecipeSteps = newRecipeDto.RecipeSteps,
                PictureUrl = newRecipeDto.RecipePicture
            };

            await cakesDBContext.Recipes.AddAsync(newCakeRecipe);
            await cakesDBContext.SaveChangesAsync();

            return newCakeRecipe;
        }

        public async Task<ServiceResponse<string>> ChangeRecipeTitle(int recipeId, RecipeTitleDto recipeTitleDto)
        {
            var recipe = await cakesDBContext.Recipes
                .FirstOrDefaultAsync(r => r.RecipeId == recipeId);

            if (recipe == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Recipe with supplied id doesn't exist"                    
                };
            }
            else if(recipeTitleDto.Title == "")
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Invalid title value"
                };
            }

            recipe.RecipeTitle = recipeTitleDto.Title;
            await cakesDBContext.SaveChangesAsync();

            return new ServiceResponse<string> { Data = recipeTitleDto.Title, Message = "Title changed successfully."};
        }
    }
}
