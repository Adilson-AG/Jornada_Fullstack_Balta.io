using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Responses
{
   public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
            TData? data, 
            int totalCount,
            int currentPage = 1,
            int pageSize = Configuraton.DefaultPageSize )
            : base(data)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
        public PagedResponse(
            TData? data,
            int code = Configuraton.DefaultStatusCode,
            string? message = null)
            : base(data, code, message)
        {

        }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configuraton.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
