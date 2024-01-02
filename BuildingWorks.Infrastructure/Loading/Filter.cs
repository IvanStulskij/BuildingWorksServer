using BuildingWorks.Common.Entities;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure.Loading;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BuildingWorks.Repositories.Loading;

public interface IFilter<TEntity> where TEntity : Entity
{
    string GetFilterSQL(IEnumerable<string> filter);
}

public class Filter<TEntity> : IFilter<TEntity>
    where TEntity : Entity
{
    private const int propertyIndex = 0;
    private const int comparorIndex = 1;
    private const int valueIndex = 2;

    private IEnumerable<string> Properties => typeof(TEntity).GetProperties().Select(x => x.Name);

    public string GetFilterSQL(IEnumerable<string> filter)
    {
        if (filter == null || !filter.Any())
        {
            return string.Empty;
        }

        var filterProperties = GetFilterAssemblies(filter, propertyIndex);
        var filterComparors = GetFilterAssemblies(filter, comparorIndex);
        var filterValues = GetFilterAssemblies(filter, valueIndex);

        var fitlerString = GetFilterString(filterProperties, filterComparors, filterValues);

        return $" where {fitlerString}";
    }

    private string GetFilterString(IEnumerable<string> filterProperties, IEnumerable<string> filterComparors, IEnumerable<string> filterValues)
    {
        var filterIndex = 0;
        StringBuilder filterString = new StringBuilder();

        foreach (var filterProperty in filterProperties)
        {
            if (!Properties.Contains(filterProperty, new StringCaseInsensetiveEqualityComparer()))
            {
                throw new EntityNotExistException($"Property {filterProperty} not exist in table ${typeof(TEntity).Name}");
            }

            var filterComparor = filterComparors.ElementAt(filterIndex);
            var filterValue = filterValues.ElementAt(filterIndex);
            var property = Properties.FirstOrDefault(property => property.Equals(filterProperty, StringComparison.OrdinalIgnoreCase));

            filterString = filterString.Append($"\"{property}\" {filterComparor} '{filterValue}'");

            filterIndex++;

            if (filterIndex != filterProperties.Count())
            {
                filterString.Append(" and");
            }
        }

        return filterString.ToString();
    }

    private IEnumerable<string> GetFilterAssemblies(IEnumerable<string> filter, int filterIndex)
    {
        return filter.Select((value, index) =>
        {
            if (index == filterIndex)
            {
                return value;
            }

            return string.Empty;
        }).Where(x => !string.IsNullOrWhiteSpace(x));
    }
}
