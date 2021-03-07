using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.App.Services
{
    public class InfoMessagingService : IInfoMessagingService
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string CssClass { get; set; }
        public InfoMessagingService(string title, string message, string cssClass)
        {
            Title = title;
            Message = message;
            CssClass = cssClass;
        }

        public InfoMessagingService CreateMessage(string title, string message, string cssClass)
        {
            return new InfoMessagingService(title, message, cssClass);
        }
    }
}