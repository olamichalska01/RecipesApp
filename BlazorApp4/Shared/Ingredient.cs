using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp4.Shared
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [NotNull]
        public string IngredientName { get; set; }

        [NotNull]
        public int Amount { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        [NotNull]
        public int UnitOfMeasureId { get; set; }

        [JsonIgnore]
        public List<Recipe> Recipes { get; set; }
    }
}
