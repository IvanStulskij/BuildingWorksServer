using BuildingWorks.Common.Entities;
using BuildingWorks.Repositories.Loading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BuildingWorks.Infrastructure.Loading;

public interface ILoader<TEntity> where TEntity : Entity
{
    Task<LoadResult<TEntity>> Load(IQueryable<TEntity> entities, LoadConditions loadConditions);
}

public class Loader<TEntity> : ILoader<TEntity>
    where TEntity : Entity
{
    private readonly BuildingWorksDbContext _context;
    private readonly ISorter<TEntity> _sorter;
    private readonly IFilter<TEntity> _filter;
    private readonly IPage<TEntity> _page;

    public Loader(BuildingWorksDbContext context, ISorter<TEntity> sorter, IFilter<TEntity> filter, IPage<TEntity> page)
    {
        _context = context;
        _page = page;
        _filter = filter;
        _sorter = sorter;
    }

    public async Task<LoadResult<TEntity>> Load(IQueryable<TEntity> entities, LoadConditions loadConditions)
    {
        var loadSql = GetLoadSQL(loadConditions);
        var jsonExpression = BuildJson(entities.ToQueryString());
        var loadedJson = $"[{string.Join(",", await _context.Database.SqlQueryRaw<string>($"{jsonExpression} {loadSql}").ToListAsync())}]";
        var data = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(loadedJson);
        var count = data.Count();

        return new LoadResult<TEntity>
        {
            Data = data,
            TotalCount = count,
        };
    }

    private string BuildJson(string valueSql)
    {
        var properties = valueSql.Substring(valueSql.LastIndexOf("SELECT", StringComparison.OrdinalIgnoreCase) + "Select".Length + 1, valueSql.IndexOf("FROM", StringComparison.OrdinalIgnoreCase) - "Select".Length - 2);
        var jsonProperties = string.Join(",", properties.Split(',').Select(x => $"'{x.Substring(x.IndexOf("\"") + 1, x.LastIndexOf("\"") - x.IndexOf("\"") - 1)}', {x}"));
        
        return valueSql.Replace(properties, $"json_build_object({jsonProperties})");
    }

    private string GetLoadSQL(LoadConditions loadConditions)
    {
        var filterSql = _filter.GetFilterSQL(loadConditions.Filter);
        var sortSql = _sorter.GetSortSQL(loadConditions.Sorter);
        var pageSql = _page.GetPagedList(loadConditions.Page != null ? loadConditions.Page.Value : 0, loadConditions.PageSize != null ? loadConditions.PageSize.Value : 0);
        var sql = $" {filterSql} {sortSql} {pageSql}";

        return sql;
    }
}

public class LoadConditions
{
    public IList<string> Filter { get; set; } = new List<string>();
    [FromQuery(Name = "Sorter")]
    public IList<SortDefinition> Sorter { get; set; } = new List<SortDefinition>();
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}

public class LoadResult<T>
{
    public IEnumerable<T> Data { get; set; }
    public int TotalCount { get; set; }
}