using JobProcessor.App.ViewModels;
using JobProcessor.Domain.Services;
using System;
using System.Web.Mvc;

namespace JobProcessor.App.Controllers
{
    public class JobsController : Controller
    {
        protected readonly IJobService jobService;
        public JobsController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        public ActionResult Create()
        {
            return View(new JobCreationViewModel());
        }

        [HttpPost]
        public ActionResult Create(JobCreationViewModel job)
        {
            job.SubmitHit = true;
            jobService.Create(job.Name, out int rowsAffected, job.DoAfter);
            job.AffectedRows = rowsAffected;
            ModelState.Clear();

            return View(new JobCreationViewModel() 
            {
                PreviousNameSubmitted = job.Name, 
                AffectedRows = rowsAffected, SubmitHit = true 
            });
        }
    }
}