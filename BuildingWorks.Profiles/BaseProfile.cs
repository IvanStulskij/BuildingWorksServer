using AutoMapper;

namespace BuildingWorks.Profiles;

public abstract class BaseProfile<T, TResource> : Profile
{
    public BaseProfile()
    {
        CreateMap<T, TResource>().ReverseMap();
    }
}

public abstract class BaseOverviewProfile<T, TResource, TOverview> : BaseProfile<T, TResource>
{
    public BaseOverviewProfile()
    {
        CreateMap<T, TResource>().ReverseMap();
        ConfigureOverviewProfiling();
    }

    protected virtual void ConfigureOverviewProfiling()
    {
        CreateMap<T, TOverview>().ReverseMap();
    }
}