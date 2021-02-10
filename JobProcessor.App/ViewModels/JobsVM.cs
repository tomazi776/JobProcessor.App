using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.App.ViewModels
{
    public class JobsVM
    {
        public string Action { get; set; }
        public Job Job { get; set; }
        public List<Job> Jobs { get; set; }
    }
}