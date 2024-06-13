using ForUserApi.Common.Helpers;
using ForUserApi.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ForUserApi.Common.Extensions;

#pragma warning disable
public static class PaginationExtension
{
    public static async Task<IList<T>> ToPagedListAsync<T>(this IQueryable<T> sourse, 
                                                                PaginationParams @params)
    {
        if (@params.PageIndex == 0 ||  @params.PageSize == 0) 
            @params = new PaginationParams(1, 10);

        var count = await sourse.CountAsync();

        var metadata = new PaginationMetaData(count, @params.PageIndex, @params.PageSize);

        HttpContextHelper.ResponseHeaders.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return await sourse.Skip(@params.SkipCount())
                           .Take(@params.PageSize)
                           .ToListAsync();
    }
}