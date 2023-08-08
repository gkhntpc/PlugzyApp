using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Base
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; }

        public static async Task<PagedResult<T>> CreateAsync(List<T> dataList, int currentPage, int pageSize)
        {
            int totalCount = dataList.Count;
            int totalPageCount = (int)Math.Ceiling((double)totalCount / pageSize);

            // Ensure currentPage is within valid range
            currentPage = Math.Max(1, Math.Min(totalPageCount, currentPage));

            List<T> data = dataList
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return await Task.FromResult(new PagedResult<T>
            {
                TotalCount = totalCount,
                TotalPageCount = totalPageCount,
                CurrentPage = currentPage,
                PageSize = pageSize,
                Data = data
            });
        }
    }
}