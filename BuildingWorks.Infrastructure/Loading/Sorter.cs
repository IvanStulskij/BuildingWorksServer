using BuildingWorks.Common.Entities;
using BuildingWorks.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BuildingWorks.Infrastructure.Loading;

public interface ISorter<TEntity>
    where TEntity : Entity
{
    string GetSortSQL(IEnumerable<SortDefinition> sortings);
}

public class Sorter<TEntity> : ISorter<TEntity>
    where TEntity : Entity
{
    private IEnumerable<string> Properties => typeof(TEntity).GetProperties().Select(x => x.Name);

    public string GetSortSQL(IEnumerable<SortDefinition> sortings)
    {
        if (sortings == null || !sortings.Any())
        {
            return string.Empty;
        }

        var sortString = GetSortString(sortings);

        return $" order by {sortString}";
    }

    private string GetSortString(IEnumerable<SortDefinition> sortDefinitions)
    {
        var sortIndex = 0;
        StringBuilder sortString = new StringBuilder();

        foreach (var sortDefinition in sortDefinitions)
        {
            if (!Properties.Contains(sortDefinition.Field, new StringCaseInsensetiveEqualityComparer()))
            {
                throw new EntityNotExistException($"Property {sortDefinition.Field} not exist in table ${typeof(TEntity).Name}");
            }

            if (string.IsNullOrWhiteSpace(sortDefinition.Order))
            {
                sortDefinition.Order = "asc";
            }

            sortString = sortString.Append($" {sortDefinition.Field} {sortDefinition.Order}");
            sortIndex++;

            if (sortIndex != sortDefinitions.Count())
            {
                sortString.Append(" then by");
            }
        }

        return sortString.ToString();
    }
}


public class SortDefinition
{
    public string Field { get; set; } = string.Empty;
    public string Order { get; set; } = string.Empty;
}

public class StringCaseInsensetiveEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        return x.Equals(y, StringComparison.OrdinalIgnoreCase);
    }

    public int GetHashCode([DisallowNull] string obj)
    {
        return obj.GetHashCode();
    }
}