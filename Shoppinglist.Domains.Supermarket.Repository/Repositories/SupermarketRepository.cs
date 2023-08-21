using Microsoft.EntityFrameworkCore;
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

    public async Task AddAddressToSupermarket(AddressAggregate address)
    {
        _supermarketDbContext.Addresses.Add(address);
        await _supermarketDbContext.SaveChangesAsync();
    }

    public async Task UpdateSupermarket(SupermarketAggregate supermarket)
    {
        _supermarketDbContext.Supermarkets.Update(supermarket);
        await _supermarketDbContext.SaveChangesAsync();
    }

    public async Task DeleteSupermarket(Guid id)
    {
        _supermarketDbContext.Supermarkets.Remove(_supermarketDbContext.Supermarkets.Single(sm => sm.Id == id));
        await _supermarketDbContext.SaveChangesAsync();
    }

    public async Task<List<SupermarketAggregate>> GetAllSupermarket()
    {
        var supermarketList = await _supermarketDbContext.Supermarkets.ToListAsync();
        var addressList = await _supermarketDbContext.Addresses.ToListAsync();
        return supermarketList;
    }
    

    public async Task<SupermarketAggregate> GetSupermarketBy(Guid id) => _supermarketDbContext.Supermarkets.Single(sm => sm.Id == id);

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