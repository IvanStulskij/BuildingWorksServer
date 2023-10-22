using BuildingWorks.Common.Entities;

namespace BuildingWorks.Common.Constants;

public static class DictionariesConstants
{
    public static IReadOnlyDictionary<BuildingObjectTypes, string> BuildingObjectTypesWithNames
    {
        get
        {
            return new Dictionary<BuildingObjectTypes, string>
            {
                { BuildingObjectTypes.BusinessCenter, "Business center" },
                { BuildingObjectTypes.Cultural, "Cultural" },
                { BuildingObjectTypes.Education, "Education" },
                { BuildingObjectTypes.LivingAppartement, "Living apartaments" },
                { BuildingObjectTypes.Trade, "Trade" }
            };
        }
    }
}
