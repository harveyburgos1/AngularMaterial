using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain.Models
{
    public class PaginationResult<TEntity> where TEntity : class
    {
        public List<TEntity> Results { get; set; }
        public int TotalRecords { get; set; }
    }
}
