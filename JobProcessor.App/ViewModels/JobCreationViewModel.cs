using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobProcessor.App.ViewModels
{
    public class JobCreationViewModel
    {
        [Display(Name = "Unique Job name")]
        [RegularExpression(@".*\S+.*", ErrorMessage = "No white space allowed")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "You need to provide long enough Job Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to provide unique Job Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat( ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Do after (Optional)")]
        public DateTime? DoAfter { get; set; }
    }

}