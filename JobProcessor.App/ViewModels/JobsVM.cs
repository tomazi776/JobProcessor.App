using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
using JobProcessor.Domain.Services;
using System;
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
            Current = new Page(metadata);
            Jobs = jobService.Get(metadata);
            AssignPreviousPages();
            AssignNextPages();
        }

        public Page Current { get; set; }
        public Job Job { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<Page> NextPagesSlice { get; set; } = new List<Page>();
        public List<Page> PreviousPagesSlice { get; set; } = new List<Page>();

        public bool HasRecords(Navigation page)
        {
            switch (page)
            {
                case Navigation.Previous:
                    return (Current.Metadata.StartIndex > 0);

                case Navigation.Next:
                    var nextPageCount = jobService.GetFilteredCount(Current.Metadata.StartIndex, Current.Metadata.PageSize);
                    return nextPageCount >= 1;

            }
            return true;
        }

        public void AssignNextPages()
        {
            var pages = new List<Page>();
            var total = GetPagesCount();
            for (int nextNumber = Current.Number + 1; nextNumber < total + 1; nextNumber++)
            {
                pages.Add(new Page(Current.Metadata)
                { 
                    Number = nextNumber,
                });
            }
            NextPagesSlice = pages.Take(2).ToList();
        }

        public void AssignPreviousPages()
        {
            if (Current.Number - 1 > 0)
            {
                var total = GetPagesCount();
                var remaining = GetPagesCount(true);
                var previousPages = total - remaining;
                var pages = new List<Page>();
                for (int previousNumber = Current.Number - 1; previousNumber >= previousPages - 1; previousNumber--)
                {
                    if (previousNumber > 0)
                    {
                        pages.Add(new Page(Current.Metadata)
                        {
                            Number = previousNumber,
                        });
                        pages.Reverse();
                    }
            }
                PreviousPagesSlice = pages.Take(2).ToList();
            }
        }

        public int GetPagesCount(bool startFromCurrent = false)
        {
            int total = (startFromCurrent) 
                ? jobService.GetFilteredCount(Current.Metadata.StartIndex, int.MaxValue) 
                : jobService.GetFilteredCount(0, int.MaxValue);
            return (int)Math.Ceiling((decimal)total / (decimal)Current.Metadata.PageSize);
        }
    }
}