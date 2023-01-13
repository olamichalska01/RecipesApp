using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp4.Shared.DataTransferObjects
{
    public class NewCakeDto
    {
        [Required]
        public string CakeName { get; set; } = string.Empty;

        [Required]
        public string DifficultyLevel { get; set; } = string.Empty;

        [Required]
        public string PreparationTime { get; set; } = string.Empty;

        [Required]
        public string RecipeTitle { get; set; } = string.Empty;

        [Required]
        public string RecipeSteps { get; set; } = string.Empty;

        [Required]
        public string Picture { get; set; } = string.Empty;
    }
}
