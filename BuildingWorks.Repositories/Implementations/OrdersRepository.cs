using AutoMapper;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Models.Resources;
using BuildingWorks.Models.Resources.Providers;
using BuildingWorks.Repositories.Abstractions;
using BuildingWorks.Repositories.Abstractions.Providers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations;

public class OrdersRepository : IOrdersRepository
{
    private readonly IMapper _mapper;
    private readonly BuildingWorksDbContext _context;

    public OrdersRepository(IMapper mapper, BuildingWorksDbContext context)
    {
        _mapper = mapper;
        _context = context;
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
            order.StartDeliverAt = DateTime.UtcNow;
            order.ProviderName = provider.Name;

            var orderMaterials = entity.Materials.Select(material => new OrderMaterial
            {
                MaterialsId = material.Id,
                OrdersId = entity.Id,
                Quantity = material.Quantity,
                PricePerOne = material.PricePerOne,
            });
            await _context.OrderMaterial.AddRangeAsync(orderMaterials);
            await _context.Orders.AddAsync(order);

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
            .ExecuteUpdateAsync(ctx => ctx.SetProperty(order => order.DeliveredAt, DateTime.UtcNow));

        if (updatedCount == 0)
        {
            throw new EntityNotExistException($"Order with id {orderId} not exist in database");
        }
    }
}
