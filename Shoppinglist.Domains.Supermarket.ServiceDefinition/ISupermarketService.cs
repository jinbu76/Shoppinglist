using Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

namespace Shoppinglist.Domains.Supermarket.ServiceDefinition
{
    public interface ISupermarketService
    {
        Task<SupermarketDto> InsertSupermarket(CreateSupermarketDto supermarket);
        Task<SupermarketDto> AddAddressToSupermarket(SupermarketDto supermarket, AddressDto address);
        Task<List<SupermarketDto>> GetAllSupermarket();
        Task<SupermarketDto> GetSupermarketById(Guid supermarketId);
        Task<SupermarketDto> GetSupermarketByAddressId(Guid id);
        Task EditSupermarket(SupermarketDto supermarket);
        Task EditAddressFromSupermarket(Guid supermarketId);
        Task DeleteSupermarket(Guid supermarketId);
        Task DeleteAddress(Guid addressId);
    }
}