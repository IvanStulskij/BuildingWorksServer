using BuildingWorks.Infrastructure.Entities;

namespace BuildingWorks.Repositories;

public static class Constants
{
    public static readonly IReadOnlyDictionary<OrderStatuses, string> OrderStatusesWithNames = new Dictionary<OrderStatuses, string>
    {
        { OrderStatuses.Created, "Новый" },
        { OrderStatuses.ApprovedByProvider, "Подтвержден поставщиком" },
        { OrderStatuses.StartDeliver, "Начал доставку" },
        { OrderStatuses.Delivered, "Доставлен" },
        { OrderStatuses.MoneyTransferred, "Деньги перечислены" },
    };
}
