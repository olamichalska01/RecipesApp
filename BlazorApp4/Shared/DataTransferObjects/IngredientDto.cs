using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp4.Shared.DataTransferObjects
{
    public class IngredientDto
    {
        [NotNull]
        public string IngredientName { get; set; }

        [NotNull]
        public int Amount { get; set; }

        [NotNull]
        public string UnitOfMeasureName { get; set; }
    }
}
