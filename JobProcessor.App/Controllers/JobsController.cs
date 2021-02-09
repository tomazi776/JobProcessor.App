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

        public ActionResult Create(JobCreationViewModel job)
        {
            return View(job);
        }

        [HttpPost]
        public ActionResult Create(string name, DateTime? doAfter)
        {
            return View();
        }
    }
}