using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp4.Shared
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }

        public string RecipeTitle { get; set; }

        public string RecipeSteps { get; set; }

        public string PictureUrl { get; set; }

        [JsonIgnore]
        public Cake Cake { get; set; }

        [JsonIgnore]
        public int CakeId { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public bool ContainsIngredient(Ingredient newIngredient)
        {
            foreach (Ingredient recipeIngredient in Ingredients)
            {
                if (recipeIngredient.IngredientName == newIngredient.IngredientName)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
