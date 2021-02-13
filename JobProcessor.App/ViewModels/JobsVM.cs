using JobProcessor.Domain.Models;
using JobProcessor.Domain.Services;
using System.Collections.Generic;


namespace JobProcessor.App.ViewModels
{
    public class JobsVM
    {
        //protected readonly IJobService jobService;

        public JobsVM(IJobService jobService, int startIndex = 0, int pageSize = 0)
        {
            JobsIndexMetadata = new JobsIndexMetadata(startIndex, pageSize);

            if (startIndex >= 0)
            {
                Jobs = jobService.GetFiltered(JobsIndexMetadata.StartIndex, JobsIndexMetadata.PageSize);
            }

            if (pageSize >= 0)
            {
                NextPageCount = jobService.GetFilteredCount(startIndex, pageSize);
            }
        }


        public JobsIndexMetadata JobsIndexMetadata { get; private set; }
        public Job Job { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();

        public int NextPageCount { get; set; }

        public bool HasRecords(Navigate page)
        {
            switch (page)
            {
                case Navigate.Previous:
                     var  so = NextPageCount >= 0;
                    return so;

                case Navigate.Next:
                    return NextPageCount >= 1;
            }
            return true;
        }
    }
}