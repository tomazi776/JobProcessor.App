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

        public ActionResult Index(int startIndex = 0, int pageSize = 2)
        {
            var jobsVM = new JobsVM(jobService, startIndex, pageSize);
            return View(jobsVM);
        }

        public ActionResult Create(JobCreationVM job)
        {
            ModelState.Clear();
            return View(job);
        }

        [HttpPost]
        public ActionResult Create(string name, DateTime? doAfter)
        {
            if (ModelState.IsValid)
            {
                jobService.Create(name, doAfter);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Success()
        {
            ModelState.Clear();
            return Content("Job Created");
        }
    }
}