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
        [Required(ErrorMessage = "Enter unique name")]
        public string Name { get; set; }

        [Display(Name = "Do after (Optional)")]
        public DateTime? DoAfter { get; set; }
    }
}