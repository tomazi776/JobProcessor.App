﻿using JobProcessor.App.ViewModels;
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

        public ActionResult Create()
        {
            return View(new JobCreationViewModel());
        }

        [HttpPost]
        public ActionResult Create(JobCreationViewModel job)
        {
            EntityStateResult<Job> result = new EntityStateResult<Job>();
            job.SubmitHit = true;
            if (ModelState.IsValid)
            {
                result = jobService.Create(job.Name, job.DoAfter);
            }

            ModelState.Clear();
            return View(new JobCreationViewModel()
            {
                PreviousNameSubmitted = job.Name,
                SubmitHit = true,
                JobCreated = result.Success
            });
        }
        
        [HttpGet]
        public ActionResult Details(Job job)
        {
            var detailedJob = jobService.GetById(job.Id);
            var detailsVm = new JobDetailsVM(detailedJob.Data);
            return View(detailsVm);
        }
    }
}