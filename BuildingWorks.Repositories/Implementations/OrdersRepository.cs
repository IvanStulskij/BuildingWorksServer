using AutoMapper;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Models.Resources;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions;
using BuildingWorks.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations;

public class OrdersRepository : IOrdersRepository
{
    private readonly IMapper _mapper;
    private readonly ISmsNotificationSender _smsNotificationSender;
    private readonly BuildingWorksDbContext _context;

    public OrdersRepository(IMapper mapper, BuildingWorksDbContext context, ISmsNotificationSender smsNotificationSender)
    {
        _mapper = mapper;
        _context = context;
        _smsNotificationSender = smsNotificationSender;
    }

    public async Task Add(OrderResource entity)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(provider => provider.Id == entity.ProviderId);
            if (provider == null)
            {
                throw new EntityNotExistException($"Provider with id {entity.ProviderId} not exist in database");
            }
            var order = _mapper.Map<Order>(entity);
            order.ProviderName = provider.Name;
            order.StatusId = (int)OrderStatuses.New;
            order.Status = Constants.OrderStatusesWithNames[OrderStatuses.New];
            order.Cost = entity.Materials.Sum(material => material.Quantity * material.PricePerOne);
            var added = await _context.Orders.AddAsync(order);

            var orderMaterials = entity.Materials.Select(material => new OrderMaterial
            {
                MaterialsId = material.Id,
                OrdersId = added.Entity.Id,
                Quantity = material.Quantity,
                PricePerOne = material.PricePerOne,
            });
            await _context.OrderMaterial.AddRangeAsync(orderMaterials);
            

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<OrderMaterialResult>> GetMaterials(Guid orderId)
    {
        var materials = await _context.OrderMaterial.AsNoTracking()
            .Where(order => order.OrdersId == orderId)
            .Select(entity => new OrderMaterialResult
            {
                Id = entity.MaterialsId,
                Name = entity.Material.Name,
                Measure = entity.Material.Name,
                PricePerOne = entity.PricePerOne,
                Quantity = entity.Quantity
            }).ToListAsync();

        return materials;
    }

    public async Task SetAsDelivered(Guid orderId)
    {
        var updatedCount = await _context.Orders
            .Where(order => order.Id == orderId)
            .ExecuteUpdateAsync(ctx => ctx
                                        .SetProperty(order => order.PlannedDeliveredAt, DateTime.UtcNow)
                                        .SetProperty(order => order.StatusId, (int)OrderStatuses.Delivered)
                                        .SetProperty(order => order.Status, Constants.OrderStatusesWithNames[OrderStatuses.Delivered]));

        if (updatedCount == 0)
        {
            throw new EntityNotExistException($"Order with id {orderId} not exist in database");
        }
    }

    public async Task SendOrderLink(Guid orderId)
    {
        /*var order = await _context.Orders.SingleOrDefaultAsync(order => order.Id == orderId);

        if (order == null)
        {
            throw new EntityNotExistException($"Order with id {orderId} not exist in database");
        }*/

        await _smsNotificationSender.SendSms("message", "+995599167435");
    }

    public async Task<bool> ApproveByProvider(Guid id)
    {
        var updatedCount = await _context.Orders
            .Where(provider => provider.Id == id)
            .ExecuteUpdateAsync(context => context
                                                .SetProperty(order => order.StatusId, (int)OrderStatuses.ApprovedByProvider)
                                                .SetProperty(order => order.Status, Constants.OrderStatusesWithNames[OrderStatuses.ApprovedByProvider]));

        return updatedCount > 0;
    }
}
