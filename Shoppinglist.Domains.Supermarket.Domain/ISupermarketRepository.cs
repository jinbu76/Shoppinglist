using Shoppinglist.Domains.Supermarket.Domain.Aggregate;

namespace Shoppinglist.Domains.Supermarket.Domain
{
    public interface ISupermarketRepository
    {
        Task<int> InsertSupermarket(SupermarketAggregate supermarket);
        Task UpdateSupermarket(SupermarketAggregate supermarket);
        Task DeleteSupermarket(Guid id);
        Task<List<SupermarketAggregate>> GetAllSupermarket();
        Task<SupermarketAggregate> GetSupermarketBy(Guid id);
        Task<SupermarketAggregate> GetSupermarketByAddress(Guid id);
        Task EditAddressFromSupermarket(Guid supermarketId);
        Task DeleteAddress(Guid addressId);
    }
}




