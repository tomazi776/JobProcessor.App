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
        private int CurrentNumber;
        private int NextPageCount;
        public JobsVM(IJobService jobService, Metadata metadata)
        {
            this.jobService = jobService;
            Metadata = metadata;

            Jobs = Jobs = jobService.Get(Metadata);
            CurrentNumber = GetCurrentPageNumber(GetTotalPages(), metadata.StartIndex);
            NextPageCount = jobService.GetFilteredCount(Metadata.StartIndex, Metadata.PageSize);
            AssignNextPages();
        }

        
        public Metadata Metadata { get; set; }
        public Job Job { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
        public List<Page> PagesSlice { get; set; } = new List<Page>();

        public bool HasRecords(Navigation page)
        {
            switch (page)
            {
                case Navigation.Previous:
                    return (Metadata.StartIndex > 0);

                case Navigation.Next:
                    return NextPageCount >= 1;
            }
            return true;
        }

        public void AssignNextPages()
        {
            var pages = new List<Page>();
            var remainingPages = GetTotalPages();
            for (int nextNumber = CurrentNumber + 1; nextNumber < remainingPages + 1; nextNumber++)
            {
                pages.Add(new Page()
                { 
                    Number = nextNumber, 
                    Metadata = new Metadata() { StartIndex = GetPreviousPageIndex(), PageSize = Metadata.PageSize } 
                });
            }
            PagesSlice = pages.Take(5).ToList();
        }

        public int GetTotalPages()
        {
            var totalRecordsCount = jobService.GetFilteredCount(0, int.MaxValue);
            return (int)Math.Ceiling((decimal)totalRecordsCount / (decimal)Metadata.PageSize);
        }

        public int GetCurrentPageNumber(int totalPages, int startIndex)
        {
            var previousPagesCount = GetPreviousPagesCount(startIndex, Metadata.PageSize);
            var currentPage = previousPagesCount + 1;

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }
            return currentPage;
        }

        public int GetPreviousPagesCount(int totalRecordsCount,  int pageSize)
        {
            return (int)Math.Ceiling((decimal)totalRecordsCount / (decimal)pageSize);
        }

        public int GetPreviousPageIndex()
        {
            int pageStartIndex = Metadata.StartIndex;
            if (Jobs.Any())
            {
                foreach (var item in Jobs)
                {
                    pageStartIndex--;
                }
            }
            else
            {
                pageStartIndex = Metadata.StartIndex - Metadata.PageSize;
            }
            return pageStartIndex;
        }
    }
}