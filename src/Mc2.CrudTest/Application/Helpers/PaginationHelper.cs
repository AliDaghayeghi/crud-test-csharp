using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Helpers;

public static class PaginationHelper
{
    public static async Task<List<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int page,
        int pageSize) where T : class
    {
        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }
}
