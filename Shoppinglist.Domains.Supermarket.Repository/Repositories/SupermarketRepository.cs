using Shoppinglist.Domains.Supermarket.Domain;
using Shoppinglist.Domains.Supermarket.Domain.Aggregate;

namespace Shoppinglist.Domains.Supermarket.Repository.Repositories;

public class SupermarketRepository : ISupermarketRepository
{
    private readonly SupermarketDBContext _supermarketDbContext;

    public SupermarketRepository(SupermarketDBContext supermarketDbContext)
    {
        _supermarketDbContext = supermarketDbContext;
    }

    public async Task<int> InsertSupermarket(SupermarketAggregate supermarket)
    {
        _supermarketDbContext.Supermarkets.Add(supermarket);
        var result = await _supermarketDbContext.SaveChangesAsync();
        return result;
    }

    public Task UpdateSupermarket(SupermarketAggregate supermarket)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSupermarket(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SupermarketAggregate>> GetAllSupermarket()
    {
        throw new NotImplementedException();
    }

    public Task<SupermarketAggregate> GetSupermarketBy(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SupermarketAggregate> GetSupermarketByAddress(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task EditAddressFromSupermarket(Guid supermarketId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAddress(Guid addressId)
    {
        throw new NotImplementedException();
    }
}