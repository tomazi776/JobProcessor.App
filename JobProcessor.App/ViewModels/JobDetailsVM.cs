using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.App.ViewModels
{
    public class JobDetailsVM
    {
        public Job Job { get; private set; }
        public JobDetailsVM(Job job)
        {
            Job = job;
        }
    }
}