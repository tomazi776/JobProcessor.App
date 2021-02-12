using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.Domain.Services
{
    public class EntityStateResult<TEntity>
    {
        public TEntity Data { get; set; }
        public string ErrorMsg { get; set; }
        public bool Success { get => string.IsNullOrEmpty(ErrorMsg); }
    }
}