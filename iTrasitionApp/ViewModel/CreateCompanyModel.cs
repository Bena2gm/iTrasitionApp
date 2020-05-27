using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTrasitionApp.ViewModel
{
    public class CreateCompanyModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Required]
        [Display(Name = "Goal: $")]
        [DataType(DataType.Currency)]
        [Range(1, 1000000000)]
        public int Goal { get; set; }

    }
}
