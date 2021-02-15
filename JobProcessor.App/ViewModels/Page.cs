using JobProcessor.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.App.ViewModels
{
    public class Page
    {
        public int Number { get; set; }
        public Metadata Metadata { get; set; } = new Metadata();

        public int GetLandingPageIndex(int landingPage)
        {
            int landingPageIndex = landingPage * Metadata.PageSize - Metadata.PageSize;
            return landingPageIndex;
        }
    }
}