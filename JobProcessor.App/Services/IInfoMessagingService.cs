using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.App.Services
{
    public interface IInfoMessagingService
    {
        InfoMessagingService CreateMessage(string title, string message, string cssClass);
    }
}
