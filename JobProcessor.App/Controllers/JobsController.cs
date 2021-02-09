using JobProcessor.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobProcessor.App.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Create(string name, DateTime? doAfter)
        {
            return View();
        }
    }
}