using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp4.Shared
{
    public class UnitOfMeasure
    {
        public int UnitOfMeasureId { get; set; }

        public string UnitOfMeasureName { get; set; }

        [JsonIgnore]
        public List<Ingredient> Ingredients { get; set; }
    }
}
