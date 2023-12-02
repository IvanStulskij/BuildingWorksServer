using AutoMapper;

namespace BuildingWorks.Profiles;

public abstract class BaseProfile<T, TResource> : Profile
{
    protected BaseProfile()
    {
        ConfigureResourceProfile();
    }

    protected virtual void ConfigureResourceProfile()
    {
        CreateMap<T, TResource>().ReverseMap();
    }
}

public abstract class BaseOverviewProfile<T, TResource, TOverview> : BaseProfile<T, TResource>
{
    protected BaseOverviewProfile()
    {
        CreateMap<T, TResource>().ReverseMap();
        ConfigureOverviewProfiling();
    }

    protected virtual void ConfigureOverviewProfiling()
    {
        CreateMap<T, TOverview>().ReverseMap();
    }
}