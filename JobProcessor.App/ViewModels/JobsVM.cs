using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
using JobProcessor.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace JobProcessor.App.ViewModels
{
    public class JobsVM
    {
        protected readonly IJobService jobService;
        public JobsVM(IJobService jobService, Metadata metadata)
        {
            this.jobService = jobService;

            Metadata = metadata;

            GetJobs();
            GetNextPageCount();
        }

        public Metadata Metadata { get; set; }
        public Job Job { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public int NextPageCount { get; set; }

        public bool HasRecords(Navigation page)
        {
            switch (page)
            {
                case Navigation.Previous:
                    var so = (Metadata.StartIndex > 0);
                    return so;

                case Navigation.Next:
                    return NextPageCount >= 1;
            }
            return true;
        }

        public void GetJobs()
        {
            Jobs = jobService.Get(Metadata);
        }

        public void GetNextPageCount()
        {
            NextPageCount = jobService.GetFilteredCount(Metadata.StartIndex, Metadata.PageSize);
        }

        public int SetBackPageIndex()
        {
            int backPageIndex = Metadata.StartIndex;
            if (Jobs.Any())
            {
                foreach (var item in Jobs)
                {
                    foreach (var i in Jobs)
                    {
                        backPageIndex--;
                    }
                }
            }
            else
            {
                backPageIndex = Metadata.StartIndex - Metadata.PageSize;
            }
            return backPageIndex;
        }

    }
}