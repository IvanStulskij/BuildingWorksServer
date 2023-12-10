using BuildingWorks.Common.Entities;

namespace BuildingWorks.Infrastructure.Loading;

public interface IPage<TEntity> where TEntity : Entity
{
    string  GetPagedList(int page, int pageSize);
}

public class Page<TEntity> : IPage<TEntity>
    where TEntity : Entity
{

    public string GetPagedList(int page, int pageSize)
    {
        if (pageSize <= 0)
        {
            return string.Empty;
        }

        return $" offset {(page - 1) * pageSize} rows fetch next {pageSize} rows only ";
    }
}
