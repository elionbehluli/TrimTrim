using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrimTrim.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int pageIndex, int pageSize, int totalCount)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            Items = items;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, pageIndex, pageSize, totalCount);
        }
    }
}