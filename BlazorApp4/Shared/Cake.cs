using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp4.Shared
{
    public class Cake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CakeId { get; set; }

        public string CakeName { get; set; }

        private string difficultyLevel;

        public static List<string> allowedDifficultyLevels = new List<string>() { "easy", "medium", "difficult", "expert" };

        public string DifficultyLevel 
        {
            get
            {
                return difficultyLevel;
            }
            set
            {
                if(allowedDifficultyLevels.Contains(value))
                {
                    difficultyLevel = value;
                }
                else
                {
                    throw new ArgumentException("This difficulty level is not allowed. " +
                        "Allowed difficulty level values: easy, medium, difficult, expert");
                }
            }
        }

        public string PreparationTime { get; set; }

        public Recipe Recipe { get; set; }
        
    }
}
