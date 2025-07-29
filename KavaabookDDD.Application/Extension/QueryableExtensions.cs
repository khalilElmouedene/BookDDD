using BookDDD.Application.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Application.Extension
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int skipCount, int maxResultCount) where T : class
        {
            if (source == null) throw new Exception("Error");
            skipCount = skipCount == 0 ? 1 : skipCount;
            maxResultCount = maxResultCount == 0 ? 10 : maxResultCount;
            int count = await source.CountAsync();
            skipCount = skipCount <= 0 ? 1 : skipCount;
            List<T> items = await source.Skip((skipCount - 1) * maxResultCount).Take(maxResultCount).ToListAsync();
            return PaginatedResult<T>.Success(items, count, skipCount, maxResultCount);
        }
    }
}