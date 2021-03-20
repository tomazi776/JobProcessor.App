using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.DataAccess.Services
{
    public interface IFiltrable
    {
        int GetFilteredCount(int startIndex, int pageSize);

    }
}
