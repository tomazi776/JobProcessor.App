using JobProcessor.App.Services;
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
        protected readonly IInfoMessagingService messagingService;
        public JobsController(IJobService jobService, IInfoMessagingService messagingService)
        {
            this.jobService = jobService;
            this.messagingService = messagingService;
        }

        public ActionResult Index(Metadata metadata)
        {
            return View(new JobsVM(jobService, metadata));
        }

        public PartialViewResult GetAll(Metadata metadata)
        {
            return PartialView(new JobsVM(jobService, metadata));
        }

        public ActionResult Create()
        {
            return View(new JobCreationVM());
        }

        [HttpPost]
        public ActionResult Create(JobCreationVM job)
        {
            if (ModelState.IsValid)
            {
                var result = jobService.Create(job.Name, job.DoAfter);
                if (result.Success)
                {
                    TempData["jobCreated"] = messagingService
                        .CreateMessage("Job created",$"Job {job.Name} succesfully created.", "text-success");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("",
                        $"Cannot create Job \"{job.Name}\" \n There already exists job with that name. Pick unique one.");
                }
            }
            return View(job);
        }
    }
}