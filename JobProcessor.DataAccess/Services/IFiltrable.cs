using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.DataAccess.Services
{
    public interface IFiltrable<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FactorToPaginate(int startIndex = 0, int pageSize = 0);
    }
}
