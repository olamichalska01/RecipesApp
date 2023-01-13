using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp4.Shared.DataTransferObjects
{
    public class CakeDto
    {
        public string CakeName { get; set; }

        public string DifficultyLevel { get; set; }

        public string PreparationTime { get; set; }
    }
}
