using JobProcessor.App.ViewModels;
using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
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

        public ActionResult Index(Metadata metadata)
        {
            var jobsVM = new JobsVM(jobService, metadata);
            return View(jobsVM);
        }

        public PartialViewResult GetAll(Metadata metadata)
        {
            var jobsVm = new JobsVM(jobService, metadata);
            return PartialView(jobsVm);
        }

        public ActionResult Create()
        {
            return View(new JobCreationVM());
        }

        [HttpPost]
        public ActionResult Create(JobCreationVM job)
        {
            EntityStateResult<Job> result = new EntityStateResult<Job>();
            job.SubmitHit = true;
            if (ModelState.IsValid)
            {
                result = jobService.Create(job.Name, job.DoAfter);
            }

            ModelState.Clear();
            return View(new JobCreationVM()
            {
                PreviousNameSubmitted = job.Name,
                SubmitHit = true,
                JobCreated = result.Success
            });
        }
    }
}